using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VacationBiddingSite.Data;
using VacationBiddingSite.Models.VacationDestinations;

namespace VacationBiddingSite.Controllers.VacationDestinations
{
    public class countriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public countriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: countries
        public async Task<IActionResult> Index()
        {
            return View(await _context.country.ToListAsync());
        }

        // GET: countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.country
                .SingleOrDefaultAsync(m => m.id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.country.SingleOrDefaultAsync(m => m.id == id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name")] country country)
        {
            if (id != country.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!countryExists(country.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.country
                .SingleOrDefaultAsync(m => m.id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await _context.country.SingleOrDefaultAsync(m => m.id == id);
            _context.country.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool countryExists(int id)
        {
            return _context.country.Any(e => e.id == id);
        }
    }
}
