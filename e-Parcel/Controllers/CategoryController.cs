﻿
using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_Parcel.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		public CategoryController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var _data = _unitOfWork.Category.GetAll();
			if (!ModelState.IsValid) return BadRequest(ModelState);
			return Ok(_data);
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var _data = _unitOfWork.Category.Get(u => u.Id == id);
			return Ok(_data);
		}

		[HttpPost]
		public IActionResult Create([FromBody] Category obj)
		{
			if (obj == null) return BadRequest("Category is Null");
			_unitOfWork.Category.Add(obj);
			_unitOfWork.Save();
			return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] Category obj)
		{
			if (id != obj.Id || obj == null) return BadRequest();

			_unitOfWork.Category.Update(obj);
			_unitOfWork.Save();
			return NoContent();
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
		public IActionResult Delete(int id)
		{
			var _data = _unitOfWork.Category.Get(u => u.Id == id);
			if (_data == null) return NotFound();

			_unitOfWork.Category.Remove(_data);
			_unitOfWork.Save();
			return Ok(_data);
		}


		[HttpDelete("range")]
		public IActionResult DeleteRange([FromBody] IEnumerable<int> ids)
		{
			var categories = new List<Category>();

			foreach (var id in ids)
			{
				var category = _unitOfWork.Category.Get(u => u.Id == id);
				if (category == null) return NotFound();
				//_unitOfWork.Category.UpdateDelete(id);
				//_unitOfWork.Save();
				if (category != null) categories.Add(category);
			}
			if (categories.Count == 0) return NotFound();

			_unitOfWork.Category.RemoveRange(categories);
			_unitOfWork.Save();

			return Ok();
		}
	}
}
