using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project08_LINQ.Models.Repositpries;

namespace Project08_LINQ.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
           var products = Repository.Products.ToList();
            return Ok(products);
        }

        [HttpGet("bycategory/{categoryId}")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var result = 
                    Repository
                        .Products
                        .Where(p => p.CategoryId == categoryId)
                        .ToList();
            return Ok(result);
        }

        [HttpGet("bycategoryandsupplier")] 
        public IActionResult GetProductsByCategoryAndSupplier([FromQuery] int categoryId, [FromQuery] int supplierId) // bu yöntem query parameter yöntemi olarak bilinir.(bycategoryandsupplier?categoryId=1&supplierId=2) urlde böyle görülür
        {
            var result = 
                    Repository
                        .Products
                        .Where(p => p.CategoryId == categoryId && p.SupplierId == supplierId)   
                        .ToList();
            return Ok(result);
        }

        // Silinmemiş ürünleri getir
        [HttpGet("nondeleted")]
        public IActionResult GetNonDeleted()
        {
            var result = 
                    Repository
                    .Products
                    .Where(p => p.IsDeleted)
                    .ToList();
            return Ok(result);    
        }

        // İstediğimizde silinmiş istediğimizde silinmemiş ürünleri getir
        [HttpGet("deleted")]
        public IActionResult Get([FromQuery] bool isDeleted=false)
        {
            var result = 
                    Repository
                    .Products
                    .Where(p => p.IsDeleted == isDeleted)
                    .ToList();
            return Ok(result);   
        }

        [HttpGet("countbysupplier")]
        public IActionResult CountBySupplier()
        {
            var result = 
                    Repository
                    .Products
                    .GroupBy(p=>p.SupplierId)
                    .Select(g=>new {SupplierId=g.Key, ProductCount=g.Count()})
                    .ToList();
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            // var products = Repository
            //         .Products
            //         .Where(p => p.Id == id)
            //         .First(); // bu first sadece bir tane değer döndüreceğimiz zaman kullanılır. Idye göre ürün çektiğimiz için bir tane ürün geleceği için list yerine first kullanarak daha sağlıklı kod olmuş olur.
            // return Ok(products);
             var products = Repository
                    .Products
                    .Where(p => p.Id == id)
                    .FirstOrDefault(); // firstordefault da first gibi aynı işlemi yapar ancak tek farkı first de olamayan bir ürünü çektiğimizde hata fırlatır firstordefault da ise hata fırlatmaz boş olarak döner. yani hiç bir sey döndermez.(Daha çok bu kullanılır.)
            return Ok(products);
        }

        // Ürünlerin fiyat Ortalaması
        [HttpGet("average")]
        public IActionResult Average()
        {
            var average = Repository
                    .Products
                    .Average(p=>p.Price);
            return Ok(average);
        }

        [HttpGet("sum")]
        public IActionResult Sum()
        {
            var sum = Repository
                    .Products
                    .Sum(p=>p.Price*p.Stock);
            return Ok(new {Total = sum});
        }

    }
}
