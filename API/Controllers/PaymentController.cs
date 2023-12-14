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
    public class PaymentController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> Get11()
        {
            var Payments = await _unitOfWork.Payments.GetAllAsync();
            return _mapper.Map<List<PaymentDto>>(Payments);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentDto>> Get(int id)
        {
            var Payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (Payment == null)
                return NotFound(new ApiResponse(404, $"El Payment solicitado no existe."));

            return _mapper.Map<PaymentDto>(Payment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Payment>> Post(PaymentDto PaymentDto)
        {
            var Payment = _mapper.Map<Payment>(PaymentDto);
            _unitOfWork.Payments.Add(Payment);
            await _unitOfWork.SaveAsync();
            if (Payment == null)
                return BadRequest(new ApiResponse(400));

            PaymentDto.Id = Payment.Id;
            return CreatedAtAction(nameof(Post), new { id = PaymentDto.Id }, PaymentDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaymentDto>> Put(int id, [FromBody] PaymentDto PaymentDto)
        {
            if (PaymentDto == null)
                return NotFound(new ApiResponse(404, $"El Payment solicitado no existe."));

            var PaymentBd = await _unitOfWork.Payments.GetByIdAsync(id);
            if (PaymentBd == null)
                return NotFound(new ApiResponse(404, $"El Payment solicitado no existe."));

            var Payment = _mapper.Map<Payment>(PaymentDto);
            _unitOfWork.Payments.Update(Payment);
            await _unitOfWork.SaveAsync();
            return PaymentDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (Payment == null)
                return NotFound(new ApiResponse(404, $"El Payment solicitado no existe."));

            _unitOfWork.Payments.Remove(Payment);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}