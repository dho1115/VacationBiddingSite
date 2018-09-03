using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VacationBiddingSite.Data;
using VacationBiddingSite.Models.VacationerProfile;

namespace VacationBiddingSite.Controllers.VacationerProfile
{
    public class VacationerParametersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VacationerParametersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VacationerParameters
        public async Task<IActionResult> Index()
        {
            return View(await _context.VacationerParametersTable.ToListAsync());
        }

        // GET: VacationerParameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationerParameters = await _context.VacationerParametersTable
                .SingleOrDefaultAsync(m => m.id == id);
            if (vacationerParameters == null)
            {
                return NotFound();
            }

            return View(vacationerParameters);
        }

        // GET: VacationerParameters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VacationerParameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,PhoneNumber,email")] VacationerParameters vacationerParameters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacationerParameters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacationerParameters);
        }

        // GET: VacationerParameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationerParameters = await _context.VacationerParametersTable.SingleOrDefaultAsync(m => m.id == id);
            if (vacationerParameters == null)
            {
                return NotFound();
            }
            return View(vacationerParameters);
        }

        // POST: VacationerParameters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,LastName,PhoneNumber,email")] VacationerParameters vacationerParameters)
        {
            if (id != vacationerParameters.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacationerParameters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationerParametersExists(vacationerParameters.id))
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
            return View(vacationerParameters);
        }

        // GET: VacationerParameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationerParameters = await _context.VacationerParametersTable
                .SingleOrDefaultAsync(m => m.id == id);
            if (vacationerParameters == null)
            {
                return NotFound();
            }

            return View(vacationerParameters);
        }

        // POST: VacationerParameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacationerParameters = await _context.VacationerParametersTable.SingleOrDefaultAsync(m => m.id == id);
            _context.VacationerParametersTable.Remove(vacationerParameters);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationerParametersExists(int id)
        {
            return _context.VacationerParametersTable.Any(e => e.id == id);
        }
    }
}
