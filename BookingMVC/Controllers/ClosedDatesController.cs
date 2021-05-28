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
    public class ClosedDatesController : Controller
    {
        private readonly DataContext _context;

        public ClosedDatesController(DataContext context)
        {
            _context = context;
        }

        // GET: ClosedDates
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClosedDates.ToListAsync());
        }

        // GET: ClosedDates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var closedDates = await _context.ClosedDates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (closedDates == null)
            {
                return NotFound();
            }

            return View(closedDates);
        }

        // GET: ClosedDates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClosedDates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,Type,StartDate,EndDate,StartDateTicks,EndDateTicks,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] ClosedDates closedDates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(closedDates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(closedDates);
        }

        // GET: ClosedDates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var closedDates = await _context.ClosedDates.FindAsync(id);
            if (closedDates == null)
            {
                return NotFound();
            }
            return View(closedDates);
        }

        // POST: ClosedDates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label,Type,StartDate,EndDate,StartDateTicks,EndDateTicks,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] ClosedDates closedDates)
        {
            if (id != closedDates.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(closedDates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClosedDatesExists(closedDates.Id))
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
            return View(closedDates);
        }

        // GET: ClosedDates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var closedDates = await _context.ClosedDates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (closedDates == null)
            {
                return NotFound();
            }

            return View(closedDates);
        }

        // POST: ClosedDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var closedDates = await _context.ClosedDates.FindAsync(id);
            _context.ClosedDates.Remove(closedDates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClosedDatesExists(int id)
        {
            return _context.ClosedDates.Any(e => e.Id == id);
        }
    }
}
