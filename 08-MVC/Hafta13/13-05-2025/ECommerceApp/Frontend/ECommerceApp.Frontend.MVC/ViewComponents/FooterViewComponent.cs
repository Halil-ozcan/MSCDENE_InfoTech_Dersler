using System;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Frontend.MVC.ViewComponents;

public class FooterViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
