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
    public class MultiMediaTypeController : Controller
    {
        private readonly DataContext _context;

        public MultiMediaTypeController(DataContext context)
        {
            _context = context;
        }

        // GET: MultiMediaType
        public async Task<IActionResult> Index()
        {
            return View(await _context.MultiMediaTypes.ToListAsync());
        }

        // GET: MultiMediaType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiMediaType = await _context.MultiMediaTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (multiMediaType == null)
            {
                return NotFound();
            }

            return View(multiMediaType);
        }

        // GET: MultiMediaType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MultiMediaType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] MultiMediaType multiMediaType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(multiMediaType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(multiMediaType);
        }

        // GET: MultiMediaType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiMediaType = await _context.MultiMediaTypes.FindAsync(id);
            if (multiMediaType == null)
            {
                return NotFound();
            }
            return View(multiMediaType);
        }

        // POST: MultiMediaType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] MultiMediaType multiMediaType)
        {
            if (id != multiMediaType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(multiMediaType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MultiMediaTypeExists(multiMediaType.Id))
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
            return View(multiMediaType);
        }

        // GET: MultiMediaType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiMediaType = await _context.MultiMediaTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (multiMediaType == null)
            {
                return NotFound();
            }

            return View(multiMediaType);
        }

        // POST: MultiMediaType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var multiMediaType = await _context.MultiMediaTypes.FindAsync(id);
            _context.MultiMediaTypes.Remove(multiMediaType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MultiMediaTypeExists(int id)
        {
            return _context.MultiMediaTypes.Any(e => e.Id == id);
        }
    }
}
