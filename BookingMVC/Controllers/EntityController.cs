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
    public class EntityController : Controller
    {
        private readonly DataContext _context;

        public EntityController(DataContext context)
        {
            _context = context;
        }

        // GET: Entity
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entities.ToListAsync());
        }

        // GET: Entity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entities = await _context.Entities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entities == null)
            {
                return NotFound();
            }

            return View(entities);
        }

        // GET: Entity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EntityName,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] Entities entities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entities);
        }

        // GET: Entity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entities = await _context.Entities.FindAsync(id);
            if (entities == null)
            {
                return NotFound();
            }
            return View(entities);
        }

        // POST: Entity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EntityName,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] Entities entities)
        {
            if (id != entities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntitiesExists(entities.Id))
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
            return View(entities);
        }

        // GET: Entity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entities = await _context.Entities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entities == null)
            {
                return NotFound();
            }

            return View(entities);
        }

        // POST: Entity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entities = await _context.Entities.FindAsync(id);
            _context.Entities.Remove(entities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntitiesExists(int id)
        {
            return _context.Entities.Any(e => e.Id == id);
        }
    }
}
