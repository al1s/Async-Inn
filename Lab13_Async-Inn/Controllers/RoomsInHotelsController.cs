﻿using System;
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
    public class RoomsInHotelsController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public RoomsInHotelsController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: RoomsInHotels
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotel).Include(h => h.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: RoomsInHotels/Details/5
        public async Task<IActionResult> Details(int? HotelId, int? RoomNumber)
        {
            if (HotelId == null || RoomNumber == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => (m.HotelId == HotelId && m.RoomNumber == RoomNumber));
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // GET: RoomsInHotels/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "Name");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name");
            return View();
        }

        // POST: RoomsInHotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelId,RoomNumber,RoomId,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "Name", hotelRoom.HotelId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", hotelRoom.RoomId);
            return View(hotelRoom);
        }

        // GET: RoomsInHotels/Edit/5
        public async Task<IActionResult> Edit(int? HotelId, int? RoomNumber)
        {
            if (HotelId == null || RoomNumber == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms.FindAsync(HotelId, RoomNumber);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "Name", hotelRoom.HotelId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", hotelRoom.RoomId);
            return View(hotelRoom);
        }

        // POST: RoomsInHotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? HotelId, int? RoomNumber, [Bind("HotelId,RoomNumber,RoomId,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (HotelId != hotelRoom.HotelId || RoomNumber != hotelRoom.RoomNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.HotelId))
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
            ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "Name", hotelRoom.HotelId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", hotelRoom.RoomId);
            return View(hotelRoom);
        }

        // GET: RoomsInHotels/Delete/5
        public async Task<IActionResult> Delete(int? HotelId, int? RoomNumber)
        {
            if (HotelId == null || RoomNumber == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelId == HotelId && m.RoomNumber == RoomNumber);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: RoomsInHotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int HotelId, int RoomNumber)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(HotelId, RoomNumber);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelId == id);
        }
    }
}
