
using System.Net.Http.Headers;
using System.Text;
using ECommerceApp.Backend.Shared.DTOs.CartDTOs;
using ECommerceApp.Backend.Shared.DTOs.OrderDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceApp.Frontend.MVC.Controllers
{

    public class OrderController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Checkout()
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
                var cart = result!.Data;
                var orderNowDto = new OrderNowDTO
                {
                    Address = "Test adresi",
                    City = "Test şehir",
                    OrderItems = cart.CartItems.Select(x => new OrderItemCreateDTO
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        UnitPrice = x.Product!.Price,
                        Product = x.Product
                    }).ToList()
                };
                return View(orderNowDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View(new OrderNowDTO());
            }
        }

        // Ödemeyi tamamlayıp siparişi veriyoruz
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderNowDTO orderNowDto)
        {
            var client = new HttpClient();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5100/carts");
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDTO<CartDTO>>(responseContent);
                response.EnsureSuccessStatusCode();
                var cart = result!.Data;
                orderNowDto.OrderItems = cart.CartItems.Select(x => new OrderItemCreateDTO
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    UnitPrice = x.Product!.Price
                }).ToList();
                var jsonContent = JsonConvert.SerializeObject(orderNowDto);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                response = await client.PostAsync("http://localhost:5100/orders", stringContent);
                response.EnsureSuccessStatusCode();
                responseContent = await response.Content.ReadAsStringAsync();
                var responseDto = JsonConvert.DeserializeObject<ResponseDTO<OrderDTO>>(responseContent);
                return Redirect("/");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View(new OrderNowDTO());
            }
        }
    }
}
