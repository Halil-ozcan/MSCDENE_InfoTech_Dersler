using System.Net.Http.Headers;
using ECommerceApp.Backend.Shared.DTOs.CategoryDTOs;
using ECommerceApp.Backend.Shared.DTOs.ProductDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace ECommerceApp.Frontend.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IToastNotification _toastr;

        public ProductController(IHttpContextAccessor httpContextAccessor, IToastNotification toastr)
        {
            _httpContextAccessor = httpContextAccessor;
            _toastr = toastr;
        }

        public async Task<IActionResult> Index([FromQuery] bool isDeleted = false)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5100/products/admin?isDeleted={isDeleted}");
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDTO<List<ProductDTO>>>(responseContent);
                if (result is not null)
                    response.EnsureSuccessStatusCode();
                ViewBag.IsDeleted = isDeleted;
                return View(result!.Data);
            }
            catch (Exception ex)
            {
                _toastr.AddErrorToastMessage("Geri dönüşüm kutusunda ürün bulunamadı!");
                return View(new List<ProductDTO>());
            }
        }

        public async Task<IActionResult> Create()
        {
            var categories = await GetCategoriesAsync();
            if (categories is null)
            {
                _toastr.AddWarningToastMessage("Kategori listesi çekilemediği için, ürün oluşturma sayfası açılamıyor!");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryList = categories;
            return View(new ProductCreateDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                var categories = await GetCategoriesAsync();
                if (categories is null)
                {
                    _toastr.AddWarningToastMessage("Kategori listesi çekilemediği için, ürün oluşturma sayfası açılamıyor!");
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.CategoryList = categories;
                return View(productCreateDTO);
            }
            var client = new HttpClient();
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(productCreateDTO.Name), "Name");
                formData.Add(new StringContent(productCreateDTO.Properties), "Properties");
                formData.Add(new StringContent(productCreateDTO.Price.ToString()!), "Price");
                formData.Add(new StringContent(productCreateDTO.IsHome.ToString()!), "IsHome");
                if (productCreateDTO.CategoryIds.Count == 0)
                {
                    _toastr.AddErrorToastMessage("Mutlaka en az bir kategori seçilmelidir!");
                    var categories = await GetCategoriesAsync();
                    if (categories is null)
                    {
                        _toastr.AddWarningToastMessage("Kategori listesi çekilemediği için, ürün oluşturma sayfası açılamıyor!");
                        return RedirectToAction(nameof(Index));
                    }
                    ViewBag.CategoryList = categories;
                    return View(productCreateDTO);
                }
                foreach (int id in productCreateDTO.CategoryIds)
                {
                    formData.Add(new StringContent(id.ToString()), "CategoryIds");
                }

                if (productCreateDTO.Image is not null)
                {
                    formData.Add(new StreamContent(productCreateDTO.Image.OpenReadStream()), "Image", productCreateDTO.Image.FileName);
                }
                else
                {
                    var defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin", "img", "nopicture.png");
                    formData.Add(new StreamContent(System.IO.File.OpenRead(defaultImagePath)), "Image", "nopicture.png");
                }


                var response = await client.PostAsync("http://localhost:5100/products", formData);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseDto = JsonConvert.DeserializeObject<ResponseDTO<ProductDTO>>(responseContent);
                _toastr.AddSuccessToastMessage("Kayıt başarıyla gerçekleşmiştir!");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _toastr.AddErrorToastMessage(ex.Message);
                var categories = await GetCategoriesAsync();
                if (categories is null)
                {
                    _toastr.AddWarningToastMessage("Kategori listesi çekilemediği için, ürün oluşturma sayfası açılamıyor!");
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.CategoryList = categories;
                return View(productCreateDTO);
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            var categories = await GetCategoriesAsync();
            if (categories is null)
            {
                _toastr.AddWarningToastMessage("Kategori listesi çekilemediği için, ürün oluşturma sayfası açılamıyor!");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryList = categories;


            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5100/products/{id}?includeCategories=true");
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDTO<ProductDTO>>(responseContent);
                response.EnsureSuccessStatusCode();
                var productUpdateDTO = new ProductUpdateDTO
                {
                    Id = result!.Data.Id,
                    Name = result!.Data.Name!,
                    Properties = result!.Data.Properties!,
                    Price = result!.Data.Price,
                    IsHome = result!.Data.IsHome,
                    CategoryIds = result!.Data.Categories.Select(x => x.Id).ToList()
                };
                ViewBag.ImageUrl = result!.Data.ImageUrl;
                return View(productUpdateDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View(new CategoryUpdateDTO());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductUpdateDTO productUpdateDTO, string imageUrl)
        {
            if (!ModelState.IsValid || productUpdateDTO.CategoryIds.Count == 0)
            {
                if (productUpdateDTO.CategoryIds.Count == 0)
                {
                    ModelState.AddModelError("CategoryIds", "En az bir kategori seçilmelidir!");
                }
                var categories = await GetCategoriesAsync();
                if (categories is null)
                {
                    _toastr.AddWarningToastMessage("Kategori listesi çekilemediği için, ürün oluşturma sayfası açılamıyor!");
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.CategoryList = categories;
                ViewBag.ImageUrl = imageUrl;
                return View(productUpdateDTO);
            }
            var client = new HttpClient();
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(productUpdateDTO.Id.ToString()), "Id");
                formData.Add(new StringContent(productUpdateDTO.Name), "Name");
                formData.Add(new StringContent(productUpdateDTO.Properties), "Properties");
                formData.Add(new StringContent(productUpdateDTO.Price.ToString()!), "Price");
                formData.Add(new StringContent(productUpdateDTO.IsHome.ToString()!), "IsHome");
                if (productUpdateDTO.CategoryIds.Count == 0)
                {
                    _toastr.AddErrorToastMessage("Mutlaka en az bir kategori seçilmelidir!");
                    var categories = await GetCategoriesAsync();
                    if (categories is null)
                    {
                        _toastr.AddWarningToastMessage("Kategori listesi çekilemediği için, ürün oluşturma sayfası açılamıyor!");
                        return RedirectToAction(nameof(Index));
                    }
                    ViewBag.CategoryList = categories;
                    return View(productUpdateDTO);
                }
                foreach (int id in productUpdateDTO.CategoryIds)
                {
                    formData.Add(new StringContent(id.ToString()), "CategoryIds");
                }

                if (productUpdateDTO.Image is not null)
                {
                    formData.Add(new StreamContent(productUpdateDTO.Image.OpenReadStream()), "Image", productUpdateDTO.Image.FileName);
                }

                var response = await client.PutAsync("http://localhost:5100/products", formData);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseDto = JsonConvert.DeserializeObject<ResponseDTO<NoContentDTO>>(responseContent);
                _toastr.AddSuccessToastMessage("Kayıt başarıyla gerçekleşmiştir!");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _toastr.AddErrorToastMessage(ex.Message);
                var categories = await GetCategoriesAsync();
                if (categories is null)
                {
                    _toastr.AddWarningToastMessage("Kategori listesi çekilemediği için, ürün oluşturma sayfası açılamıyor!");
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.CategoryList = categories;
                ViewBag.ImageUrl = imageUrl;
                return View(productUpdateDTO);
            }

        }

        public async Task<IActionResult> Trash(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5100/products/{id}");
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDTO<ProductDTO>>(responseContent);
                response.EnsureSuccessStatusCode();

                ViewBag.ImageUrl = result!.Data.ImageUrl;
                return View(result.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return View(new ProductDTO());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Trash(int id, [FromQuery] bool deleteType = true)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(deleteType ? HttpMethod.Delete : HttpMethod.Put, $"http://localhost:5100/products/{id}");


            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDTO<NoContentDTO>>(responseContent);
                if (!result!.IsSuccessful)
                {
                    _toastr.AddErrorToastMessage(result.Message);
                    return RedirectToAction(nameof(Trash), new { id, deleteType });
                }
                _toastr.AddSuccessToastMessage(deleteType ? "Silme işlemi başarıyla tamamlanmıştır!" : "Geri dönüşüm kutusuna  işlemi başarıyla tamamlanmıştır!");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _toastr.AddErrorToastMessage(ex.Message);
                return RedirectToAction(nameof(Trash), new { Id = id });
            }
        }

        private async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5100/categories");
            try
            {
                var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var token = authResult.Properties?.Items["access_token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDTO<List<CategoryDTO>>>(responseContent);
                response.EnsureSuccessStatusCode();
                return result!.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                return null!;
            }

        }
    }
}