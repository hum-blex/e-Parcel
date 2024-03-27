using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_Parcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var _data = _unitOfWork.OrderDetail.GetAll();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_data);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id, OrderDetail obj)
        {
            var _data = _unitOfWork.OrderDetail.Get(c => c.Id == id);
            if (_data == null) return NotFound();
            return Ok(_data);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] OrderDetail obj)
        {
            if(obj == null) return BadRequest("Order Detail is null");

            _unitOfWork.OrderDetail.Add(obj);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderDetail obj)
        {
            if (id != obj.Id || obj == null) return BadRequest();

            _unitOfWork.OrderDetail.Update(obj);
            _unitOfWork.Save();
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _data = _unitOfWork.OrderDetail.Get(c => c.Id == id);
            if(_data == null) return NotFound();

            _unitOfWork.OrderDetail.Remove(_data);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("range")]
        public IActionResult DeleteRange(IEnumerable<int> ids)
        {
            var _items = new List<OrderDetail>();

            foreach(int id in ids)
            {
                var _item = _unitOfWork.OrderDetail.Get(c => c.Id == id);
                if(_item != null) _items.Add(_item);
            }
            if(_items.Count == 0) return NotFound();

            _unitOfWork.OrderDetail.RemoveRange(_items);
            _unitOfWork.Save();
            return Ok(_items);
        }
    }
}
