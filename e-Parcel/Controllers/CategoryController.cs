
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
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<Category> GetAll()
		{
			var _data = _unitOfWork.Category.GetAll();


			if (!ModelState.IsValid) return BadRequest(ModelState);
			return Ok(_data);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<Category> Get(int id)
		{
			var _data = _unitOfWork.Category.Get(u => u.Id == id);
			return Ok(_data);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<Category> Create([FromBody] Category obj)
		{
			if (obj == null) return BadRequest("Category is Null");
			_unitOfWork.Category.Add(obj);
			_unitOfWork.Save();
			return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<Category> Update(int id, [FromBody] Category obj)
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
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		//[ProducesResponseType()]
		public ActionResult<Category> Delete(int id)
		{
			var _data = _unitOfWork.Category.Get(u => u.Id == id);
			if (_data == null) return NotFound();

			_unitOfWork.Category.Remove(_data);
			_unitOfWork.Save();
			return Ok(_data);
		}


		[HttpDelete("range")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<Category> DeleteRange([FromBody] IEnumerable<int> ids)
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
