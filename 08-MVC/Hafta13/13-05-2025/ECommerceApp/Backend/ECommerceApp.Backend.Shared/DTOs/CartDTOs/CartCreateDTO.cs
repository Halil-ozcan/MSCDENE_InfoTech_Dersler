using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Backend.Shared.DTOs.CartDTOs;

public class CartCreateDTO
{
    [Required(ErrorMessage = "Kullanıcı Id bilgisi zorunludur")]
    public string? AppUserId { get; set; }
    
}
