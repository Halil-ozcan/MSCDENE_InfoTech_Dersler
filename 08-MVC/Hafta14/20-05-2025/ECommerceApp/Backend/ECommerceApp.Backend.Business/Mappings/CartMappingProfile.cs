using System;
using AutoMapper;
using ECommerceApp.Backend.Entities.Concrete;
using ECommerceApp.Backend.Shared.DTOs.AuthDTOs;
using ECommerceApp.Backend.Shared.DTOs.CartDTOs;

namespace ECommerceApp.Backend.Business.Mappings;

public class CartMappingProfile : Profile
{
    public CartMappingProfile()
    {
        TimeZoneInfo turkeyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
        CreateMap<AppUser, AppUserDTO>();
        CreateMap<Cart, CartDTO>()
            .ForMember(
                dest => dest.AppUser,
                opt => opt.MapFrom(src => src.AppUser))
            .ForMember(
                dest => dest.CartItems,
                opt => opt.MapFrom(src => src.CartItems))
            .ReverseMap();

        CreateMap<CartCreateDTO, Cart>();


        CreateMap<CartItem, CartItemDTO>()
            .ForMember(
                dest => dest.Product,
                opt => opt.MapFrom(src => src.Product))
            .ReverseMap();



    }
}
