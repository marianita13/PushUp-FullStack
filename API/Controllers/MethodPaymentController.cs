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
    public class MethodPaymentController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MethodPaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MethodPaymentDto>>> Get11()
        {
            var MethodPayments = await _unitOfWork.MethodPayments.GetAllAsync();
            return _mapper.Map<List<MethodPaymentDto>>(MethodPayments);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MethodPaymentDto>> Get(int id)
        {
            var MethodPayment = await _unitOfWork.MethodPayments.GetByIdAsync(id);
            if (MethodPayment == null)
                return NotFound(new ApiResponse(404, $"El MethodPayment solicitado no existe."));

            return _mapper.Map<MethodPaymentDto>(MethodPayment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MethodPayment>> Post(MethodPaymentDto MethodPaymentDto)
        {
            var MethodPayment = _mapper.Map<MethodPayment>(MethodPaymentDto);
            _unitOfWork.MethodPayments.Add(MethodPayment);
            await _unitOfWork.SaveAsync();
            if (MethodPayment == null)
                return BadRequest(new ApiResponse(400));

            MethodPaymentDto.Id = MethodPayment.Id;
            return CreatedAtAction(nameof(Post), new { id = MethodPaymentDto.Id }, MethodPaymentDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MethodPaymentDto>> Put(int id, [FromBody] MethodPaymentDto MethodPaymentDto)
        {
            if (MethodPaymentDto == null)
                return NotFound(new ApiResponse(404, $"El MethodPayment solicitado no existe."));

            var MethodPaymentBd = await _unitOfWork.MethodPayments.GetByIdAsync(id);
            if (MethodPaymentBd == null)
                return NotFound(new ApiResponse(404, $"El MethodPayment solicitado no existe."));

            var MethodPayment = _mapper.Map<MethodPayment>(MethodPaymentDto);
            _unitOfWork.MethodPayments.Update(MethodPayment);
            await _unitOfWork.SaveAsync();
            return MethodPaymentDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var MethodPayment = await _unitOfWork.MethodPayments.GetByIdAsync(id);
            if (MethodPayment == null)
                return NotFound(new ApiResponse(404, $"El MethodPayment solicitado no existe."));

            _unitOfWork.MethodPayments.Remove(MethodPayment);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}