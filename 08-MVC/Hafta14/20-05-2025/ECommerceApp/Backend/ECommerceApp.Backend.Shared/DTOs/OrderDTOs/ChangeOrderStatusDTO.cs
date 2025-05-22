using System;
using System.ComponentModel.DataAnnotations;
using ECommerceApp.Backend.Shared.Enums;

namespace ECommerceApp.Backend.Shared.DTOs.OrderDTOs;

public class ChangeOrderStatusDTO
{
    public ChangeOrderStatusDTO(int orderId, OrderStatus orderStatus)
    {
        OrderId = orderId;
        OrderStatus = orderStatus;
    }

    [Required(ErrorMessage = "Sipariş Id bilgisiz zorunludur")]
    public int OrderId { get; set; }

    [Required(ErrorMessage = "Sipariş durum bilgisi zorunludur")]
    public OrderStatus OrderStatus { get; set; }
}
