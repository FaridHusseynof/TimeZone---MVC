using Microsoft.AspNetCore.Mvc;
using TimeZone.Areas.AdminPanel.ViewModels;
using TimeZone.Data;
using TimeZone.Models;

namespace TimeZone.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private TimeZoneDbContext _context { get; }
        public CategoryController(TimeZoneDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            return View(_context.categories.Where(c => !c.isDeleted));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel) {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_context.categories.Any(c => c.Name==categoryViewModel.Name))
            {
                ModelState.AddModelError("Name", "This category already exists");
                return View();
            }
            Category category = new Category
            {
                Name = categoryViewModel.Name,
            };
            await _context.categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category existCategory = _context.categories.Where(c => !c.isDeleted).FirstOrDefault(c => c.Id == id);
            if (existCategory == null)
            {
                return NotFound();
            }
            existCategory.isDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        public IActionResult Update( int ?id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category existCategory = _context.categories.Where(c => !c.isDeleted).FirstOrDefault(c => c.Id == id);
            if (existCategory == null)
            {
                return NotFound();
            }
            return View(existCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category category) {

            if (id == null)
            {
                return BadRequest();
            }
            Category existCategory = _context.categories.Where(c => !c.isDeleted).FirstOrDefault(c => c.Id == id);
            if (existCategory == null)
            {
                return NotFound();
            }
            existCategory.Name = category.Name;
            if (_context.categories.Any(c => c.Name == category.Name))
            {
                ModelState.AddModelError("Name", "Name is already exist.");
                return View();
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
