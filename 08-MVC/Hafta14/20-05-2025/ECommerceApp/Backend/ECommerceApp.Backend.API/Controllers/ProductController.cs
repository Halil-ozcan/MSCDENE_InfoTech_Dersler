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
        public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
        {
            var response = await _productService.AddAsync(productCreateDTO);
            return CreateResult(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDTO)
        {
            var response = await _productService.UpdateAsync(productUpdateDTO);
            return CreateResult(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var response = await _productService.HardDeleteAsync(id);
            return CreateResult(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var response = await _productService.SoftDeleteAsync(id);
            return CreateResult(response);
        }
        [HttpPut("{id}/ishome")]
        public async Task<IActionResult> UpdateIsHome(int id)
        {
            var response = await _productService.UpdateIsHomeAsync(id);
            return CreateResult(response);
        }
        [HttpGet("count")]
        public async Task<IActionResult> Count([FromQuery] bool? isDeleted = null, [FromQuery] int? categoryId = null)
        {
            var response = await _productService.CountAsync(isDeleted, categoryId);
            return CreateResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool includeCategories = false, [FromQuery] int? categoryId = null)
        {
            var response = await _productService.GetAllAsync(
                isDeleted:false,
                includeCategories:includeCategories,
                categoryId:categoryId
            );
            return CreateResult(response);
        }

        [HttpGet("homepages")]
        public async Task<IActionResult> GetHomePages()
        {
            var response = await _productService.GetAllHomePageAsync();
            return CreateResult(response);
        }
        
        [HttpGet("admin")]
        public async Task<IActionResult> GetAllAdmin(
            [FromQuery] bool includeCategories=false,
            [FromQuery] int? categoryId=null,
            [FromQuery] bool? isDeleted=null
        )
        {
            var response = await _productService.GetAllAsync(
                includeCategories:includeCategories,
                categoryId:categoryId,
                isDeleted:isDeleted
            );
            return CreateResult(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromQuery] bool includeCategories=false)
        {
            var response = await _productService.GetAsync(id,includeCategories);
            return CreateResult(response);
        }
        [HttpPut("{id}/softdeletebycategory")]
        public async Task<IActionResult> SoftDeleteByCategory(int categoryId)
        {
            var response = await _productService.SoftDeleteByCategoryAsync(categoryId);
            return CreateResult(response);
        }


    }
}
