using ECommerceApp.Backend.API.ControllerBases;
using ECommerceApp.Backend.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Backend.API.Controllers
{
    [Route("carts")]
    [ApiController]
    [Authorize]
    public class CartController : CustomControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var response = await _cartService.GetCartAsync(GetUserId());
            return CreateResult(response);

        }
    }
}
