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
    public class SaleController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SaleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SaleDto>>> Get11()
        {
            var Sales = await _unitOfWork.Sales.GetAllAsync();
            return _mapper.Map<List<SaleDto>>(Sales);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SaleDto>> Get(int id)
        {
            var Sale = await _unitOfWork.Sales.GetByIdAsync(id);
            if (Sale == null)
                return NotFound(new ApiResponse(404, $"El Sale solicitado no existe."));

            return _mapper.Map<SaleDto>(Sale);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Sale>> Post(SaleDto SaleDto)
        {
            var Sale = _mapper.Map<Sale>(SaleDto);
            _unitOfWork.Sales.Add(Sale);
            await _unitOfWork.SaveAsync();
            if (Sale == null)
                return BadRequest(new ApiResponse(400));

            SaleDto.Id = Sale.Id;
            return CreatedAtAction(nameof(Post), new { id = SaleDto.Id }, SaleDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SaleDto>> Put(int id, [FromBody] SaleDto SaleDto)
        {
            if (SaleDto == null)
                return NotFound(new ApiResponse(404, $"El Sale solicitado no existe."));

            var SaleBd = await _unitOfWork.Sales.GetByIdAsync(id);
            if (SaleBd == null)
                return NotFound(new ApiResponse(404, $"El Sale solicitado no existe."));

            var Sale = _mapper.Map<Sale>(SaleDto);
            _unitOfWork.Sales.Update(Sale);
            await _unitOfWork.SaveAsync();
            return SaleDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Sale = await _unitOfWork.Sales.GetByIdAsync(id);
            if (Sale == null)
                return NotFound(new ApiResponse(404, $"El Sale solicitado no existe."));

            _unitOfWork.Sales.Remove(Sale);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}