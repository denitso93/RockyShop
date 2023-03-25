using Microsoft.AspNetCore.Mvc;
using RockyShop.Data;
using RockyShop.Models;

namespace RockyShop.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ApplicationTypeController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _applicationDbContext.ApplicationType;
            return View(objList);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE 
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ApplicationType obj)
        {
            _applicationDbContext.ApplicationType.Add(obj);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
