using CarSection.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarSection.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewData["cardata"] = SearchString;
            var cars = from c in _context.Cars
                       select c;
            if (!String.IsNullOrEmpty(SearchString))
            {
                cars = cars.Where(c=>c.CarName.Contains(SearchString));
            }
            return View(cars);
        }
    }
}
