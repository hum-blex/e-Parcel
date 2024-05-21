using AutoMapper;
using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs.CartItems;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_Parcel.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartItemController : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CartItemController(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
        _mapper = mapper;
    }

	[HttpGet]
	public async Task<IActionResult>  GetAll()
	{
		var _data = await _unitOfWork.CartItem.GetAllAsync();
		if (!ModelState.IsValid) return BadRequest(ModelState);
		return Ok(_mapper.Map<List<CartItemDto>>(_data));
	}


	[HttpGet]
	[Route("{id:guid}")]
	public async Task<IActionResult> GetByID([FromRoute] Guid id)
	{
		var _data = await _unitOfWork.CartItem.GetAsync(c => c.Id == id);
		if (_data == null) return NotFound();
		return Ok(_mapper.Map<CartItemDto>(_data));
	}


	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CartItemAddDto obj)
	{
		if (obj == null) return BadRequest("Cart Item is null");

		var CartItemDomain = _mapper.Map<CartItem>(obj);
		CartItemDomain.CreatedOn = DateTime.Now;

		await _unitOfWork.CartItem.AddAsync(CartItemDomain);
		await _unitOfWork.SaveAsync();

		var CartItemDTO = _mapper.Map<CartItemDto>(CartItemDomain);

		return CreatedAtAction(nameof(GetByID), new { id = CartItemDTO.Id }, CartItemDTO);
	}

	// PUT api/<CartItemController>/5
	[HttpPut]
	[Route("{id:guid}")]
	public async Task<IActionResult> UpdateCartItem([FromRoute] Guid id, [FromBody] CartItemUpdateDto obj)
	{
		if (id != obj.Id || obj == null) return BadRequest();

		var CartItemDomain = _mapper.Map<CartItem>(obj);

		CartItemDomain = await _unitOfWork.CartItem.UpdateAsync(id, CartItemDomain);
		if(CartItemDomain == null) return NotFound();

		await _unitOfWork.SaveAsync();
		return Ok(_mapper.Map<CartItemDto>(CartItemDomain));
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
