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
    public class ReservedDatesController : Controller
    {
        private readonly DataContext _context;

        public ReservedDatesController(DataContext context)
        {
            _context = context;
        }

        // GET: ReservedDates
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReservedDates.ToListAsync());
        }

        // GET: ReservedDates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservedDates = await _context.ReservedDates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservedDates == null)
            {
                return NotFound();
            }

            return View(reservedDates);
        }

        // GET: ReservedDates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservedDates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,ReserveDateStart,ReserveDateEnd,ReserveDateStartTicks,ReserveDateEndTicks,Count,IsCanceled,IsFinal,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] ReservedDates reservedDates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservedDates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservedDates);
        }

        // GET: ReservedDates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservedDates = await _context.ReservedDates.FindAsync(id);
            if (reservedDates == null)
            {
                return NotFound();
            }
            return View(reservedDates);
        }

        // POST: ReservedDates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,ReserveDateStart,ReserveDateEnd,ReserveDateStartTicks,ReserveDateEndTicks,Count,IsCanceled,IsFinal,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] ReservedDates reservedDates)
        {
            if (id != reservedDates.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservedDates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservedDatesExists(reservedDates.Id))
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
            return View(reservedDates);
        }

        // GET: ReservedDates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservedDates = await _context.ReservedDates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservedDates == null)
            {
                return NotFound();
            }

            return View(reservedDates);
        }

        // POST: ReservedDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservedDates = await _context.ReservedDates.FindAsync(id);
            _context.ReservedDates.Remove(reservedDates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservedDatesExists(int id)
        {
            return _context.ReservedDates.Any(e => e.Id == id);
        }
    }
}
