using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ECommerceApp.Backend.Shared.DTOs.CartDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceApp.Frontend.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: CartController
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5100/carts");
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDTO<CartDTO>>(responseContent);
                response.EnsureSuccessStatusCode();
                return View(result!.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View(new CartDTO());
            }
        }

        public async Task<IActionResult> AddToCart([FromQuery] int productId, int quantity = 1)
        {
            var client = new HttpClient();
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var addToCartDTO = new AddToCartDTO { ProductId = productId, Quantity = quantity };
                var jsonContent = JsonConvert.SerializeObject(addToCartDTO);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5100/carts", stringContent);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseDto = JsonConvert.DeserializeObject<ResponseDTO<CartItemDTO>>(responseContent);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View("Index");
            }
        }


        public async Task<IActionResult> RemoveFromCart([FromQuery] int cartItemId)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"http://localhost:5100/carts/{cartItemId}");
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDTO<CartDTO>>(responseContent);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View(new CartDTO());
            }
        }

       
    }


}
