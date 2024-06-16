using AutoMapper;
using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs;
using e_Parcel.Models.DTOs.ProductInventories;
using Microsoft.AspNetCore.Mvc;

namespace e_Parcel.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductInventoriesController : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public ProductInventoriesController(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	// GET: ProductInventories
	[HttpGet]
	public async Task<ActionResult<ProductInventory>> GetProductInventory()
	{
		var _data = await _unitOfWork.ProductInventory.GetAllAsync();
		if (!ModelState.IsValid) return BadRequest(ModelState);

		return Ok(_mapper.Map<List<ProductInventoryDto>>(_data));
	}

	// GET: ProductInventories/5
	[HttpGet]
	[Route("{id:guid}")]
	public async Task<ActionResult<ProductInventory>> GetProductInventoryByID([FromRoute] Guid id)
	{
		var _data = await _unitOfWork.ProductInventory.GetAsync(u => u.Id == id);
		if (_data == null) return NotFound();
		return Ok(_mapper.Map<ProductInventoryDto>(_data));
	}

	// PUT: ProductInventories/5
	[HttpPut]
    [Route("{id:guid}")]
    public async Task<ActionResult<ProductInventory>> Update([FromRoute] Guid id, ProductInventoryUpdateDto inventory)
	{
		if (id != inventory.Id || inventory == null) return BadRequest();

		ProductInventory _data = _mapper.Map<ProductInventory>(inventory);
		await _unitOfWork.ProductInventory.UpdateAsync(id, _data);
		await _unitOfWork.SaveAsync();

		return Ok(_mapper.Map<ProductInventoryDto>(_data));
	}

	// POST: ProductInventories
	[HttpPost]
	public async Task<ActionResult<ProductInventory>> Create(ProductInventoryAddDto inventory)
	{
		if (inventory == null) return BadRequest("Inventory is Null");
		var _data = _mapper.Map<ProductInventory>(inventory);
		_data.CreatedOn = DateTime.UtcNow;

		await _unitOfWork.ProductInventory.AddAsync(_data);
		await _unitOfWork.SaveAsync();

		var ProductInventoryDTO = _mapper.Map<ProductInventoryDto>(_data);
		
		return CreatedAtAction(nameof(GetProductInventoryByID), new { id = ProductInventoryDTO.Id }, ProductInventoryDTO);
	}

	// DELETE: ProductInventories/5
	//[HttpDelete("{id}")]
	//public async Task<ActionResult<ProductInventory>> Delete(int id)
	//{
	//	var _data = await _unitOfWork.ProductInventory.GetAsync(u => u.Id == id);
	//	if (_data == null) return NotFound();

	//	_unitOfWork.ProductInventory.RemoveAsync(_data);
	//	await _unitOfWork.SaveAsync();
	//	return Ok(_data);
	//}

	//[HttpDelete("range")]
	//public async Task<ActionResult<ProductInventory>> DeleteRange([FromBody] IEnumerable<int> ids)
	//{
	//	var productInventories = new List<ProductInventory>();

	//	foreach (var id in ids)
	//	{
	//		var productInventory = await _unitOfWork.ProductInventory.GetAsync(u => u.Id == id);
	//		if (productInventory != null) productInventories.Add(productInventory);
	//	}
	//	if (productInventories.Count == 0) return NotFound();

	//	_unitOfWork.ProductInventory.RemoveRangeAsync(productInventories);
	//	await _unitOfWork.SaveAsync();

	//	return Ok(productInventories);
	//}
}
