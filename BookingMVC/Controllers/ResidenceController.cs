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
    public class ResidenceController : Controller
    {
        private readonly DataContext _context;

        public ResidenceController(DataContext context)
        {
            _context = context;
        }

        // GET: Residence
        public async Task<IActionResult> Index()
        {
            return View(await _context.Residences.ToListAsync());
        }

        // GET: Residence/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residence = await _context.Residences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (residence == null)
            {
                return NotFound();
            }

            return View(residence);
        }

        // GET: Residence/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Residence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CheckIn,CheckOut,Address,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] Residence residence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(residence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(residence);
        }

        // GET: Residence/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residence = await _context.Residences.FindAsync(id);
            if (residence == null)
            {
                return NotFound();
            }
            return View(residence);
        }

        // POST: Residence/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CheckIn,CheckOut,Address,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] Residence residence)
        {
            if (id != residence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(residence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResidenceExists(residence.Id))
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
            return View(residence);
        }

        // GET: Residence/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residence = await _context.Residences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (residence == null)
            {
                return NotFound();
            }

            return View(residence);
        }

        // POST: Residence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var residence = await _context.Residences.FindAsync(id);
            _context.Residences.Remove(residence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResidenceExists(int id)
        {
            return _context.Residences.Any(e => e.Id == id);
        }
    }
}
