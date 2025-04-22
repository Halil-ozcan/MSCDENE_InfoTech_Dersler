using ECommerceApp.Backend.API.ControllerBases;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Shared.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Backend.API.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : CustomControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDTO categoryCreateDTO)
        {
            var response = await _productService.AddAsync(categoryCreateDTO);
            return CreateResult(response);
        }
        [HttpGet("count")]
        public async Task<IActionResult> Count([FromQuery] bool? isDeleted=null, [FromQuery] int? categoryId=null)
        {
            var response = await _productService.CountAsync(isDeleted, categoryId);
            return CreateResult(response);
        }
    }
}
