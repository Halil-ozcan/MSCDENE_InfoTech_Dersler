using System;
using ECommerceApp.Backend.Data.Concrete.Configs;
using ECommerceApp.Backend.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ECommerceApp.Backend.Data.Concrete.Context;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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


        #region Rol İşlemleri
        var adminRole = new IdentityRole("Admin") { Id = "990a7e41-dfb9-4d5a-b783-0f1ebde4b9c2", NormalizedName = "ADMIN" };
        var NormalRole = new IdentityRole("Normal") { Id = "aa33fd02-dd33-4f12-8fab-dd9dc18e0bdb", NormalizedName = "NORMAL" };

        builder.Entity<IdentityRole>().HasData(adminRole, NormalRole);

        #endregion

        #region User İşlemleri
        var hasher = new PasswordHasher<AppUser>();
        var adminUser = new AppUser("Ali", "Eren", "adminuser", "adminuser@example.com"){NormalizedUserName="ADMINUSER",NormalizedEmail="ADMINUSER@EXAMPLE.COM", Id= "23f8f723-bcdc-4fdb-9851-c8036f761c42" };
        adminUser.PasswordHash =hasher.HashPassword(adminUser,"Qwe123.,");


        var normalUser = new AppUser("Canan", "Kedi", "normaluser", "normaluser@example.com"){NormalizedUserName="NORMALUSER",NormalizedEmail="NORMALUSER@EXAMPLE.COM", Id= "c79ede8e-3c7e-4be7-a36c-5338ed79fd30" };
        normalUser.PasswordHash =hasher.HashPassword(normalUser, "Qwe123.,");

        builder.Entity<AppUser>().HasData(adminUser, normalUser);

        #endregion

        #region User-Role Atama İşlemleri
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = adminUser.Id,
                    RoleId=adminRole.Id,
                },
                new IdentityUserRole<string>
                {
                    UserId = normalUser.Id,
                    RoleId = NormalRole.Id,
                }
            );
        #endregion
        base.OnModelCreating(builder);
    }
}

// dotnet ef migrations add InitialDb --startup-project ../ECommerce.Backend.API
// dotnet ef migrations add InitialDb -s ../ECommerce.Backend.API (kısa hali)