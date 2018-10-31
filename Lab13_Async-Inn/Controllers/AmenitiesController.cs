using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Controllers
{
    public class AmenitiesController : Controller
    {
        private readonly IAmenities _amenities;

        public AmenitiesController(IAmenities context)
        {
            _amenities = context;
        }

        // GET: Amenities
        public async Task<IActionResult> Index()
        {
            return View(await _amenities.GetAmenitiesAsync());
        }

        // GET: Amenities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Amenities amenities = await _amenities.GetAmenitiesById(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        // GET: Amenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmenitiesId,Name")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {
                await _amenities.CreateAmenities(amenities);
                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var amenities = await _amenities.GetAmenitiesById(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AmenitiesId,Name")] Amenities amenities)
        {
            if (id != amenities.AmenitiesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _amenities.UpdateAmenities(amenities);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_amenities.AmenitiesExists(amenities.AmenitiesId))
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
            return View(amenities);
        }

        // GET: Amenities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var amenities = await _amenities.GetAmenitiesById(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amenities = await _amenities.GetAmenitiesById(id);
            await _amenities.DeleteAmenities(amenities);
            return RedirectToAction(nameof(Index));
        }

    }
}
