﻿using System;
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
    public class hotelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public hotelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: hotels
        public async Task<IActionResult> Index()
        {
            return View(await _context.hotel.ToListAsync());
        }

        // GET: hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.hotel
                .SingleOrDefaultAsync(m => m.id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: hotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,AverageRoomRate,Restaurant24Hour,buffet")] hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.hotel.SingleOrDefaultAsync(m => m.id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: hotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,AverageRoomRate,Restaurant24Hour,buffet")] hotel hotel)
        {
            if (id != hotel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!hotelExists(hotel.id))
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
            return View(hotel);
        }

        // GET: hotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.hotel
                .SingleOrDefaultAsync(m => m.id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.hotel.SingleOrDefaultAsync(m => m.id == id);
            _context.hotel.Remove(hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool hotelExists(int id)
        {
            return _context.hotel.Any(e => e.id == id);
        }
    }
}
