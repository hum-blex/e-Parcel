using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_Parcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymentDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var _data = _unitOfWork.PaymentDetail.GetAllAsync();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_data);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(Guid id, PaymentDetail obj)
        {
            var _data = _unitOfWork.PaymentDetail.GetAsync(c => c.Id == id);
            if (_data == null) return NotFound();
            return Ok(_data);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] PaymentDetail obj)
        {
            if(obj == null) return BadRequest("Payment Detail is null");

            _unitOfWork.PaymentDetail.AddAsync(obj);
            _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] PaymentDetail obj)
        {
            if (id != obj.Id || obj == null) return BadRequest();

            _unitOfWork.PaymentDetail.Update(obj);
            _unitOfWork.SaveAsync();
            return Ok();
        }

        
        //[HttpDelete("{id}")]
        //public IActionResult Delete(Guid id)
        //{
        //    var _data = _unitOfWork.PaymentDetail.GetAsync(c => c.Id == id);
        //    if(_data == null) return NotFound();

        //    //_unitOfWork.PaymentDetail.RemoveAsync(_data);
        //    _unitOfWork.SaveAsync();
        //    return Ok();
        //}

        //[HttpDelete("range")]
        //public IActionResult DeleteRange(IEnumerable<int> ids)
        //{
        //    var _items = new List<PaymentDetail>();

        //    foreach(int id in ids)
        //    {
        //        var _item = _unitOfWork.PaymentDetail.GetAsync(c => c.Id == id);
        //        if(_item != null) _items.Add(_item);
        //    }
        //    if(_items.Count == 0) return NotFound();

        //    _unitOfWork.PaymentDetail.RemoveRange(_items);
        //    _unitOfWork.Save();
        //    return Ok(_items);
        //}
    }
}
