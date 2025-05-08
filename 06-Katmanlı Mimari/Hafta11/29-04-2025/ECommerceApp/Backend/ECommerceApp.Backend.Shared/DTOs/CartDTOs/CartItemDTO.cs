using System;
using ECommerceApp.Backend.Shared.DTOs.ProductDTOs;

namespace ECommerceApp.Backend.Shared.DTOs.CartDTOs;

public class CartItemDTO
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public ProductDTO Product { get; set; } = new();// bu şekilde product null gelmeyecek. ve aşağıdaki product.price null yerine 0 olarak gelecek ve program hata vermeyecek.
    public int Quantity { get; set; }
    public decimal TotalAmount => Product.Price * Quantity;
}
