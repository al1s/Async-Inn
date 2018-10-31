using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab13_AsyncInn.Data;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Interfaces;

namespace Lab13_AsyncInn.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoom _rooms;
        private readonly ILayout _layout;

        public RoomsController(IRoom context, ILayout layout)
        {
            _rooms = context;
            _layout = layout;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var rooms = await _rooms.GetRoomAsync(); 
            return View(rooms);
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _rooms.GetRoomById(id); 
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public async Task<IActionResult> Create()
        {
            ViewData["LayoutId"] = new SelectList(await _layout.GetLayoutAsync(), "LayoutId", "Name");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,Name,LayoutId")] Room room)
        {
            if (ModelState.IsValid)
            {
                await _rooms.CreateRoom(room);
                return RedirectToAction(nameof(Index));
            }
            ViewData["LayoutId"] = new SelectList(await _layout.GetLayoutAsync(), "LayoutId", "Name", room.LayoutId);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _rooms.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["LayoutId"] = new SelectList(await _layout.GetLayoutAsync(), "LayoutId", "Name", room.LayoutId);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,Name,LayoutId")] Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _rooms.UpdateRoom(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_rooms.RoomExists(room.RoomId))
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
            ViewData["LayoutId"] = new SelectList(await _layout.GetLayoutAsync(), "LayoutId", "Name", room.LayoutId);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _rooms.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _rooms.GetRoomById(id);
            await _rooms.DeleteRoom(room);
            return RedirectToAction(nameof(Index));
        }

    }
}
