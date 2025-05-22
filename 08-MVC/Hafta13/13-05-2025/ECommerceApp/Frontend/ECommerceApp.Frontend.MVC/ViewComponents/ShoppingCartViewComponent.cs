using System;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Frontend.MVC.ViewComponents;

public class ShoppingCartViewComponent:ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        int itemCount = 3;
        return View(model: itemCount);
    }
}
