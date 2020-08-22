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
    public class ExpensesController : Controller
    {
        private readonly MTContext _context;
        private readonly UserManager<IdentityUser> _manager;
        private String _userID;

        public ExpensesController(MTContext context, UserManager<IdentityUser> manager)
        {
            _context = context;
            _manager = manager;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            _userID = _manager.GetUserId(HttpContext.User);

            var mTContext = _context.Expenses.Include(e => e.Project).Where(e => e.UserGUID == _userID);
            return View(await mTContext.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.ExpenseID == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            _userID = _manager.GetUserId(HttpContext.User);
            ViewData["ProjectID"] = new SelectList(_context.Projects.Where(p => p.UserGUID == _userID), "ProjectID", "Name");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpenseID,ProjectID,Date,Description,Amount")] Expense expense)
        {
            _userID = _manager.GetUserId(HttpContext.User);

            if (ModelState.IsValid)
            {
                expense.UserGUID = _userID;
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProjectID"] = new SelectList(_context.Projects.Where(p => p.UserGUID == _userID), "ProjectID", "Name", expense.ProjectID);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _userID = _manager.GetUserId(HttpContext.User);
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects.Where(p => p.UserGUID == _userID), "ProjectID", "Name", expense.ProjectID);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpenseID,ProjectID,Date,Description,Amount")] Expense expense)
        {
            if (id != expense.ExpenseID)
            {
                return NotFound();
            }

            _userID = _manager.GetUserId(HttpContext.User);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.ExpenseID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects.Where(p => p.UserGUID == _userID), "ProjectID", "Name", expense.ProjectID);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.ExpenseID == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.ExpenseID == id);
        }
    }
}
