using Microsoft.AspNetCore.Mvc;
using RockyShop.Data;
using RockyShop.Models;

namespace RockyShop.Controllers
{
    public class CategoryController : Controller
    {
        // Здесь "_applicationDbContext" является экземпляром класса ApplicationDbContext
        private readonly ApplicationDbContext _applicationDbContext;


        // Здесь создается конструктор для класса CategoryController с аргументами "ApplicationDbContext" и создается 
        // переменная "applicationDbContext" с присваиванием "_applicationDbContext". Вообще здесь переменная создается 
        //чтобы обезопасить сам класс "CategoryController" как-то так...))
        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _applicationDbContext.Category;
            return View(objList);
        }


        // This is GET - CREATE
        public IActionResult Create()
        {

            return View();
        }



        // POST - Create
        // Здесь "obj" это объект "Category" вот так вот...)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            // "_applicationDbContext" - дает доступ к базе данных
            _applicationDbContext.Category.Add(obj); // здесь мы добавляем что-то в таблицу "Category" - который находиться в базе данных
            _applicationDbContext.SaveChanges(); // Здесь мы сохраняем все что изменили
            return RedirectToAction("Index");
        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) // если "id" не найден или равен нулю...
            {
                return NotFound(); // то возвращать "Не найдено"
            }
            var obj = _applicationDbContext.Category.Find(id); // иначе находим запись по "Id" из базы данных

            if (obj == null) // опять занудная проверка - найден ли объект 
            {
                return NotFound(); // не найдено. суслик есть, но его никто не видит
            }

            return View(obj); // иначе возврат суслика
        }

        // POST - EDIT

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj) // Создаем экземпляр "Category" и именуем его "obj"
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.Category.Update(obj); // здесь "obj" - это экземпляр таблицы "Category"
                _applicationDbContext.SaveChanges(); // сохраняем изменения
                return RedirectToAction("Index"); // перенаправляем в главную страницу
            }
            return View(obj);
        }


        // GET - DELETE

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) // если "id" не найден или равен нулю...
            {
                return NotFound(); // то возвращать "Не найдено"
            }
            var obj = _applicationDbContext.Category.Find(id); // иначе находим запись по "Id" из базы данных

            if (obj == null) // опять занудная проверка - найден ли объект 
            {
                return NotFound(); // не найдено. суслик есть, но его никто не видит
            }

            return View(obj); // иначе возврат суслика
        }


        public IActionResult DeletePost(int? id)
        {
            var obj = _applicationDbContext.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _applicationDbContext.Category.Remove(obj);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }




        }

    }
}
