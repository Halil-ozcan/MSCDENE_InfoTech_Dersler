using System;
using System.Net.Http.Headers;
using ECommerceApp.Backend.Shared.DTOs.CartDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceApp.Frontend.MVC.ViewComponents;

public class ShoppingCartViewComponent : ViewComponent
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ShoppingCartViewComponent(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IViewComponentResult> InvokeAsync()
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
            return View(result!.Data.CartItemsCount);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"HATA: {ex.Message}");
            return View(model: 0);
        }
    }
}