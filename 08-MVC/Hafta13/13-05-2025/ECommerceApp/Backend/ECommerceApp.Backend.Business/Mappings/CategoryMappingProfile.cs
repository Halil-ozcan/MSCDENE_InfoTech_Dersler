
using System;
using AutoMapper;
using ECommerceApp.Backend.Entities.Concrete;
using ECommerceApp.Backend.Shared.DTOs.CategoryDTOs;

namespace ECommerceApp.Backend.Business.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        TimeZoneInfo turkeyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
        CreateMap<Category, CategoryDTO>()
            .ForMember(
                dest => dest.CreatedAt,
                opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.CreatedAt.UtcDateTime, turkeyTimeZone)))
            .ForMember(
                dest => dest.UpdatedAt,
                opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.UpdatedAt.UtcDateTime, turkeyTimeZone)))
            .ForMember(
                dest => dest.DeletedAt,
                opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.DeletedAt.UtcDateTime, turkeyTimeZone)))
            .ReverseMap();

        CreateMap<CategoryCreateDTO, Category>();
        CreateMap<CategoryUpdateDTO, Category>();
    }
}
