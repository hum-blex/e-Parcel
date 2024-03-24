using e_Parcel.DataAccess.Repository;
using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace e_Parcel.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        private DiscountsController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        [HttpGet]
        public IActionResult GetDiscounts()
        {
            var _data = _unitOfWork.Discount.GetAll();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_data);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetDiscounts(int id)
        {
            if (id != obj.Id || obj == null) return BadRequest();

            var _data = _unitOfWork.Discount.Get(c => c.Id == id);
            if (_data == null) return NotFound();

            return Ok(_data);
        }

        
        [HttpPatch("{id}")]
        public IActionResult Delete(int id, Discount obj)
        {
            if (id != obj.Id || obj == null) return BadRequest();

            var _data = _unitOfWork.Discount.Get(c => c.Id == id);
            if (_data == null) return NotFound();

            _unitOfWork.Discount.UpdateDelete(id);
            _unitOfWork.Save();
            return NoContent();
        }

        
        [HttpPut("{id}")]
        public IActionResult UdpateDiscounts(int id,[FromBody] Discount obj)
        {
            if (id != obj.Id || obj == null) return BadRequest();

            var _data = _unitOfWork.Discount.Get(c => c.Id == id);
            if (_data == null) return NotFound();

            _unitOfWork.Discount.Update(id, _data);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("range")]
        public IActionResult DeleteRange(IEnumerable<int> ids)
        {
            //var discount = new List<Discount>();
            foreach(int id in ids)
            {
                var discount = _unitOfWork.Discount.Get(c => c.Id == id);
                if(discount == null) return NotFound();
                _unitOfWork.Discount.UpdateDelete(id);
                _unitOfWork.Save();
            }
            return Ok();
        }
    }
}
