using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project07_NorthwindManagmentAPI.Data.Repositories;
using Project07_NorthwindManagmentAPI.Models;

namespace Project07_NorthwindManagmentAPI.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
       private readonly NorthwindRepository _northwindRepository;

        public CategoriesController(NorthwindRepository northwindRepository)
        {
            // Dependency Injection(DI)
            _northwindRepository = northwindRepository;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _northwindRepository.GetAllCategories();
            return Ok(categories);//Json Serialization işlemi otomatik yapılmaktadır.
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoriesById(int id)
        {
            var category = _northwindRepository.GetCategoryById(id);
            if(category == null)
            {
                return NotFound(new {ErrorMessage =$"{id} ID'li category bulunamadı!"});
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult AddCategories([FromBody] Category category)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdCategories = _northwindRepository.AddCategory(category);
            if(createdCategories is null)
            {
               return StatusCode(500,"category oluşturulurken bir sorun oluştu lütfen daha sonra deneyiniz!");
            }
            return StatusCode(201,createdCategories);   

        }

        [HttpPut("{id}")]
        public IActionResult UpdatedCategories(int id, [FromBody] Category category)
        {
            if(id!=category.CategoryID)
            {
                return BadRequest("Url!deki Id ile ürün Id'si uyuşmuyor");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingCategory = _northwindRepository.GetCategoryById(id);
            if(existingCategory is null)
            {
                return  StatusCode(404,$"{id} ID'li ürün bulunamadığı için güncelleme başarısı oldu!");
            }
            var isUpdated = _northwindRepository.UpdateCategory(category);
            if(!isUpdated)
            {
                return StatusCode(500,"Ürün Güncellenirken bir sorun oluştu");
            }
            return NoContent();
        } 


        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _northwindRepository.GetCategoryById(id);
            if(category is null)
            {
                return NotFound(new {Message =$"{id} ID'li ürün bulunamadığı için başarısız oldu."});
            }   
            var isDeleted = _northwindRepository.DeleteCategory(id);
            if(!isDeleted)
            {
                return StatusCode(500, new{messge="Ürün Silinirken bir hata oluştu."});
            }
            return NoContent();
        }   
    }
}
