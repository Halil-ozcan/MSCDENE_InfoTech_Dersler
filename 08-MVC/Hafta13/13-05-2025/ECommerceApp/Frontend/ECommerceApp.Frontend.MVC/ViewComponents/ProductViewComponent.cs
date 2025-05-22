using System;
using ECommerceApp.Backend.Shared.DTOs.ProductDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceApp.Frontend.MVC.ViewComponents;

public class ProductViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string title)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5100/products/homepages");
        try
        {
            var response = await client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDTO<List<ProductDTO>>>(responseContent);
            response.EnsureSuccessStatusCode();
            ViewData["Title"] = title;
            return View(result!.Data);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"HATA: {ex.Message}");
            return View(new List<ProductDTO>());
        }
    }
}