using System;
using ECommerceApp.Backend.Shared.DTOs.CategoryDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceApp.Frontend.MVC.ViewComponents;

public class CategoriesViewComponent:ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5100/categories");
        try
        {
            var response = await client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDTO<List<CategoryDTO>>>(responseContent);
            response.EnsureSuccessStatusCode();
            return View(result!.Data);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"HATA: {ex.Message}");
            return View(new List<CategoryDTO>());
        }
    }
}
