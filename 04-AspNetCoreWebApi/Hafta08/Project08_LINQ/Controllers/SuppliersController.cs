using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project08_LINQ.Models;
using Project08_LINQ.Models.Repositpries;

namespace Project08_LINQ.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Getall()
        {
            var suppliers = Repository.Suppliers.ToList();
            return Ok(suppliers);
        }

        // Tedarikçilerin isimlerini listeleyin
        [HttpGet("names")]
        public IActionResult GetAllNames()
        {
            var names = 
                    Repository
                        .Suppliers
                        .Select(s=>s.CompanyName)
                        .ToList();
            return Ok(names);
        }

        // Tedarikçilerin şehirlerini listele
        [HttpGet("cities")]
        public IActionResult GetAllCities()
        {
            var cities = 
                    Repository
                    .Suppliers
                    .Select(s=>s.city)
                    .ToList();
            return Ok(cities);
        }

        // Tedarikçilerin şirket adı ve sehirlerini getirelim
        [HttpGet("namecity")]
        public IActionResult GetAllNamesAndCities()
        {
            // var result = 
            //         Repository
            //             .Suppliers
            //             .Select(s=>new {CompanyName=s.CompanyName,City=s.city})
            //             .ToList();
            var result = 
                    Repository
                        .Suppliers
                        .Select(s=>new SupplierNameCity{Sirket =s.CompanyName, Sehir=s.city})
                        .ToList();
            return Ok(result);
        }
    }
}
