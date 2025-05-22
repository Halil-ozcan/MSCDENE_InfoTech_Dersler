using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project01_MVC_Intro.Models;

namespace Project01_MVC_Intro.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<ContactInfo> contacts = [
             new ContactInfo("email1@example.com","city1","123456"),
            new ContactInfo("email12@example.com","city2","1234567"),
            new ContactInfo("email3@example.com","city3","1234568"),
            new ContactInfo("email4@example.com","city4","123459"),
            new ContactInfo("email5@example.com","city5","1234560"),
            new ContactInfo("email6@example.com","city6","1234561"),
            new ContactInfo("email7@example.com","city7","1234562"),
            new ContactInfo("email8@example.com","city8","1234563")
        ];
        return View(contacts); 
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult About()
    {
        ViewBag.ApiUrl = "http:localhost:5240/api";
        ViewBag.ErrorMessage = "Lütfen daha sonra yeniden deneyiniz.";
        return View();
    }

    public IActionResult Contact()
    {
        var contactInfo = new ContactInfo("info@ecommerceapp.com", "İstanbul", "12345678900");
        return View(contactInfo);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


//View Metodu():
// html sayfalarını üreten metot
//Razor View
//View Metodu, parametresiz kullanıldığında şu şekilde çalışır: View klasörüne gider orda içinde bulunduğu Controller'ın adında bir klasör arar. O klasörü bulunca onun içinde bulunduğu Action metodun adında bir .cshtml(razor view) dosyası arar.