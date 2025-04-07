using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project08_LINQ.Models;
using Project08_LINQ.Models.Repositpries;

namespace Project08_LINQ.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> categories = Repository.Categories.ToList();// bunun  yerine 
            //  var categories = Repository.Categories.ToList(); bunu kullanacağız daha kısa ve daha okunaklı kod açısından.
            return Ok(categories);
        }

        // Kategori İsimlerini listele
        [HttpGet("names")]
        public IActionResult GetAllNames()
        {
            // Method Syntax
            var categoryNames = 
                    Repository
                        .Categories
                        .Select(c=>c.Name)
                        .ToList();
            return Ok(categoryNames);

            // // Query Syntax
            // var categoryNames = 
            //         from category in Repository.Categories
            //         select category.Name;
            // return Ok(categoryNames);
        }
    }
}
