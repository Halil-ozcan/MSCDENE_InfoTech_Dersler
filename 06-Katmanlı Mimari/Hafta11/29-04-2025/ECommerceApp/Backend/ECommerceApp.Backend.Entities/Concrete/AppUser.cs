using System;
using ECommerceApp.Backend.Shared.Enums;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Backend.Entities.Concrete;

public class AppUser:IdentityUser
{
    private AppUser()
    {
        
    }
    public AppUser(string? firstName, string? lastName,string? userName,string? email)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Email = email;
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public Gender? Gender { get; set; }
}
