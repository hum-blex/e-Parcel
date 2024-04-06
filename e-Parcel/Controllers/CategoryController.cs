
using AutoMapper;
using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace e_Parcel.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]

	public async Task<ActionResult<Category>> GetAll()
	{
		var _data = await _unitOfWork.Category.GetAllAsync();


		if (!ModelState.IsValid) return BadRequest(ModelState);
		return Ok(_mapper.Map<List<CategoryDto>>(_data));
	}

	[HttpGet("{id}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public async Task<ActionResult<Category>> Get(int id)
	{
		var _data = await _unitOfWork.Category.GetAsync(u => u.Id == id);
		if (_data == null) return NotFound();

		return Ok(_mapper.Map<CategoryDto>(_data));
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]

	public async Task<ActionResult<Category>> Create([FromBody] CategoryAddDto obj)
	{
		if (obj == null) return BadRequest("Category is Null");
		// Map DTO to Domain Model
		var _data = _mapper.Map<Category>(obj);
		_data.CreatedOn = DateTime.UtcNow;
		await _unitOfWork.Category.AddAsync(_data);
		await _unitOfWork.SaveAsync();
		return CreatedAtAction(nameof(Get), new { id = _data.Id }, _data);
	}

	[HttpPut("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]

	public async Task<ActionResult<Category>> Update(int id, [FromBody] CategoryUpdateDto obj)
	{
		if (obj.Id != id || obj == null) return BadRequest();
		Category _data = _mapper.Map<Category>(obj);
		await _unitOfWork.Category.UpdateAsync(id, _data);
		await _unitOfWork.SaveAsync();
		return Ok();
	}

	//[HttpPut("{id}")]
	//public IActionResult UpdateDelete(int id, [FromBody] Category obj)
	//{
	//	if (id != obj.Id || obj == null) return BadRequest();

	//	_unitOfWork.Category.UpdateDelete(obj);
	//	_unitOfWork.Save();
	//	return NoContent();
	//}

	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]

	//[ProducesResponseType()]
	public async Task<ActionResult<Category>> Delete(int id)
	{
		var _data = await _unitOfWork.Category.GetAsync(u => u.Id == id);
		if (_data == null) return NotFound();

		_unitOfWork.Category.RemoveAsync(_data);
		await _unitOfWork.SaveAsync();
		return Ok(_data);
	}


	[HttpDelete("range")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public async Task<ActionResult<Category>> DeleteRange([FromBody] IEnumerable<int> ids)
	{
		var categories = new List<Category>();

		foreach (var id in ids)
		{
			var category = await _unitOfWork.Category.GetAsync(u => u.Id == id);
			if (category == null) return NotFound();
			//_unitOfWork.Category.UpdateDelete(id);
			//_unitOfWork.Save();
			if (category != null) categories.Add(category);
		}
		if (categories.Count == 0) return NotFound();

		_unitOfWork.Category.RemoveRangeAsync(categories);
		await _unitOfWork.SaveAsync();

		return Ok();
	}
}
