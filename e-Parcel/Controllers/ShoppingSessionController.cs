using AutoMapper;
using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs.ShoppingSessions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_Parcel.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoppingSessionController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ShoppingSessionController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var _data = await _unitOfWork.ShoppingSession.GetAllAsync();
			if (!ModelState.IsValid) return BadRequest(ModelState);

			return Ok(_mapper.Map<List<ShoppingSessionDto>>(_data));
		}


		[HttpGet]
		[Route("{id:guid}")]
		public async Task<IActionResult> GetByID([FromRoute] Guid id)
		{
			var _data = await _unitOfWork.ShoppingSession.GetAsync(c => c.Id == id);
			if (_data == null) return NotFound();
			return Ok(_mapper.Map<ShoppingSessionDto>(_data));
		}


		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ShoppingSessionAddDto obj)
		{
			if (obj == null) return BadRequest("Shopping Session is null");

			var shoppingSessionDomain = _mapper.Map<ShoppingSession>(obj);
			shoppingSessionDomain.CreatedOn = DateTime.Now;

			await _unitOfWork.ShoppingSession.AddAsync(shoppingSessionDomain);
			await _unitOfWork.SaveAsync();

			var shoppingSessionDTO = _mapper.Map<ShoppingSessionDto>(shoppingSessionDomain);

			return CreatedAtAction(nameof(GetByID), new { id = shoppingSessionDTO.Id }, shoppingSessionDTO);
		}

		[HttpPut]
		[Route("{id:guid}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ShoppingSessionUpdateDto obj)
		{
			if (id != obj.Id || obj == null) return BadRequest();

			var shoppingSessionDomain = _mapper.Map<ShoppingSession>(obj);

			shoppingSessionDomain = await _unitOfWork.ShoppingSession.UpdateAsync(id, shoppingSessionDomain);
			if (shoppingSessionDomain == null) return NotFound();

			await _unitOfWork.SaveAsync();

			return Ok(_mapper.Map<ShoppingSessionDto>(shoppingSessionDomain));
		}


		//[HttpDelete("{id}")]
		//public IActionResult Delete(int id)
		//{
		//    var _data = _unitOfWork.ShoppingSession.Get(c => c.Id == id);
		//    if(_data == null) return NotFound();

		//    _unitOfWork.ShoppingSession.Remove(_data);
		//    _unitOfWork.Save();
		//    return Ok();
		//}

		//[HttpDelete("range")]
		//public IActionResult DeleteRange(IEnumerable<int> ids)
		//{
		//    var _items = new List<ShoppingSession>();

		//    foreach(int id in ids)
		//    {
		//        var _item = _unitOfWork.ShoppingSession.Get(c => c.Id == id);
		//        if(_item != null) _items.Add(_item);
		//    }
		//    if(_items.Count == 0) return NotFound();

		//    _unitOfWork.ShoppingSession.RemoveRange(_items);
		//    _unitOfWork.Save();
		//    return Ok(_items);
		//}
	}
}
