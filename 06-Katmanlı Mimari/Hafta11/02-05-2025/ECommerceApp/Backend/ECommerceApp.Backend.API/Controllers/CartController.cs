using ECommerceApp.Backend.API.ControllerBases;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Shared.DTOs.CartDTOs;
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
        [HttpPost]
        public async Task<IActionResult> AddToCard(AddToCartDTO addToCartDTO)
        {
            addToCartDTO.AppUserId = GetUserId();
            var response = await _cartService.AddToCartAsync(addToCartDTO);
            return CreateResult(response);

        }
        [HttpPut("{cartItemId}/qty")] // /carts/2/qty?quantity=5
        public async Task<IActionResult> ChangeQuantity(int cartItemId, [FromQuery] int quantity)
        {
            var changeQuantityDTO = new ChangeQuantityDTO(cartItemId, quantity);
            var response = await _cartService.ChangeQuantityAsync(changeQuantityDTO);
            return CreateResult(response);
        }
        [HttpDelete("{cartItemId}")] // /carts/2/qty?quantity=5
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            
            var response = await _cartService.RemoveFromCartAsync(cartItemId);
            return CreateResult(response);
        }
        [HttpDelete] // /carts/2/qty?quantity=5
        public async Task<IActionResult> Clear()
        {

            var response = await _cartService.ClearCartAsync(GetUserId());
            return CreateResult(response);
        }
    }
}
