using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly ITokenService _tokenService;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, IUnitOfWork unitOfWork,
			ITokenService tokenService, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_unitOfWork = unitOfWork;
			_tokenService = tokenService;
			_signInManager = signInManager;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

			if (user == null) return Unauthorized("Invalid Username!");

			var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

			if (!result.Succeeded) return Unauthorized("Username or password is incorrect");
			return Ok(new NewUserDto
			{
				UserName = user.UserName,
				Email = user.Email,
				Token = _tokenService.CreateToken(user)

			});
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);
				var appUser = new AppUser
				{
					UserName = registerDto.Username,
					Email = registerDto.Email,
					PhoneNumber = registerDto.Mobile
				};

				var createUser = await _userManager.CreateAsync(appUser, registerDto.Password);

				if (createUser.Succeeded)
				{
					var address = new UserAddress
					{

						Address = registerDto.Address,
						City = registerDto.City,
						Country = registerDto.Country,
						Telephone = registerDto.Telephone,
						Mobile = registerDto.Mobile,
						State = registerDto.State,
						PostalCode = registerDto.PostalCode,
						UserId = appUser.Id
					};
					_unitOfWork.UserAddress.AddAsync(address);
					await _unitOfWork.SaveAsync();

					var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
					if (roleResult.Succeeded)
					{
						return Ok(
							new NewUserDto
							{
								UserName = appUser.UserName,
								Email = appUser.Email,
								Token = _tokenService.CreateToken(appUser)
							});
					}
					else
					{
						return BadRequest(ModelState);
					}
				}
				else
				{
					return StatusCode(500, createUser.Errors);
				}
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
				throw;
			}
		}

	}

}
