
using System.Net.Http.Headers;
using System.Text;
using ECommerceApp.Backend.Shared.DTOs.CategoryDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceApp.Frontend.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5100/categories");
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTO categoryCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = new HttpClient();
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(categoryCreateDTO.Name), "Name");
                formData.Add(new StringContent(categoryCreateDTO.Description), "Description");
                if (categoryCreateDTO.Image is not null)
                {
                    formData.Add(new StreamContent(categoryCreateDTO.Image.OpenReadStream()), "Image", categoryCreateDTO.Image.FileName);
                }
                else
                {
                    var defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin", "img", "nopicture.png");
                    formData.Add(new StreamContent(System.IO.File.OpenRead(defaultImagePath)), "Image", "nopicture.png");
                }


                var response = await client.PostAsync("http://localhost:5100/categories", formData);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseDto = JsonConvert.DeserializeObject<ResponseDTO<CategoryDTO>>(responseContent);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5100/categories/{id}");
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDTO<CategoryDTO>>(responseContent);
                response.EnsureSuccessStatusCode();
                var categoryUpdateDTO = new CategoryUpdateDTO
                {
                    Id = result!.Data.Id,
                    Name = result!.Data.Name!,
                    Description = result!.Data.Description!
                };
                ViewBag.ImageUrl = result!.Data.ImageUrl;
                return View(categoryUpdateDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View(new List<CategoryDTO>());
            }
        }


    }
}
