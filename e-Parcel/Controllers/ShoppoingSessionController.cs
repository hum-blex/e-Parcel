using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_Parcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppoingSessionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppoingSessionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var _data = _unitOfWork.ShoppingSession.GetAllAsync();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_data);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(Guid id, ShoppingSession obj)
        {
            var _data = _unitOfWork.ShoppingSession.GetAsync(c => c.Id == id);
            if (_data == null) return NotFound();
            return Ok(_data);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] ShoppingSession obj)
        {
            if(obj == null) return BadRequest("Shopping Session is null");

            _unitOfWork.ShoppingSession.AddAsync(obj);
            _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] ShoppingSession obj)
        {
            if (id != obj.Id || obj == null) return BadRequest();

            _unitOfWork.ShoppingSession.Update(obj);
            _unitOfWork.SaveAsync();
            return Ok();
        }

        
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var _data = _unitOfWork.ShoppingSession.Get(c => c.Id == id);
        //    if(_data == null) return NotFound();

        //    _unitOfWork.ShoppingSession.Remove(_data);
        //    _unitOfWork.Save();
        //    return Ok();
        //}

        //[HttpDelete("range")]
        //public IActionResult DeleteRange(IEnumerable<int> ids)
        //{
        //    var _items = new List<ShoppingSession>();

        //    foreach(int id in ids)
        //    {
        //        var _item = _unitOfWork.ShoppingSession.Get(c => c.Id == id);
        //        if(_item != null) _items.Add(_item);
        //    }
        //    if(_items.Count == 0) return NotFound();

        //    _unitOfWork.ShoppingSession.RemoveRange(_items);
        //    _unitOfWork.Save();
        //    return Ok(_items);
        //}
    }
}
