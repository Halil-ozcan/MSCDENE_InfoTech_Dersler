using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project06_Controllers.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly List<Product> Products=[
            new Product{Id = 1, Name = "Iphone 13",Price =40000,CategoryId=1},
            new Product{Id = 2, Name = "Kadınlar Ülkes",Price =340,CategoryId=4},
            new Product{Id = 3, Name = "L Koltuk Takımı",Price =43000,CategoryId=5}
        ];

        [HttpGet]
        public IActionResult GetAll()
        {
            if(Products.Count != 0)
            {
                return Ok(Products);
            }
            return NotFound("Hiç Bir Ürün Bulunamadı!");
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult GetAllByCategoryId(int categoryId)
        {
            List<Product> products = Products.Where(x=>x.CategoryId==categoryId).ToList();
            return Ok(products);
        }

    }
}
