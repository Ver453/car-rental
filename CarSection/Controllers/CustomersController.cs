using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarSection.Data;
using CarSection.Models;

namespace CarSection.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Customers.Include(c => c.City).Include(c => c.Country);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.City)
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        //public IActionResult List()
        //{
        //    List<Customer> customers = _context.Customers
        //    .Include(c => c.Country)
        //    .Include(cy => cy.City)
        //    .ToList();
        //    return View(customers);
        //}
        private List<SelectListItem> GetCountries()
        {
            var lstCountries = new List<SelectListItem>();
            List<Country> Countries = _context.Countries.ToList();
            lstCountries = Countries.Select(ct => new SelectListItem()
            {
                Value = ct.Id.ToString(),
                Text = ct.CountryName
            }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Country----"
            };
            lstCountries.Insert(0, defItem);
            return lstCountries;
        }

        //List country private
        private List<SelectListItem> GetCities(int countryId = 1)
        {
            List<SelectListItem> cities = _context.Cities
                .Where(c => c.CountryId == countryId)
                .OrderBy(n => n.CityName)
                .Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.CityName
                }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select City----"
            };
            cities.Insert(0, defItem);
            return cities;
        }

        // GET: Customers/Create
        [HttpGet]
        public IActionResult Create()
        {
            Customer Customer = new Customer();
            ViewBag.CountryId = GetCountries();
            ViewBag.CityId = GetCities();
            //ViewData["CityId"] = new SelectList(_context.Cities, "GetCities");
            //ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "CountryName");
            return View(Customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Customer customer)/*[Bind("Id,Name,Email,CountryId,CityId")]*/
        {
            _context.Add(customer);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "CityName", customer.CityId);
            //ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "CountryName", customer.CountryId);
            //return View(customer);
        }

        [HttpGet]
        public JsonResult GetCitiesByCountry(int countryId)
        {
            List<SelectListItem> cities = GetCities(countryId);
            return Json(cities);
        }

        // GET: Customers/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Customers == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.Customers.FindAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", customer.CityId);
        //    ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", customer.CountryId);
        //    return View(customer);
        //}

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,CountryId,CityId")] Customer customer)
        //{
        //    if (id != customer.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(customer);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CustomerExists(customer.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", customer.CityId);
        //    ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", customer.CountryId);
        //    return View(customer);
        //}

        // GET: Customers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Customers == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.Customers
        //        .Include(c => c.City)
        //        .Include(c => c.Country)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customer);
        //}

        // POST: Customers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Customers == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
        //    }
        //    var customer = await _context.Customers.FindAsync(id);
        //    if (customer != null)
        //    {
        //        _context.Customers.Remove(customer);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CustomerExists(int id)
        //{
        //  return _context.Customers.Any(e => e.Id == id);
        //}
    }
}
