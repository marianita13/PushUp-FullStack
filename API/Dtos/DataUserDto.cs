using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Domain.Entities;

namespace API.Dtos
{
    public class DataUserDto
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Rol> Roles { get; set; }
        public string Token { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}