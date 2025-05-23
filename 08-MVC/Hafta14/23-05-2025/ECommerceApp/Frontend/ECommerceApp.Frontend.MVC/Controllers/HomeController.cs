using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Frontend.MVC.Models;

namespace ECommerceApp.Frontend.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
