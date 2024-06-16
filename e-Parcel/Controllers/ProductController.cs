using AutoMapper;
using e_Parcel.DataAccess.Repository.IRepository;
using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs.Products;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_Parcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await _unitOfWork.Product.GetAllAsync();
            if(!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(_mapper.Map<List<ProductDto>>(_data));
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var _data = await _unitOfWork.Product.GetAsync(c => c.Id == id);
            if (_data == null) return NotFound();

            return Ok(_mapper.Map<ProductDto>(_data));
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductAddDto obj)
        {
            if(obj == null) return BadRequest("Product is null");

            var ProductDomain = _mapper.Map<Product>(obj);
            ProductDomain.CreatedOn = DateTime.Now;

            await _unitOfWork.Product.AddAsync(ProductDomain);
            await _unitOfWork.SaveAsync();

            var ProductDTO = _mapper.Map<ProductDto>(ProductDomain);

            return CreatedAtAction(nameof(GetByID), new { id = ProductDTO.Id }, ProductDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ProductUpdateDto obj)
        {
            if (id != obj.Id || obj == null) return BadRequest();

            var ProductDomain = _mapper.Map<Product>(obj);

            ProductDomain = await _unitOfWork.Product.UpdateAsync(id, ProductDomain);
            if(ProductDomain == null) return NotFound();

            await _unitOfWork.SaveAsync();


            return Ok(_mapper.Map<ProductDto>(ProductDomain));
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
