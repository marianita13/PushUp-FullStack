using API.Controllers;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Contoller
{
    public class UserController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Register(DataUserDto request)
        {
            try
            {
                var existingUser = await _unitOfWork.Users.GetByUsernameAsync(request.Email);

                if (existingUser != null)
                {
                    BadRequest("El usuario ya está registrado");
                }

                var newUser = new User
                {
                    Username = request.UserName,
                    Email = request.Email,
                    Password = request.Password,
                    Rols = request.Roles
                };

                _unitOfWork.Users.Add(newUser);
                await _unitOfWork.SaveAsync();

                return Ok(); // Devuelve true si el usuario se registra correctamente
            }
            catch (Exception)
            {
                // Manejo de errores
                return StatusCode(500, false); // Envía falso en caso de error
            }
        }
        
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HttpResponse>> Login(LoginDto request)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByUsernameAsync(request.Username);

                if (user == null)
                {
                    return BadRequest();
                }

                bool passwordMatches= request.Password == user.Password;
                bool EmailMatches = request.Username == user.Username;

                if(passwordMatches && EmailMatches){
                    return Ok();
                }
                else{
                    return Unauthorized();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}