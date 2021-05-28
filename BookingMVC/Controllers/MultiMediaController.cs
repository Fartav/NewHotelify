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
    public class MultiMediaController : Controller
    {
        private readonly DataContext _context;

        public MultiMediaController(DataContext context)
        {
            _context = context;
        }

        // GET: MultiMedia
        public async Task<IActionResult> Index()
        {
            return View(await _context.MultiMedia.ToListAsync());
        }

        // GET: MultiMedia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiMedia = await _context.MultiMedia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (multiMedia == null)
            {
                return NotFound();
            }

            return View(multiMedia);
        }

        // GET: MultiMedia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MultiMedia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Path,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] MultiMedia multiMedia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(multiMedia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(multiMedia);
        }

        // GET: MultiMedia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiMedia = await _context.MultiMedia.FindAsync(id);
            if (multiMedia == null)
            {
                return NotFound();
            }
            return View(multiMedia);
        }

        // POST: MultiMedia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Path,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] MultiMedia multiMedia)
        {
            if (id != multiMedia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(multiMedia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MultiMediaExists(multiMedia.Id))
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
            return View(multiMedia);
        }

        // GET: MultiMedia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiMedia = await _context.MultiMedia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (multiMedia == null)
            {
                return NotFound();
            }

            return View(multiMedia);
        }

        // POST: MultiMedia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var multiMedia = await _context.MultiMedia.FindAsync(id);
            _context.MultiMedia.Remove(multiMedia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MultiMediaExists(int id)
        {
            return _context.MultiMedia.Any(e => e.Id == id);
        }
    }
}
