using ECommerceApp.Backend.API.ControllerBases;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Shared.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Backend.API.Controllers
{
    
    [Route("categories")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : CustomControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _categoryService.GetAsync(id);
            return CreateResult(response);
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] bool? isDeleted=null)
        {
            var response = await _categoryService.GetAllAsync(isDeleted);
            return CreateResult(response);
        }
        [HttpPost]
        
        public async Task<IActionResult> Create([FromForm] CategoryCreateDTO categoryCreateDTO)
        {
            var response = await _categoryService.AddAsync(categoryCreateDTO);
            return CreateResult(response);
        }
        [HttpPut]
        
        public async Task<IActionResult> Update([FromForm] CategoryUpdateDTO categoryUpdateDTO)
        {
            var response = await _categoryService.UpdateAsync(categoryUpdateDTO);
            return CreateResult(response);
        }

        [HttpDelete("{id}")]
        
        public async Task<IActionResult> HardDelete(int id)
        {
            var response = await _categoryService.HardDeleteAsync(id);
            return CreateResult(response);
        }

        [HttpPut("{id}")]
        
        public async Task<IActionResult> SoftDelete(int id)
        {
            var response = await _categoryService.SoftDeleteAsync(id);
            return CreateResult(response);
        }

        [HttpGet("count")]
        
        public async Task<IActionResult> Count([FromQuery] bool? isDeleted = null)
        {
            var response = await _categoryService.CountAsync(isDeleted);
            return CreateResult(response);
        }


    }
}
