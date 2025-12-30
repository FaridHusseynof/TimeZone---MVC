using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TimeZone.Data;
using TimeZone.Models;
using TimeZone.ViewModel;

namespace TimeZone.Controllers
{
    public class HomeController : Controller
    {
        private TimeZoneDbContext _context { get; }
        public HomeController(TimeZoneDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            Summary summary = _context.summary.FirstOrDefault();
            List<Category> categories = _context.categories.Where(c => !c.isDeleted).ToList();
            List<Product> products = _context.products.Where(p => !p.isDeleted)
                .Include(p => p.category).Include(p => p.productImages).ToList();
            HomeViewModel home = new HomeViewModel
            {
                Products=products,
                Categories=categories,
                Summary=summary
            };
            return View(home);
        }
    }
}
