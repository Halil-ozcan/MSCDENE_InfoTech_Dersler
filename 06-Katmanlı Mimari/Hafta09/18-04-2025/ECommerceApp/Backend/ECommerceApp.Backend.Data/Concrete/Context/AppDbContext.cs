using System;
using ECommerceApp.Backend.Data.Concrete.Configs;
using ECommerceApp.Backend.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ECommerceApp.Backend.Data.Concrete.Context;

public class AppDbContext:IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
        base.OnModelCreating(builder);
    }
}

// dotnet ef migrations add InitialDb --startup-project ../ECommerce.Backend.API
// dotnet ef migrations add InitialDb -s ../ECommerce.Backend.API (kısa hali)