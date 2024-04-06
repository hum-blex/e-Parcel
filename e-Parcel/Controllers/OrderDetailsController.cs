using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace e_Parcel.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork;
	public OrderDetailsController(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	[HttpGet]
	public async Task<ActionResult<OrderDetail>> GetAll()
	{
		var _data = await _unitOfWork.OrderDetail.GetAllAsync();
		if (!ModelState.IsValid) return BadRequest(ModelState);
		return Ok(_data);
	}


	[HttpGet("{id}")]
	public async Task<ActionResult<OrderDetail>> Get(int id)
	{
		var _data = await _unitOfWork.OrderDetail.GetAsync(c => c.Id == id);
		if (_data == null) return NotFound();
		return Ok(_data);
	}


	[HttpPost]
	public async Task<ActionResult<OrderDetail>> Create([FromBody] OrderDetail obj)
	{
		if (obj == null) return BadRequest("Order Detail is null");

		await _unitOfWork.OrderDetail.AddAsync(obj);
		await _unitOfWork.SaveAsync();
		return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<OrderDetail>> Update(int id, [FromBody] OrderDetail obj)
	{
		if (id != obj.Id || obj == null) return BadRequest();

		_unitOfWork.OrderDetail.Update(obj);
		await _unitOfWork.SaveAsync();
		return Ok();
	}


	[HttpDelete("{id}")]
	public async Task<ActionResult<OrderDetail>> Delete(int id)
	{
		var _data = await _unitOfWork.OrderDetail.GetAsync(c => c.Id == id);
		if (_data == null) return NotFound();

		_unitOfWork.OrderDetail.RemoveAsync(_data);
		await _unitOfWork.SaveAsync();
		return Ok();
	}

	[HttpDelete("range")]
	public async Task<ActionResult<OrderDetail>> DeleteRange(IEnumerable<int> ids)
	{
		var _items = new List<OrderDetail>();

		foreach (int id in ids)
		{
			var _item = await _unitOfWork.OrderDetail.GetAsync(c => c.Id == id);
			if (_item != null) _items.Add(_item);
		}
		if (_items.Count == 0) return NotFound();

		_unitOfWork.OrderDetail.RemoveRangeAsync(_items);
		await _unitOfWork.SaveAsync();
		return Ok(_items);
	}
}

