using System;

namespace ECommerceApp.Backend.Entities.Concrete;

public class Cart
{
    private Cart()
    {
        
    }
    public Cart(string? appUserId)
    {
        AppUserId = appUserId;
    }

    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }//AppUser tablosuyla birebir ilişki kuracak.
    public ICollection<CartItem> CartItems { get; set; }=[]; 
}
