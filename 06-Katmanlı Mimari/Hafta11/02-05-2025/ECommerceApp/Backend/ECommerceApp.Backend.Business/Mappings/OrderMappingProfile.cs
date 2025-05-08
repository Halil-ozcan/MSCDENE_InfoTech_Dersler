using System;
using AutoMapper;
using ECommerceApp.Backend.Entities.Concrete;
using ECommerceApp.Backend.Shared.DTOs.OrderDTOs;

namespace ECommerceApp.Backend.Business.Mappings;

public class OrderMappingProfile:Profile
{
    public OrderMappingProfile()
    {
        TimeZoneInfo turkeyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
        CreateMap<Order, OrderDTO>()
            .ForMember(
                dest => dest.AppUser,
                opt => opt.MapFrom(src => src.AppUser))
            .ForMember(
                dest => dest.OrderItems,
                opt => opt.MapFrom(src => src.OrderItems)
            )
            .ForMember(
                dest => dest.OrderDate,
                opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.CreatedAt.UtcDateTime, turkeyTimeZone)))
            .ForMember(
                dest => dest.CanceledDate,
                opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.DeletedAt.UtcDateTime, turkeyTimeZone)))
            .ForMember(
                dest => dest.OrderStatusUpdateDate,
                opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.UpdatedAt.UtcDateTime, turkeyTimeZone)))
            .ReverseMap();
        CreateMap<OrderNowDTO, Order>()
            .ForMember(
                dest => dest.OrderItems,
                opt => opt.MapFrom(src => src.OrderItems));

        CreateMap<OrderItem, OrderItemDTO>()
            .ForMember(
                dest => dest.ProductName,
                opt => opt.MapFrom(src => src.Product!.Name))
            .ForMember(
                dest => dest.ProductImageUrl,
                opt => opt.MapFrom(src => src.Product!.ImageUrl));
        CreateMap<OrderItemDTO, OrderItem>();
        CreateMap<OrderItemCreateDTO, OrderItem>();

    }
}
