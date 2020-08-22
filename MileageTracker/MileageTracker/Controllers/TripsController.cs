using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MileageTracker.Data;
using MileageTracker.Models;

namespace MileageTracker.Controllers
{
    public class TripsController : Controller
    {
        private readonly MTContext _context;
        private readonly UserManager<IdentityUser> _manager;
        private String _userID;

        public TripsController(MTContext context, UserManager<IdentityUser> manager)
        {
            _context = context;
            _manager = manager;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            _userID = _manager.GetUserId(HttpContext.User);
            var mTContext = _context.Trips.Where(t => t.UserGUID == _userID).Include(t => t.Project).Include(t => t.Vehicle);
            return View(await mTContext.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Project)
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.ExpenseID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects.Where(p => p.UserGUID == _userID), "ProjectID", "Name");
            ViewData["VehicleID"] = new SelectList(_context.Vehicles.Where(v => v.UserGUID == _userID), "VehicleID", "Name");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleID,Destination,BeginMileage,EndMileage,Fee,FeeDescription,ExpenseID,ProjectID,Date,Description,Amount")] Trip trip)
        {
            _userID = _manager.GetUserId(HttpContext.User);

            if (ModelState.IsValid)
            {
                trip.UserGUID = _userID;
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects.Where(p => p.UserGUID == _userID), "ProjectID", "Name", trip.ProjectID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicles.Where(v => v.UserGUID == _userID), "VehicleID", "Name", trip.VehicleID);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "Name", trip.ProjectID);
            ViewData["VehicleID"] = new SelectList(_context.Set<Vehicle>(), "VehicleID", "Name", trip.VehicleID);
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleID,Destination,BeginMileage,EndMileage,Fee,FeeDescription,ExpenseID,ProjectID,Date,Description,Amount")] Trip trip)
        {
            if (id != trip.ExpenseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.ExpenseID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "Name", trip.ProjectID);
            ViewData["VehicleID"] = new SelectList(_context.Set<Vehicle>(), "VehicleID", "Name", trip.VehicleID);
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Project)
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.ExpenseID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.ExpenseID == id);
        }
    }
}
