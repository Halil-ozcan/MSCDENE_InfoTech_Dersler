using System;
using ECommerceApp.Backend.Entities.Abstract;

namespace ECommerceApp.Backend.Entities.Concrete;

public class OrderItem:BaseEntity
{
    private OrderItem()
    {
        
    }
    public OrderItem(int orderId, int productId, int quantity, decimal unitPrice)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public int OrderId { get; set; }
    public Order? Order { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
