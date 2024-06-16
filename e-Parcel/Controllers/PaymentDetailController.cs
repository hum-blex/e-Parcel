using AutoMapper;
using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs.PaymentDetails;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_Parcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentDetailController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await _unitOfWork.PaymentDetail.GetAllAsync();

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_mapper.Map<List<PaymentDetailDto>>(_data));
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var _data = await _unitOfWork.PaymentDetail.GetAsync(c => c.Id == id);
            if (_data == null) return NotFound();

            return Ok(_mapper.Map<PaymentDetailDto>(_data));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaymentDetailAddDto obj)
        {
            if (obj == null) return BadRequest("Payment Detail is null");

            var PaymentDetailDomain = _mapper.Map<PaymentDetail>(obj);
            PaymentDetailDomain.CreatedOn = DateTime.Now;

            await _unitOfWork.PaymentDetail.AddAsync(PaymentDetailDomain);
            await _unitOfWork.SaveAsync();

            var PaymentDetailsDTO = _mapper.Map<PaymentDetailDto>(obj);

            return CreatedAtAction(nameof(GetByID), new { id = PaymentDetailsDTO.Id }, PaymentDetailsDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PaymentDetailUpdateDto obj)
        {
            if (id != obj.Id || obj == null) return BadRequest();

            var PaymentDetailDomain = _mapper.Map<PaymentDetail>(obj);

            PaymentDetailDomain = await _unitOfWork.PaymentDetail.UpdateAsync(id, PaymentDetailDomain);
            if(PaymentDetailDomain == null) return NotFound();

            await _unitOfWork.SaveAsync();

            return Ok(_mapper.Map<PaymentDetailDto>(PaymentDetailDomain));
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
