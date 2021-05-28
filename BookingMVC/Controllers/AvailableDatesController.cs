using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Booking.Models;

namespace BookingMVC.BookingMVC_Controllers_
{
    public class AvailableDatesController : Controller
    {
        private readonly DataContext _context;

        public AvailableDatesController(DataContext context)
        {
            _context = context;
        }

        // GET: AvailableDates
        public async Task<IActionResult> Index()
        {
            return View(await _context.AvailableDates.ToListAsync());
        }

        // GET: AvailableDates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableDates = await _context.AvailableDates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availableDates == null)
            {
                return NotFound();
            }

            return View(availableDates);
        }

        // GET: AvailableDates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AvailableDates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,ReserveDateStart,ReserveDateEnd,ReserveDateStartTicks,ReserveDateEndTicks,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] AvailableDates availableDates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(availableDates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(availableDates);
        }

        // GET: AvailableDates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableDates = await _context.AvailableDates.FindAsync(id);
            if (availableDates == null)
            {
                return NotFound();
            }
            return View(availableDates);
        }

        // POST: AvailableDates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label,ReserveDateStart,ReserveDateEnd,ReserveDateStartTicks,ReserveDateEndTicks,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] AvailableDates availableDates)
        {
            if (id != availableDates.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(availableDates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvailableDatesExists(availableDates.Id))
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
            return View(availableDates);
        }

        // GET: AvailableDates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableDates = await _context.AvailableDates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availableDates == null)
            {
                return NotFound();
            }

            return View(availableDates);
        }

        // POST: AvailableDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var availableDates = await _context.AvailableDates.FindAsync(id);
            _context.AvailableDates.Remove(availableDates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvailableDatesExists(int id)
        {
            return _context.AvailableDates.Any(e => e.Id == id);
        }
    }
}
