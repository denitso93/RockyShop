using Microsoft.AspNetCore.Mvc;
using RockyShop.Data;
using RockyShop.Models;

namespace RockyShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Products> objList = _applicationDbContext.Products;
            

            foreach (var obj in objList)
            {
                obj.Category = _applicationDbContext.Category.FirstOrDefault(u => u.Id == obj.CategoryId);
            };

            return View(objList);

        }


    }
}
