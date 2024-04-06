using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using Microsoft.AspNetCore.Mvc;


namespace e_Parcel.Controllers;

[Route("[controller]")]
[ApiController]
public class DiscountsController : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork;

	public DiscountsController(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	[HttpGet]
	public async Task<ActionResult<Discount>> GetDiscounts()
	{
		var _data = await _unitOfWork.Discount.GetAllAsync();
		if (!ModelState.IsValid) return BadRequest(ModelState);
		return Ok(_data);
	}


	[HttpGet("{id}")]
	public async Task<ActionResult<Discount>> GetDiscount(int id)
	{
		var _data = await _unitOfWork.Discount.GetAsync(c => c.Id == id);
		if (_data == null) return NotFound();

		return Ok(_data);
	}

	[HttpPost]
	public async Task<ActionResult<Discount>> Create(Discount obj)
	{
		if (obj == null) return BadRequest("Category is Null");
		await _unitOfWork.Discount.AddAsync(obj);
		await _unitOfWork.SaveAsync();
		return CreatedAtAction(nameof(GetDiscount), new { id = obj.Id }, obj);
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<Discount>> Delete(int id)
	{
		var _data = await _unitOfWork.Discount.GetAsync(c => c.Id == id);
		if (_data == null) return NotFound();

		_unitOfWork.Discount.RemoveAsync(_data);
		await _unitOfWork.SaveAsync();
		return NoContent();
	}


	[HttpPut("{id}")]
	public async Task<ActionResult<Discount>> UpdateDiscounts(int id, [FromBody] Discount obj)
	{
		if (id != obj.Id || obj == null) return BadRequest();

		_unitOfWork.Discount.Update(obj);
		await _unitOfWork.SaveAsync();
		return NoContent();
	}

	[HttpDelete("range")]
	public async Task<ActionResult<Discount>> DeleteRange(IEnumerable<int> ids)
	{
		var discounts = new List<Discount>();
		foreach (int id in ids)
		{
			var discount = await _unitOfWork.Discount.GetAsync(c => c.Id == id);
			if (discount != null) discounts.Add(discount);
		}
		if (discounts.Count == 0) return NotFound();
		_unitOfWork.Discount.RemoveRangeAsync(discounts);
		await _unitOfWork.SaveAsync();
		return Ok(discounts);
	}
}
