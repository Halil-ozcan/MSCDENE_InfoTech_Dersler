using System;
using AutoMapper;
using ECommerceApp.Backend.Entities.Concrete;
using ECommerceApp.Backend.Shared.DTOs.ProductDTOs;

namespace ECommerceApp.Backend.Business.Mappings;

public class ProductMappingProfile : Profile
{

    public ProductMappingProfile()
    {
        TimeZoneInfo turkeyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
        CreateMap<Product, ProductDTO>()
        .ForMember(
            dest=>dest.Categories,
            opt=>opt.MapFrom(src=>src.ProductCategories.Select(pc=>pc.Category)))
        .ForMember(
                dest => dest.CreatedAt,
                opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.CreatedAt.UtcDateTime, turkeyTimeZone))
            )
            .ForMember(
                dest => dest.CreatedAt,
                opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.CreatedAt.UtcDateTime, turkeyTimeZone))
            )
            .ForMember(
                dest => dest.CreatedAt,
                opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.CreatedAt.UtcDateTime, turkeyTimeZone))
            )
            .ReverseMap();
        CreateMap<ProductCreateDTO, Product>();
        CreateMap<ProductUpdateDTO, Product>();

    }
}
