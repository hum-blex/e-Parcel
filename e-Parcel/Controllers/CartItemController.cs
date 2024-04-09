using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_Parcel.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartItemController : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork;
	public CartItemController(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	[HttpGet]
	public async Task<ActionResult<CartItem>> GetAll()
	{
		var _data = await _unitOfWork.CartItem.GetAllAsync();
		if (!ModelState.IsValid) return BadRequest(ModelState);
		return Ok(_data);
	}


	[HttpGet("{id}")]
	public async Task<ActionResult<CartItem>> Get(Guid id, CartItem obj)
	{
		var _data = await _unitOfWork.CartItem.GetAsync(c => c.Id == id);
		if (_data == null) return NotFound();
		return Ok(_data);
	}


	[HttpPost]
	public async Task<ActionResult<CartItem>> Create([FromBody] CartItem obj)
	{
		if (obj == null) return BadRequest("Cart Item is null");

		await _unitOfWork.CartItem.AddAsync(obj);
		await _unitOfWork.SaveAsync();
		return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
	}

	// PUT api/<CartItemController>/5
	[HttpPut("{id}")]
	public async Task<ActionResult<CartItem>> Update(Guid id, [FromBody] CartItem obj)
	{
		if (id != obj.Id || obj == null) return BadRequest();
		_unitOfWork.CartItem.Update(obj);
		await _unitOfWork.SaveAsync();
		return Ok();
	}


	//[HttpDelete("{id}")]
	//public async Task<ActionResult<CartItem>> Delete(Guid id)
	//{
	//	var _data = await _unitOfWork.CartItem.GetAsync(c => c.Id == id);
	//	if (_data == null) return NotFound();

	//	_unitOfWork.CartItem.RemoveAsync(_data);
	//	await _unitOfWork.SaveAsync();
	//	return Ok();
	//}

	//[HttpDelete("range")]
	//public async Task<ActionResult<CartItem>> DeleteRange(IEnumerable<int> ids)
	//{
	//	var _items = new List<CartItem>();

	//	foreach (int id in ids)
	//	{
	//		var _item = await _unitOfWork.CartItem.GetAsync(c => c.Id == id);
	//		if (_item != null) _items.Add(_item);
	//	}
	//	if (_items.Count == 0) return NotFound();

	//	_unitOfWork.CartItem.RemoveRangeAsync(_items);
	//	await _unitOfWork.SaveAsync();
	//	return Ok(_items);
	//}
}
