
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using ECommerceApp.Backend.Shared.DTOs.AuthDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceApp.Frontend.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: AuthController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var client = new HttpClient();
            try
            {
                var jsonContent = JsonConvert.SerializeObject(loginDTO);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5100/auth/login", stringContent);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseDto = JsonConvert.DeserializeObject<ResponseDTO<TokenDTO>>(responseContent);
                if (responseDto?.IsSuccessful == true && responseDto.Data is not null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(responseDto.Data.AccessToken);
                    var claims = new List<Claim>();
                    claims.AddRange(jwtToken.Claims);
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = responseDto.Data.AccessTokenExpirationDate,
                        Items ={
                            {"access_token",responseDto.Data.AccessToken}
                        }
                    };
                    await _httpContextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View("Index");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
