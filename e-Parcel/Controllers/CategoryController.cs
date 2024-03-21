using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_Parcel.Controllers
{
	[Route("api/[controller]")]
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
			var existingCategory = _unitOfWork.Category.Get(u => u.Id == id);
			if (existingCategory == null) return NotFound();

			existingCategory.Name = obj.Name;
			existingCategory.DisplayOrder = obj.DisplayOrder;
			existingCategory.Description = obj.Description;

			_unitOfWork.Category.Update(existingCategory);
			_unitOfWork.Save();
			return NoContent();
		}

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
				if (category != null) categories.Add(category);
			}
			if (categories.Count == 0) return NotFound();

			_unitOfWork.Category.RemoveRange(categories);
			_unitOfWork.Save();

			return Ok(categories);
		}
	}
}
