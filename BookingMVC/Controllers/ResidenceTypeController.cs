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
    public class ResidenceTypeController : Controller
    {
        private readonly DataContext _context;

        public ResidenceTypeController(DataContext context)
        {
            _context = context;
        }

        // GET: ResidenceType
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResidenceTypes.ToListAsync());
        }

        // GET: ResidenceType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residenceType = await _context.ResidenceTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (residenceType == null)
            {
                return NotFound();
            }

            return View(residenceType);
        }

        // GET: ResidenceType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResidenceType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] ResidenceType residenceType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(residenceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(residenceType);
        }

        // GET: ResidenceType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residenceType = await _context.ResidenceTypes.FindAsync(id);
            if (residenceType == null)
            {
                return NotFound();
            }
            return View(residenceType);
        }

        // POST: ResidenceType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] ResidenceType residenceType)
        {
            if (id != residenceType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(residenceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResidenceTypeExists(residenceType.Id))
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
            return View(residenceType);
        }

        // GET: ResidenceType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residenceType = await _context.ResidenceTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (residenceType == null)
            {
                return NotFound();
            }

            return View(residenceType);
        }

        // POST: ResidenceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var residenceType = await _context.ResidenceTypes.FindAsync(id);
            _context.ResidenceTypes.Remove(residenceType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResidenceTypeExists(int id)
        {
            return _context.ResidenceTypes.Any(e => e.Id == id);
        }
    }
}
