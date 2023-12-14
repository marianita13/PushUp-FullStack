using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "Employee")]
    public class ProductController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get11()
        {
            var Products = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(Products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var Product = await _unitOfWork.Products.GetByIdAsync(id);
            if (Product == null)
                return NotFound(new ApiResponse(404, $"El Product solicitado no existe."));

            return _mapper.Map<ProductDto>(Product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> Post(ProductDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);
            _unitOfWork.Products.Add(Product);
            await _unitOfWork.SaveAsync();
            if (Product == null)
                return BadRequest(new ApiResponse(400));

            ProductDto.Id = Product.Id;
            return CreatedAtAction(nameof(Post), new { id = ProductDto.Id }, ProductDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> Put(int id, [FromBody] ProductDto ProductDto)
        {
            if (ProductDto == null)
                return NotFound(new ApiResponse(404, $"El Product solicitado no existe."));

            var ProductBd = await _unitOfWork.Products.GetByIdAsync(id);
            if (ProductBd == null)
                return NotFound(new ApiResponse(404, $"El Product solicitado no existe."));

            var Product = _mapper.Map<Product>(ProductDto);
            _unitOfWork.Products.Update(Product);
            await _unitOfWork.SaveAsync();
            return ProductDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Product = await _unitOfWork.Products.GetByIdAsync(id);
            if (Product == null)
                return NotFound(new ApiResponse(404, $"El Product solicitado no existe."));

            _unitOfWork.Products.Remove(Product);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}