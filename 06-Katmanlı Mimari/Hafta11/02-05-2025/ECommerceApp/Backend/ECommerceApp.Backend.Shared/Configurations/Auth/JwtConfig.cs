using System;

namespace ECommerceApp.Backend.Shared.Configurations.Auth;

public class JwtConfig
{
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? Secret { get; set; }
    public double AccessTokenExpiration { get; set; }
}
