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

        //------ CREATE FUNCTION
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
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            else { return View(category); }
        }

        //------- EDIT FUNCTION

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var foundFromDb = _db.Categories.Find(id);

            if(foundFromDb == null)
            {
                return NotFound();
            }
            return View(foundFromDb);
        }
        //form POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["Success"] = "Category Saved Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //------- Delete FUNCTION
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var foundFromDb = _db.Categories.Find(id);

            if (foundFromDb == null)
            {
                return NotFound();
            }
            return View(foundFromDb);
        }
        //form POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            var foundFromDb = _db.Categories.Find(category.Id);
            
            if(foundFromDb == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(foundFromDb);
            _db.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";

            return RedirectToAction("Index");
        }
    }
}
