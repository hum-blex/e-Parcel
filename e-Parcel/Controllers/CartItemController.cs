using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_Parcel.Controllers
{
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
		public IActionResult GetAll()
		{
			var _data = _unitOfWork.CartItem.GetAll();
			if (!ModelState.IsValid) return BadRequest(ModelState);
			return Ok(_data);
		}


		[HttpGet("{id}")]
		public IActionResult Get(int id, CartItem obj)
		{
			var _data = _unitOfWork.CartItem.Get(c => c.Id == id);
			if (_data == null) return NotFound();
			return Ok(_data);
		}


		[HttpPost]
		public IActionResult Create([FromBody] CartItem obj)
		{
			if (obj == null) return BadRequest("Cart Item is null");

			_unitOfWork.CartItem.Add(obj);
			_unitOfWork.Save();
			return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
		}

		// PUT api/<CartItemController>/5
		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] CartItem obj)
		{
			if (id != obj.Id || obj == null) return BadRequest();
			_unitOfWork.CartItem.Update(obj);
			_unitOfWork.Save();
			return Ok();
		}


		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var _data = _unitOfWork.CartItem.Get(c => c.Id == id);
			if (_data == null) return NotFound();

			_unitOfWork.CartItem.Remove(_data);
			_unitOfWork.Save();
			return Ok();
		}

		[HttpDelete("range")]
		public IActionResult DeleteRange(IEnumerable<int> ids)
		{
			var _items = new List<CartItem>();

			foreach (int id in ids)
			{
				var _item = _unitOfWork.CartItem.Get(c => c.Id == id);
				if (_item != null) _items.Add(_item);
			}
			if (_items.Count == 0) return NotFound();

			_unitOfWork.CartItem.RemoveRange(_items);
			_unitOfWork.Save();
			return Ok(_items);
		}
	}
}
