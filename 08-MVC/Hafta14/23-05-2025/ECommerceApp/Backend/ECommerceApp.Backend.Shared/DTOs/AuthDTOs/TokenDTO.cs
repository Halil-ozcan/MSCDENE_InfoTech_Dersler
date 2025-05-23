using System;

namespace ECommerceApp.Backend.Shared.DTOs.AuthDTOs;

public class TokenDTO
{
    public string? AccessToken { get; set; }
    public DateTime AccessTokenExpirationDate { get; set; }
    //RefreshToken adlı AccessToken'ı yenilemek için kullanılan bir mekanizma olabilir.
}
