using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project07_NorthwindManagmentAPI.Data;
using Project07_NorthwindManagmentAPI.Data.Repositories;
using Project07_NorthwindManagmentAPI.Models;

namespace Project07_NorthwindManagmentAPI.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly NorthwindRepository _northwindRepository;

        public ProductsController(NorthwindRepository northwindRepository)
        {
            // Dependency Injection(DI)
            _northwindRepository = northwindRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _northwindRepository.GetAllProducts();
            return Ok(products);//Json Serialization işlemi otomatik yapılmaktadır.
        }

        [HttpGet("{id}")]

        public IActionResult GetProductById(int id)
        {
            var product = _northwindRepository.GetProductById(id);
            if(product == null)
            {
                return NotFound(new {ErrorMessage =$"{id} ID'li ürün bulunamadı!"});
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdProduct = _northwindRepository.AddProduct(product);
            if(createdProduct is null)
            {
                return StatusCode(500,"Ürün oluşturulurken bir sorun oluştu lütfen daha sonra deneyiniz!");
            }
            return StatusCode(201,createdProduct);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id,[FromBody] Product product)
        {
            if(id!=product.ProductID)
            {
                return BadRequest("Url!deki Id ile ürün Id'si uyuşmuyor");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingProduct = _northwindRepository.GetProductById(id);
            if(existingProduct is null)
            {
                return StatusCode(404,$"{id} ID'li ürün bulunamadığı için güncelleme başarısı oldu!");
            }
            var isUpdated = _northwindRepository.UpdateProduct(product);
            if(!isUpdated)
            {
                return StatusCode(500,"Ürün Güncellenirken bir sorun oluştu");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _northwindRepository.GetProductById(id);
            if(product is null)
            {
                return NotFound(new {Message =$"{id} ID'li ürün bulunamadığı için başarısız oldu."});
            }
            var isDeleted = _northwindRepository.DeleteProduct(id);
            if(!isDeleted)
            {
                return StatusCode(500, new{messge="Ürün Silinirken bir hata oluştu."});
            }
            return NoContent();
        }

        

    }
}
