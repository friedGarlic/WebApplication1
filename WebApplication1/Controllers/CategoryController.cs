using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        public readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            IEnumerable<Category> returnDB = _db.Categories;
            return View(returnDB);
        }

        public IActionResult Create()
        {
            return View();
        }
        //form POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else { return View(category); }
        }
    }
}
