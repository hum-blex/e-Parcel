using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;
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
	public IActionResult GetDiscounts()
	{
		var _data = _unitOfWork.Discount.GetAll();
		if (!ModelState.IsValid) return BadRequest(ModelState);
		return Ok(_data);
	}


	[HttpGet("{id}")]
	public IActionResult GetDiscount(int id)
	{
		var _data = _unitOfWork.Discount.Get(c => c.Id == id);
		if (_data == null) return NotFound();

		return Ok(_data);
	}

	[HttpPost]
	public IActionResult Create(Discount obj)
	{
		if (obj == null) return BadRequest("Category is Null");
		_unitOfWork.Discount.Add(obj);
		_unitOfWork.Save();
		return CreatedAtAction(nameof(GetDiscount), new { id = obj.Id }, obj);
	}

	[HttpDelete("{id}")]
	public IActionResult Delete(int id, Discount obj)
	{
        if (id != obj.Id || obj == null) return BadRequest();

        _unitOfWork.Discount.Remove(obj);
		_unitOfWork.Save();
		return NoContent();
	}


	[HttpPut("{id}")]
	public IActionResult UpdateDiscounts(int id, [FromBody] Discount obj)
	{
		if (id != obj.Id || obj == null) return BadRequest();

		_unitOfWork.Discount.Update(obj);
		_unitOfWork.Save();
		return NoContent();
	}

	[HttpDelete("range")]
	public IActionResult DeleteRange(IEnumerable<int> ids)
	{
		var discounts = new List<Discount>();
		foreach (int id in ids)
		{
			var discount = _unitOfWork.Discount.Get(c => c.Id == id);
			if (discount != null) discounts.Add(discount);
		}
		if (discounts.Count == 0) return NotFound();
		_unitOfWork.Discount.RemoveRange(discounts);
		_unitOfWork.Save();
		return Ok(discounts);
	}
}
