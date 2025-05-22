using System;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Frontend.MVC.ViewComponents;

public class TopBarViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string userName = "Halil Özcan";
        return View(model: userName);
    }
}
