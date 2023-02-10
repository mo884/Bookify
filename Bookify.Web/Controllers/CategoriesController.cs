
using Bookify.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //AsNoTracking() use it to select items without make any changes on it 
            var categories = _context.Categories.AsNoTracking().ToList();   
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Form");
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CategoryView category)
        {
            if(!ModelState.IsValid)
                return View("Form",category);
            var categories =new Category() { Name = category.Name};
            _context.Add(categories);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edite(int ID)
        {
            var Category = _context.Categories.Find(ID);
            if (Category is null)
                return NotFound();
            var categoryVM = new CategoryView()
            {
                ID = Category.ID,
                Name = Category.Name
            };
            return View("Form", categoryVM);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edite(CategoryView category)
        {
            if (!ModelState.IsValid)
                return View("Form", category);
            var Category = _context.Categories.Find(category.ID);
            if (Category is null)
                return NotFound();
            Category.Name = category.Name;
            Category.LastUpdatedOn = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
