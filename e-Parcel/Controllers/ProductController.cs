using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_Parcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var _data = _unitOfWork.Product.GetAllAsync();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_data);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(Guid id, Product obj)
        {
            var _data = _unitOfWork.Product.GetAsync(c => c.Id == id);
            if (_data == null) return NotFound();
            return Ok(_data);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] Product obj)
        {
            if(obj == null) return BadRequest("Product is null");

            _unitOfWork.Product.AddAsync(obj);
            _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Product obj)
        {
            if (id != obj.Id || obj == null) return BadRequest();

            _unitOfWork.Product.Update(obj);
            _unitOfWork.SaveAsync();
            return Ok();
        }

        
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var _data = _unitOfWork.Product.GetAsync(c => c.Id == id);
        //    if(_data == null) return NotFound();

        //    _unitOfWork.Product.Remove(_data);
        //    _unitOfWork.Save();
        //    return Ok();
        //}

        //[HttpDelete("range")]
        //public IActionResult DeleteRange(IEnumerable<int> ids)
        //{
        //    var _items = new List<Product>();

        //    foreach(int id in ids)
        //    {
        //        var _item = _unitOfWork.Product.Get(c => c.Id == id);
        //        if(_item != null) _items.Add(_item);
        //    }
        //    if(_items.Count == 0) return NotFound();

        //    _unitOfWork.Product.RemoveRange(_items);
        //    _unitOfWork.Save();
        //    return Ok(_items);
        //}
    }
}
