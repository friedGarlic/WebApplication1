using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

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
            return View();
        }
    }
}
