using System;
using ECommerceApp.Backend.Shared.Enums;

namespace ECommerceApp.Backend.Shared.DTOs.AuthDTOs;

public class AppUserDTO
{
    public string? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public Gender Gender { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public bool EmailConfirmed { get; set; }
}
