using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Booking.Models;

namespace BookingMVC.Controllers
{
    public class EventExtensionController : Controller
    {
        private readonly DataContext _context;

        public EventExtensionController(DataContext context)
        {
            _context = context;
        }

        // GET: EventExtension
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventExtensions.ToListAsync());
        }

        // GET: EventExtension/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventExtension = await _context.EventExtensions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventExtension == null)
            {
                return NotFound();
            }

            return View(eventExtension);
        }

        // GET: EventExtension/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventExtension/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] EventExtension eventExtension)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventExtension);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventExtension);
        }

        // GET: EventExtension/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventExtension = await _context.EventExtensions.FindAsync(id);
            if (eventExtension == null)
            {
                return NotFound();
            }
            return View(eventExtension);
        }

        // POST: EventExtension/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] EventExtension eventExtension)
        {
            if (id != eventExtension.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventExtension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExtensionExists(eventExtension.Id))
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
            return View(eventExtension);
        }

        // GET: EventExtension/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventExtension = await _context.EventExtensions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventExtension == null)
            {
                return NotFound();
            }

            return View(eventExtension);
        }

        // POST: EventExtension/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventExtension = await _context.EventExtensions.FindAsync(id);
            _context.EventExtensions.Remove(eventExtension);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExtensionExists(int id)
        {
            return _context.EventExtensions.Any(e => e.Id == id);
        }
    }
}
