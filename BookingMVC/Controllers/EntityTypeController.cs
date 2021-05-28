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
    public class EntityTypeController : Controller
    {
        private readonly DataContext _context;

        public EntityTypeController(DataContext context)
        {
            _context = context;
        }

        // GET: EntityType
        public async Task<IActionResult> Index()
        {
            return View(await _context.EntityTypes.ToListAsync());
        }

        // GET: EntityType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityType = await _context.EntityTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entityType == null)
            {
                return NotFound();
            }

            return View(entityType);
        }

        // GET: EntityType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntityType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeName,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] EntityType entityType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entityType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entityType);
        }

        // GET: EntityType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityType = await _context.EntityTypes.FindAsync(id);
            if (entityType == null)
            {
                return NotFound();
            }
            return View(entityType);
        }

        // POST: EntityType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeName,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] EntityType entityType)
        {
            if (id != entityType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entityType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityTypeExists(entityType.Id))
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
            return View(entityType);
        }

        // GET: EntityType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityType = await _context.EntityTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entityType == null)
            {
                return NotFound();
            }

            return View(entityType);
        }

        // POST: EntityType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entityType = await _context.EntityTypes.FindAsync(id);
            _context.EntityTypes.Remove(entityType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityTypeExists(int id)
        {
            return _context.EntityTypes.Any(e => e.Id == id);
        }
    }
}
