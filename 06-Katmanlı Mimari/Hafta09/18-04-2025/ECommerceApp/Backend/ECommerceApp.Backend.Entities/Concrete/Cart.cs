using System;
using ECommerceApp.Backend.Entities.Abstract;

namespace ECommerceApp.Backend.Entities.Concrete;

 public class Cart:IEntity
{
    private Cart()
    {
        
    }
    public Cart(string? appUserId)
    {
        AppUserId = appUserId;
    }
    public int Id { get; set; }
    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }//AppUser tablosuyla birebir ilişki kuracak.
    public ICollection<CartItem> CartItems { get; set; }=[]; 
}
