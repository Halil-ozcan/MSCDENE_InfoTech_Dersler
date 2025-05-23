using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Frontend.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

    }
}