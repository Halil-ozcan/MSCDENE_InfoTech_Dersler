using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project07_NorthwindManagmentAPI.Data.Repositories;

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
    }
}
