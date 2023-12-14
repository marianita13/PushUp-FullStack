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
    public class CategoryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get11()
        {
            var Categorys = await _unitOfWork.Categorys.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(Categorys);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var Category = await _unitOfWork.Categorys.GetByIdAsync(id);
            if (Category == null)
                return NotFound(new ApiResponse(404, $"El Category solicitado no existe."));

            return _mapper.Map<CategoryDto>(Category);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Category>> Post(CategoryDto CategoryDto)
        {
            var Category = _mapper.Map<Category>(CategoryDto);
            _unitOfWork.Categorys.Add(Category);
            await _unitOfWork.SaveAsync();
            if (Category == null)
                return BadRequest(new ApiResponse(400));

            CategoryDto.Id = Category.Id;
            return CreatedAtAction(nameof(Post), new { id = CategoryDto.Id }, CategoryDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDto>> Put(int id, [FromBody] CategoryDto CategoryDto)
        {
            if (CategoryDto == null)
                return NotFound(new ApiResponse(404, $"El Category solicitado no existe."));

            var CategoryBd = await _unitOfWork.Categorys.GetByIdAsync(id);
            if (CategoryBd == null)
                return NotFound(new ApiResponse(404, $"El Category solicitado no existe."));

            var Category = _mapper.Map<Category>(CategoryDto);
            _unitOfWork.Categorys.Update(Category);
            await _unitOfWork.SaveAsync();
            return CategoryDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Category = await _unitOfWork.Categorys.GetByIdAsync(id);
            if (Category == null)
                return NotFound(new ApiResponse(404, $"El Category solicitado no existe."));

            _unitOfWork.Categorys.Remove(Category);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}