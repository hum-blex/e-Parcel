﻿using AutoMapper;
using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs.OrderItems;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_Parcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderItemController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var _data = _unitOfWork.OrderItem.GetAllAsync();
            if(!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(_mapper.Map<List<OrderItemDto>>(_data));
        }

        
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var _data = _unitOfWork.OrderItem.GetAsync(c => c.Id == id);
            if (_data == null) return NotFound();

            return Ok(_mapper.Map<OrderItemDto>(_data));
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] OrderItemAddDto obj)
        {
            if(obj == null) return BadRequest("Order Item is null");

            var OrderItemDomain = _mapper.Map<OrderItem>(obj);
            OrderItemDomain.CreatedOn = DateTime.Now;

            await _unitOfWork.OrderItem.AddAsync(OrderItemDomain);
            await _unitOfWork.SaveAsync();

            var OrderItemDTO = _mapper.Map<OrderItemDto>(OrderItemDomain);

            return CreatedAtAction(nameof(Get), new { id = OrderItemDTO.Id }, OrderItemDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] OrderItemUpdateDto obj)
        {
            if (id != obj.Id || obj == null) return BadRequest();
            var OrderItemDomain = _mapper.Map<OrderItem>(obj);

            OrderItemDomain = await _unitOfWork.OrderItem.UpdateAsync(id, OrderItemDomain);
            if(OrderItemDomain == null) return NotFound();

            await _unitOfWork.SaveAsync();
            
            return Ok(_mapper.Map<OrderItemDto>(OrderItemDomain));
        }

        
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var _data = _unitOfWork.OrderItem.GetAsync(c => c.Id == id);
        //    if(_data == null) return NotFound();

        //    _unitOfWork.OrderItem.Remove(_data);
        //    _unitOfWork.Save();
        //    return Ok();
        //}

        //[HttpDelete("range")]
        //public IActionResult DeleteRange(IEnumerable<int> ids)
        //{
        //    var _items = new List<OrderItem>();

        //    foreach(int id in ids)
        //    {
        //        var _item = _unitOfWork.OrderItem.Get(c => c.Id == id);
        //        if(_item != null) _items.Add(_item);
        //    }
        //    if(_items.Count == 0) return NotFound();

        //    _unitOfWork.OrderItem.RemoveRange(_items);
        //    _unitOfWork.Save();
        //    return Ok(_items);
        //}
    }
}
