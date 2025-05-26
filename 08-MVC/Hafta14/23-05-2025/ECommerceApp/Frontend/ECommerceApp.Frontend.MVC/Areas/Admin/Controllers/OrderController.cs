using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using ECommerceApp.Backend.Shared.DTOs.OrderDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using ECommerceApp.Backend.Shared.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NToastNotify;

namespace ECommerceApp.Frontend.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IToastNotification _toastr;

        public OrderController(IHttpContextAccessor httpContextAccessor, IToastNotification toastr)
        {
            _httpContextAccessor = httpContextAccessor;
            _toastr = toastr;
        }

        public async Task<IActionResult> Index([FromQuery] OrderStatus? orderStatus = null)
        {
            ViewBag.OrderStatusList = GetOrderStatuses(orderStatus);
            ViewBag.GetOrderStatusesSelectList = new Func<OrderStatus?, List<SelectListItem>>(GetOrderStatuses);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5100/orders?orderStatus={orderStatus}");
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDTO<List<OrderDTO>>>(responseContent);
                response.EnsureSuccessStatusCode();
                return View(result!.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View(new List<OrderDTO>());
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5100/orders/{id}");
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDTO<OrderDTO>>(responseContent);
                response.EnsureSuccessStatusCode();
                return View(result!.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View(new OrderDTO());
            }
        }

        public async Task<IActionResult> ChangeOrderStatus(int orderId, OrderStatus orderStatus)
        {
            var client = new HttpClient();
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // /orders/5?orderStatus=2
                var response = await client.PutAsync($"http://localhost:5100/orders/{orderId}?orderStatus={orderStatus}", null);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseDto = JsonConvert.DeserializeObject<ResponseDTO<NoContentDTO>>(responseContent);
                return Json(responseDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View();
            }
        }


        public async Task<IActionResult> OrdersByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] OrderStatus? orderStatus)
        {
            ViewBag.OrderStatusList = GetOrderStatuses(orderStatus);
            ViewBag.GetOrderStatusesSelectList = new Func<OrderStatus?, List<SelectListItem>>(GetOrderStatuses);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5100/orders?orderStatus={orderStatus}&startDate={startDate}&endDate={endDate}");
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDTO<List<OrderDTO>>>(responseContent);
                response.EnsureSuccessStatusCode();
                return View(result!.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View(new List<OrderDTO>());
            }

        }
        private List<SelectListItem> GetOrderStatuses(OrderStatus? selectedStatus)
        {
            return Enum
                .GetValues(typeof(OrderStatus))
                .Cast<OrderStatus>()
                .Select(x => new SelectListItem
                {
                    Text = x
                        .GetType()
                        .GetField(x.ToString())?
                        .GetCustomAttributes(typeof(DisplayAttribute), false)
                        .Cast<DisplayAttribute>()
                        .FirstOrDefault()?
                        .Name ?? x.ToString(),
                    Value = ((int)x).ToString(),
                    Selected = selectedStatus == x
                }).ToList();
        }
    }
}