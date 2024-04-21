using AutoMapper;
using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs.Discounts;
using Microsoft.AspNetCore.Mvc;


namespace e_Parcel.Controllers;

[Route("[controller]")]
[ApiController]
public class DiscountsController : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public DiscountsController(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetDiscounts()
	{
		var _data = await _unitOfWork.Discount.GetAllAsync();
		var notDeletedData = _data.Where(x => x.IsDeleted == false).ToList();

		if (!ModelState.IsValid) return BadRequest(ModelState);

		return Ok(_mapper.Map<List<DiscountDto>>(notDeletedData));
	}


	[HttpGet]
	[Route("{id:guid}")]
	public async Task<IActionResult> GetDiscountByID([FromRoute] Guid id)
	{
		var _data = await _unitOfWork.Discount.GetAsync(c => c.Id == id);

		if (_data == null) return NotFound();

		return Ok(_mapper.Map<DiscountDto>(_data));
	}

	[HttpPost]
	public async Task<IActionResult> Create(DiscountAddDto obj)
	{
		if (obj == null) return BadRequest("Category is Null");

		var DiscountDomain = _mapper.Map<Discount>(obj);
		DiscountDomain.CreatedOn = DateTime.Now;

		await _unitOfWork.Discount.AddAsync(DiscountDomain);
		await _unitOfWork.SaveAsync();

		var DiscountDTO = _mapper.Map<DiscountDto>(DiscountDomain);

		return CreatedAtAction(nameof(GetDiscountByID), new { id = DiscountDTO.Id }, DiscountDTO);
	}

	//[HttpDelete("{id}")]
	//public async Task<ActionResult<Discount>> Delete(int id)
	//{
	//	var _data = await _unitOfWork.Discount.GetAsync(c => c.Id == id);
	//	if (_data == null) return NotFound();

	//	_unitOfWork.Discount.RemoveAsync(_data);
	//	await _unitOfWork.SaveAsync();
	//	return NoContent();
	//}


	[HttpPut]
	[Route("{id:guid}")]
	public async Task<IActionResult> UpdateDiscount([FromRoute] Guid id, [FromBody] DiscountUpdateDto obj)
	{
		if (id != obj.Id || obj == null) return BadRequest();

		var discountDomain = _mapper.Map<Discount>(obj);

		discountDomain = await _unitOfWork.Discount.UpdateAsync(id, discountDomain);
		if (discountDomain == null) return NotFound();

		await _unitOfWork.SaveAsync();
		return Ok(_mapper.Map<DiscountDto>(discountDomain));
	}

	//[HttpDelete("range")]
	//public async Task<ActionResult<Discount>> DeleteRange(IEnumerable<Guid> ids)
	//{
	//	var discounts = new List<Discount>();
	//	foreach (int id in ids)
	//	{
	//		var discount = await _unitOfWork.Discount.GetAsync(c => c.Id == id);
	//		if (discount != null) discounts.Add(discount);
	//	}
	//	if (discounts.Count == 0) return NotFound();
	//	_unitOfWork.Discount.RemoveRangeAsync(discounts);
	//	await _unitOfWork.SaveAsync();
	//	return Ok(discounts);
	//}
}
