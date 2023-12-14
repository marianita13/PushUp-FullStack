using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<MethodPayment, MethodPaymentDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<Sale, SaleDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}