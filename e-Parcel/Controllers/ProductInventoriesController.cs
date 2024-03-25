using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_Parcel.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ProductInventoriesController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductInventoriesController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: ProductInventories
		[HttpGet]
		public IActionResult GetProductInventory()
		{
			var _data = _unitOfWork.ProductInventory.GetAll();
			if (!ModelState.IsValid) return BadRequest(ModelState);
			return Ok(_data);
		}

		// GET: ProductInventories/5
		[HttpGet("{id}")]
		public IActionResult GetProductInventory(int id)
		{
			var _data = _unitOfWork.ProductInventory.Get(u => u.Id == id);
			if (_data == null) return NotFound();
			return Ok(_data);
		}

		// PUT: ProductInventories/5
		[HttpPut("{id}")]
		public IActionResult Update(int id, ProductInventory inventory)
		{
			if (id != inventory.Id || inventory == null) return BadRequest();
			var _data = _unitOfWork.ProductInventory.Get(u => u.Id == id);
			if (_data == null) return NotFound();

			_unitOfWork.ProductInventory.Update(_data);
			_unitOfWork.Save();
			return NoContent();
		}

		// POST: ProductInventories
		[HttpPost]
		public IActionResult Create(ProductInventory inventory)
		{
			if (inventory == null) return BadRequest("Inventory is Null");
			_unitOfWork.ProductInventory.Add(inventory);
			_unitOfWork.Save();

			return CreatedAtAction(nameof(GetProductInventory), new { id = inventory.Id }, inventory);
		}

		// DELETE: ProductInventories/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var _data = _unitOfWork.ProductInventory.Get(u => u.Id == id);
			if (_data == null) return NotFound();

			_unitOfWork.ProductInventory.Remove(_data);
			_unitOfWork.Save();
			return Ok(_data);
		}

		[HttpDelete("range")]
		public IActionResult DeleteRange([FromBody] IEnumerable<int> ids)
		{
			var productInventories = new List<ProductInventory>();

			foreach (var id in ids)
			{
				var productInventory = _unitOfWork.ProductInventory.Get(u => u.Id == id);
				if (productInventory != null) productInventories.Add(productInventory);
			}
			if (productInventories.Count == 0) return NotFound();

			_unitOfWork.ProductInventory.RemoveRange(productInventories);
			_unitOfWork.Save();

			return Ok(productInventories);
		}
	}
}
