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
    public class ResidenceRoomController : Controller
    {
        private readonly DataContext _context;

        public ResidenceRoomController(DataContext context)
        {
            _context = context;
        }

        // GET: ResidenceRoom
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResidenceRooms.ToListAsync());
        }

        // GET: ResidenceRoom/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residenceRoom = await _context.ResidenceRooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (residenceRoom == null)
            {
                return NotFound();
            }

            return View(residenceRoom);
        }

        // GET: ResidenceRoom/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResidenceRoom/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Capacity,HasDinner,HasBreakfast,HasLunch,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] ResidenceRoom residenceRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(residenceRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(residenceRoom);
        }

        // GET: ResidenceRoom/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residenceRoom = await _context.ResidenceRooms.FindAsync(id);
            if (residenceRoom == null)
            {
                return NotFound();
            }
            return View(residenceRoom);
        }

        // POST: ResidenceRoom/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Capacity,HasDinner,HasBreakfast,HasLunch,CreateDate,ModifyDate,DeleteDate,CreateDateTicks,ModifyDateTicks,DeleteDateTicks,IsDeleted")] ResidenceRoom residenceRoom)
        {
            if (id != residenceRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(residenceRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResidenceRoomExists(residenceRoom.Id))
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
            return View(residenceRoom);
        }

        // GET: ResidenceRoom/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residenceRoom = await _context.ResidenceRooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (residenceRoom == null)
            {
                return NotFound();
            }

            return View(residenceRoom);
        }

        // POST: ResidenceRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var residenceRoom = await _context.ResidenceRooms.FindAsync(id);
            _context.ResidenceRooms.Remove(residenceRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResidenceRoomExists(int id)
        {
            return _context.ResidenceRooms.Any(e => e.Id == id);
        }
    }
}
