using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_Parcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var _data = _unitOfWork.OrderItem.GetAll();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_data);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id, OrderItem obj)
        {
            var _data = _unitOfWork.OrderItem.Get(c => c.Id == id);
            if (_data == null) return NotFound();
            return Ok(_data);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] OrderItem obj)
        {
            if(obj == null) return BadRequest("Cart Item is null");

            _unitOfWork.OrderItem.Add(obj);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderItem obj)
        {
            if (id != obj.Id || obj == null) return BadRequest();

            _unitOfWork.OrderItem.Update(obj);
            _unitOfWork.Save();
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _data = _unitOfWork.OrderItem.Get(c => c.Id == id);
            if(_data == null) return NotFound();

            _unitOfWork.OrderItem.Remove(_data);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("range")]
        public IActionResult DeleteRange(IEnumerable<int> ids)
        {
            var _items = new List<OrderItem>();

            foreach(int id in ids)
            {
                var _item = _unitOfWork.OrderItem.Get(c => c.Id == id);
                if(_item != null) _items.Add(_item);
            }
            if(_items.Count == 0) return NotFound();

            _unitOfWork.OrderItem.RemoveRange(_items);
            _unitOfWork.Save();
            return Ok(_items);
        }
    }
}
