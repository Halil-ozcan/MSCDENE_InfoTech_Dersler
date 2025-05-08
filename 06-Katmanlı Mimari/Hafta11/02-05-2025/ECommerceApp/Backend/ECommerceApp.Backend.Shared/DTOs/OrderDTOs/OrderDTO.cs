using System;
using ECommerceApp.Backend.Shared.DTOs.AuthDTOs;
using ECommerceApp.Backend.Shared.Enums;

namespace ECommerceApp.Backend.Shared.DTOs.OrderDTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime CanceledDate { get; set; }
    public DateTime OrderStatusUpdateDate { get; set; }
    public string? AppUserId { get; set; }
    public AppUserDTO? AppUser { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public ICollection<OrderItemDTO> OrderItems { get; set; } = [];
    public decimal TotalAmount => OrderItems.Sum(x => x.ItemAmount);
}