using AutoMapper;
using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs.OrderDetails;
using Microsoft.AspNetCore.Mvc;

namespace e_Parcel.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public OrderDetailsController(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var _data = await _unitOfWork.OrderDetail.GetAllAsync();
		if (!ModelState.IsValid) return BadRequest(ModelState);


		return Ok(_mapper.Map<List<OrderDetailDto>>(_data));
	}


	[HttpGet]
	[Route("{id:guid}")]
	public async Task<IActionResult> GetByID([FromRoute] Guid id)
	{
		var _data = await _unitOfWork.OrderDetail.GetAsync(c => c.Id == id);
		if (_data == null) return NotFound();

		return Ok(_mapper.Map<OrderDetailDto>(_data));
	}


	[HttpPost]
	public async Task<IActionResult> Create([FromBody] OrderDetailAddDto obj)
	{
		if (obj == null) return BadRequest("Order Detail is null");

		var OrderDetailDomain = _mapper.Map<OrderDetail>(obj);
		OrderDetailDomain.CreatedOn = DateTime.Now;

		await _unitOfWork.OrderDetail.AddAsync(OrderDetailDomain);
		await _unitOfWork.SaveAsync();

		var OrderDetailDTO = _mapper.Map<OrderDetail>(OrderDetailDomain);

		return CreatedAtAction(nameof(GetByID), new { id = OrderDetailDTO.Id }, OrderDetailDTO);
	}

	[HttpPut]
	[Route("{id:guid}")]
	public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] OrderDetailUpdateDto obj)
	{
		if (id != obj.Id || obj == null) return BadRequest();
		
		var OrderDetailDomain = _mapper.Map<OrderDetail>(obj);

        OrderDetailDomain = await _unitOfWork.OrderDetail.UpdateAsync(id, OrderDetailDomain);
		if (OrderDetailDomain == null) return NotFound();

		await _unitOfWork.SaveAsync();
		return Ok(_mapper.Map<OrderDetailDto>(OrderDetailDomain));
	}


	//[HttpDelete("{id}")]
	//public async Task<ActionResult<OrderDetail>> Delete(int id)
	//{
	//	var _data = await _unitOfWork.OrderDetail.GetAsync(c => c.Id == id);
	//	if (_data == null) return NotFound();

	//	_unitOfWork.OrderDetail.RemoveAsync(_data);
	//	await _unitOfWork.SaveAsync();
	//	return Ok();
	//}

	//[HttpDelete("range")]
	//public async Task<ActionResult<OrderDetail>> DeleteRange(IEnumerable<int> ids)
	//{
	//	var _items = new List<OrderDetail>();

	//	foreach (int id in ids)
	//	{
	//		var _item = await _unitOfWork.OrderDetail.GetAsync(c => c.Id == id);
	//		if (_item != null) _items.Add(_item);
	//	}
	//	if (_items.Count == 0) return NotFound();

	//	_unitOfWork.OrderDetail.RemoveRangeAsync(_items);
	//	await _unitOfWork.SaveAsync();
	//	return Ok(_items);
	//}
}

