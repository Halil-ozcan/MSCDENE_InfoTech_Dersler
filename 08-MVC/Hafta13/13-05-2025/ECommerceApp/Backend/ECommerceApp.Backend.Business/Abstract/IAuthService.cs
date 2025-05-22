using System;
using ECommerceApp.Backend.Shared.DTOs.AuthDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;

namespace ECommerceApp.Backend.Business.Abstract;

public interface IAuthService
{
    Task<ResponseDTO<TokenDTO>> LoginAsync(LoginDTO loginDTO);
    Task<ResponseDTO<AppUserDTO>> RegisterAsync(RegisterDTO registerDTO);
    Task<ResponseDTO<NoContentDTO>> ForgotPasswordAsync(); // Zaman olursa bunları da yapcaz. Şuan boş olarak bırakıyoruz.
    Task<ResponseDTO<NoContentDTO>> ResetPasswordAsync();
    Task<ResponseDTO<NoContentDTO>> ChangePasswordAsync();
    Task<ResponseDTO<NoContentDTO>> ConfirmAccountAsync();
}
