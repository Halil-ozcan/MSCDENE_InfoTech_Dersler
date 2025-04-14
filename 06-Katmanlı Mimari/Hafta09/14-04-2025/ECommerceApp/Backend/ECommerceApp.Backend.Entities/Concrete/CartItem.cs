using System;

namespace ECommerceApp.Backend.Entities.Concrete;

public class CartItem
{
    private CartItem()
    {
        
    }
    public CartItem(int cartId, int productId = 0, int quantity = 0)
    {
        CartId = cartId;
        ProductId = productId;
        Quantity = quantity;
    }

    public int CartId { get; set; }
    public Cart? Cart { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
}
