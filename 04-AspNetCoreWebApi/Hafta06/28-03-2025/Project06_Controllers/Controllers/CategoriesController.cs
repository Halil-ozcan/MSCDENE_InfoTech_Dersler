using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project06_Controllers.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private List<Category> Categories = [
           new Category {Id=1, Name="Telefon", Description="Telefon Kategorisi"},
           new Category {Id=2, Name="Bilgisayar", Description="Bilgisayar Kategorisi"},
           new Category {Id=3, Name="Elektornik", Description="Elektornik Kategorisi"},
           new Category {Id=4, Name="Oyuncak", Description="Oyuncak Kategorisi"},
           new Category {Id=5, Name="Mobilya", Description="Mobilya Kategorisi"}
        ];

        [HttpGet]
        public IActionResult GetCategories()
        {
           List<Category> categories = Categories;
           if(categories.Count != 0)
           {
                return Ok(categories);
           }
           return NotFound("Veri Tabanında hiç kategori bulunamadı!");
        }

        // [HttpGet]
        // [Route("{categoryId}")]
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            Category category = null!;
            foreach (Category c in Categories)
            {
                if(c.Id == id)
                {
                    category = new Category{
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description
                    };
                    break;
                }
            }
            if(category == null)
            {
                return NotFound("Aradığınız Kategori Bulunamadı");
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            Categories.Add(category);
            return Ok("Kayıt İşlemi Başarılı bir şekilde oluştu");
        }        
    }
}


// Swagger ile çalışıyorsak (ki biz böyle çalışacağız), her metodun tipini mutlaka belirtmeliyiz.
        // Http metotlarının en çok kullanılanları şunlardır:
        //HttpGet: Sunucudan veri almak için kullanılır.
        //HttpPost: Sunucudaki kaynaklara Yeni veri eklemek için kullanılır.
        //HttpPut: Sunucudaki kaynaklardan istediğimizi Güncellemek için kullanılır.
        //HttpDelete: Sunucudaki kaynaklardan istediğimizi Silmek için kullanılır.

        // Her isteğin hangi adresten yapılacağı bilinmelidir, bu adreslere ENDPOINT diyoruz.
        
        // [HttpGet]   
        // public string HelloWord()
        // {
        //     return "Hello Word";
        // }
        // [HttpPost]
        // public string Register()
        // {
        //     return "Register is Ok!";
        // }