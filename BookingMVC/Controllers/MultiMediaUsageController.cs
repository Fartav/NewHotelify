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
    public class MultiMediaUsageController : Controller
    {
        private readonly DataContext _context;

        public MultiMediaUsageController(DataContext context)
        {
            _context = context;
        }

        // GET: MultiMediaUsage
        public async Task<IActionResult> Index()
        {
            return View(await _context.MultiMediaUsages.ToListAsync());
        }

        // GET: MultiMediaUsage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiMediaUsage = await _context.MultiMediaUsages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (multiMediaUsage == null)
            {
                return NotFound();
            }

            return View(multiMediaUsage);
        }

        // GET: MultiMediaUsage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MultiMediaUsage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TableId,TableName,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] MultiMediaUsage multiMediaUsage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(multiMediaUsage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(multiMediaUsage);
        }

        // GET: MultiMediaUsage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiMediaUsage = await _context.MultiMediaUsages.FindAsync(id);
            if (multiMediaUsage == null)
            {
                return NotFound();
            }
            return View(multiMediaUsage);
        }

        // POST: MultiMediaUsage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TableId,TableName,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] MultiMediaUsage multiMediaUsage)
        {
            if (id != multiMediaUsage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(multiMediaUsage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MultiMediaUsageExists(multiMediaUsage.Id))
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
            return View(multiMediaUsage);
        }

        // GET: MultiMediaUsage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiMediaUsage = await _context.MultiMediaUsages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (multiMediaUsage == null)
            {
                return NotFound();
            }

            return View(multiMediaUsage);
        }

        // POST: MultiMediaUsage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var multiMediaUsage = await _context.MultiMediaUsages.FindAsync(id);
            _context.MultiMediaUsages.Remove(multiMediaUsage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MultiMediaUsageExists(int id)
        {
            return _context.MultiMediaUsages.Any(e => e.Id == id);
        }
    }
}
