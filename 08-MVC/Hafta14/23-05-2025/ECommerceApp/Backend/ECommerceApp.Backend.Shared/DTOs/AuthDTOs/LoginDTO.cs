using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Backend.Shared.DTOs.AuthDTOs;

public class LoginDTO
{
    [Required(ErrorMessage = "Kullanıcı adı ya da Email zorunludur.")]
    public string? UserNameOrEmail { get; set; }
    [Required(ErrorMessage = "Parola Zorunludur!")]
    public string? Password { get; set; }
}
