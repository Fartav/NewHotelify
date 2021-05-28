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
    public class HostExtensionController : Controller
    {
        private readonly DataContext _context;

        public HostExtensionController(DataContext context)
        {
            _context = context;
        }

        // GET: HostExtension
        public async Task<IActionResult> Index()
        {
            return View(await _context.HostExtensions.ToListAsync());
        }

        // GET: HostExtension/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostExtension = await _context.HostExtensions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hostExtension == null)
            {
                return NotFound();
            }

            return View(hostExtension);
        }

        // GET: HostExtension/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HostExtension/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adress,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] HostExtension hostExtension)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hostExtension);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hostExtension);
        }

        // GET: HostExtension/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostExtension = await _context.HostExtensions.FindAsync(id);
            if (hostExtension == null)
            {
                return NotFound();
            }
            return View(hostExtension);
        }

        // POST: HostExtension/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adress,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] HostExtension hostExtension)
        {
            if (id != hostExtension.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hostExtension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostExtensionExists(hostExtension.Id))
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
            return View(hostExtension);
        }

        // GET: HostExtension/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostExtension = await _context.HostExtensions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hostExtension == null)
            {
                return NotFound();
            }

            return View(hostExtension);
        }

        // POST: HostExtension/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hostExtension = await _context.HostExtensions.FindAsync(id);
            _context.HostExtensions.Remove(hostExtension);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HostExtensionExists(int id)
        {
            return _context.HostExtensions.Any(e => e.Id == id);
        }
    }
}
