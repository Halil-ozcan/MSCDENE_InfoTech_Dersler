using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Entities.Concrete;
using ECommerceApp.Backend.Shared.Configurations.Auth;
using ECommerceApp.Backend.Shared.DTOs.AuthDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using ECommerceApp.Backend.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace ECommerceApp.Backend.Business.Concrete;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly JwtConfig _jwtConfig;

    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IOptions<JwtConfig> optionsJwtConfig)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtConfig = optionsJwtConfig.Value;
    }

    public async Task<ResponseDTO<TokenDTO>> LoginAsync(LoginDTO loginDTO)
    {
        try
        {
            var appUser = await _userManager.FindByNameAsync(loginDTO.UserNameOrEmail!) ?? await 
            _userManager.FindByEmailAsync(loginDTO.UserNameOrEmail!);
            if(appUser is null)
            {
                return ResponseDTO<TokenDTO>.Fail("Kullanıcı Adı veya Parola Hatalı!",StatusCodes.Status400BadRequest);
            }
            // Hesap Onaylı mı kontrolü yapacağız.


            //şifre kontrolü        
            bool isValidPassword = await _userManager.CheckPasswordAsync(appUser, loginDTO.Password!);
            if(!isValidPassword)
            {
                return ResponseDTO<TokenDTO>.Fail("Kullanıcı Adı veya Parola Hatalı!",StatusCodes.Status400BadRequest);
            }

            var tokenDto = await GenerateJwtToken(appUser);
            return ResponseDTO<TokenDTO>.Success(tokenDto,"İşlem Başarılı",StatusCodes.Status200OK);

        }
        catch (Exception ex)
        {
            return ResponseDTO<TokenDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    private async Task<TokenDTO> GenerateJwtToken(AppUser appUser)
    {
        try
        {
            //Claim'leri hazırlıyoruz
            var  roles = await _userManager.GetRolesAsync(appUser);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                new Claim(ClaimTypes.Name, appUser.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }.Union(roles.Select(x=> new Claim(ClaimTypes.Role, x)));

            //Security ayarlarını yapıyoruz
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret!));
            var signInCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_jwtConfig.AccessTokenExpiration);


            var token = new JwtSecurityToken(
                issuer:_jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: claims,
                signingCredentials: signInCredentials,
                expires:expires
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            var tokenDto = new TokenDTO()
            {
                AccessToken = accessToken,
                AccessTokenExpirationDate = expires
            };
            return tokenDto;
            

        }
        
        catch (System.Exception ex)
        {
           Console.WriteLine($"Beklenmedik Hata {ex.Message}");
           throw;
        }
    }

    public async Task<ResponseDTO<AppUserDTO>> RegisterAsync(RegisterDTO registerDTO)
    {
        try
        {
            var existingUser = await _userManager.FindByNameAsync(registerDTO.UserName!);
            if(existingUser is not null)
            {
                return ResponseDTO<AppUserDTO>.Fail("Bu Kullanıcı adı zaten Mevcut'",StatusCodes.Status400BadRequest);
            }
            AppUser appUser = new(registerDTO.FirstName,registerDTO.LastName,registerDTO.UserName,registerDTO.Email);
            var result = await _userManager.CreateAsync(appUser,registerDTO.Password!);
            if(!result.Succeeded)
            {
                return ResponseDTO<AppUserDTO>.Fail("Kullanıcı kayıt sırasında bir sorun oluştu!",StatusCodes.Status500InternalServerError);
            }
            result = await _userManager.AddToRoleAsync(appUser,"NORMAL");
            if(!result.Succeeded)
            {
                return ResponseDTO<AppUserDTO>.Fail(string.Join(",",result.Errors.ToList()), StatusCodes.Status500InternalServerError);
            }
            //Email Onay İşlemleri Yapacağız

            AppUserDTO appUserDTO = new(){
                Id= appUser.Id,
                FirstName=appUser.FirstName,
                LastName=appUser.LastName,
                UserName=appUser.UserName,
                Email=appUser.Email,
                Address= appUser.Address,
                City = appUser.City,
                DateOfBirth = DateTime.UtcNow,
                EmailConfirmed = appUser.EmailConfirmed,
                Gender = Gender.None,
            };
            return ResponseDTO<AppUserDTO>.Success(appUserDTO,"İşlem Başarılı",StatusCodes.Status201Created);

        }
        catch (Exception ex)
        {
            return ResponseDTO<AppUserDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }









    public Task<ResponseDTO<NoContentDTO>> ChangePasswordAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO<NoContentDTO>> ConfirmAccountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO<NoContentDTO>> ForgotPasswordAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO<NoContentDTO>> ResetPasswordAsync()
    {
        throw new NotImplementedException();
    }
}
