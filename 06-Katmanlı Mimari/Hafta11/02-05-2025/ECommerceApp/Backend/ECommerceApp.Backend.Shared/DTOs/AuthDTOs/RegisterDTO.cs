using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Backend.Shared.DTOs.AuthDTOs;

public class RegisterDTO
{
    [Required(ErrorMessage = "Ad zorunludur")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Soyad zorunludur")]
    public string? LastName { get; set; }
    [Required(ErrorMessage = "Kullanıcı Adı zorunludur")]
    public string? UserName { get; set; }
    [Required(ErrorMessage = "Email adresi zorunludur")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Parola zorunludur")]
    public string? Password { get; set; }
    [Required(ErrorMessage = "Parola Tekrar zorunludur")]
    [Compare("Password", ErrorMessage = "Parolalar Eşleşmiyor")]
    public string? ConfirmPassword { get; set; }
}
