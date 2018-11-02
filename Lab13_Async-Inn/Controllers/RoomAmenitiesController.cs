using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab13_AsyncInn.Data;
using Lab13_AsyncInn.Models;

namespace Lab13_AsyncInn.Controllers
{
    public class RoomAmenitiesController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public RoomAmenitiesController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: RoomAmenities
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.RoomAmenities.Include(r => r.Amenities).Include(r => r.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: RoomAmenities/Details/5
        public async Task<IActionResult> Details(int? RoomId, int? AmenitiesId)
        {
            if (RoomId == null || AmenitiesId == null)
            {
                return NotFound();
            }

            var roomAmenities = await _context.RoomAmenities
                .Include(r => r.Amenities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => 
                    m.AmenitiesId == AmenitiesId &&
                    m.RoomId == RoomId);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        // GET: RoomAmenities/Create
        public IActionResult Create()
        {
            ViewData["AmenitiesId"] = new SelectList(_context.Amenities, "AmenitiesId", "Name");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name");
            return View();
        }

        // POST: RoomAmenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmenitiesId,RoomId")] RoomAmenities roomAmenities)
        {
            if(_context.RoomAmenities.Any(hr => hr.RoomId == roomAmenities.RoomId && hr.AmenitiesId == roomAmenities.AmenitiesId))
                ModelState.AddModelError("Name", "The combination already exists, please provide another amenities-room association");
            if (ModelState.IsValid)
            {
                _context.Add(roomAmenities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenitiesId"] = new SelectList(_context.Amenities, "AmenitiesId", "Name", roomAmenities.AmenitiesId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", roomAmenities.RoomId);
            return View(roomAmenities);
        }

        // GET: RoomAmenities/Delete/5
        public async Task<IActionResult> Delete(int? RoomId, int? AmenitiesId)
        {
            if (RoomId == null || AmenitiesId == null)
            {
                return NotFound();
            }

            var roomAmenities = await _context.RoomAmenities
                .Include(r => r.Amenities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => 
                    m.AmenitiesId == AmenitiesId &&
                    m.RoomId == RoomId);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        // POST: RoomAmenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? RoomId, int? AmenitiesId)
        {
            var roomAmenities = await _context.RoomAmenities.FindAsync(AmenitiesId, RoomId);
            _context.RoomAmenities.Remove(roomAmenities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomAmenitiesExists(int id)
        {
            return _context.RoomAmenities.Any(e => e.AmenitiesId == id);
        }
    }
}
