using AutoMapper;
using Commerce.Models.Models;
using Commerce.Dtos;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Services.MP
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateOrUpdateProductsDto, Products>().ReverseMap();
            CreateMap<GetAllProductsDto, Products>().ReverseMap();
            CreateMap<GetAllCategoriesDto, Categories>().ReverseMap();
            CreateMap<CreateOrUpdateCategoriesDto, Categories>().ReverseMap();
            CreateMap<GetAllOrdersDto, Orders>().ReverseMap();
            CreateMap<CreateOrdersDto, Customers>().ReverseMap();
            CreateMap<CreateOrdersDto, Products>().ReverseMap();
            CreateMap<CreateOrdersDto, OrderProducts>().ReverseMap();
            CreateMap<Customers, GetAllCustomersDto>();

        }

    }
}
