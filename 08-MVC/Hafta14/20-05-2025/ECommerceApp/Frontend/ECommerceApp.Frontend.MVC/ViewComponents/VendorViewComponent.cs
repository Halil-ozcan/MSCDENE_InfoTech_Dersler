using System;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Frontend.MVC.ViewComponents;

public class VendorViewComponent:ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
