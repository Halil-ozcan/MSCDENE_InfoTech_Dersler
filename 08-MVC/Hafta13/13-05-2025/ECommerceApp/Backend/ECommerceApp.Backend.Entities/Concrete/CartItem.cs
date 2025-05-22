using System;
using ECommerceApp.Backend.Entities.Abstract;

namespace ECommerceApp.Backend.Entities.Concrete;

public class CartItem : IEntity
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
}
