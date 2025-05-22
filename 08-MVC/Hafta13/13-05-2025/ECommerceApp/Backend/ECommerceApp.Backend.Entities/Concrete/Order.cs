using System;
using ECommerceApp.Backend.Entities.Abstract;
using ECommerceApp.Backend.Shared.Enums;

namespace ECommerceApp.Backend.Entities.Concrete;

public class Order : BaseEntity,IEntity
{
    private Order()
    {
        
    }
    public Order(string? appUserId, string? address, string? city)
    {
        AppUserId = appUserId;
        Address = address;
        City = city;
    }

    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
    public ICollection<OrderItem> OrderItems { get; set; } = [];
}
