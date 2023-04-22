using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileRecharge.Data;
using MobileRecharge.Models;
using MobileRecharge.Utilities;

namespace MobileRecharge.Controllers
{
    [Authorize(Roles =SD.Role_Admin)]
    public class RechargeModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RechargeModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RechargeModels
        public async Task<IActionResult> Index()
        {
              return _context.RechargeModel != null ? 
                          View(await _context.RechargeModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.RechargeModel'  is null.");
        }

        // GET: RechargeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RechargeModel == null)
            {
                return NotFound();
            }

            var rechargeModel = await _context.RechargeModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rechargeModel == null)
            {
                return NotFound();
            }

            return View(rechargeModel);
        }

        // GET: RechargeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RechargeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlanName,Price,Description")] RechargeModel rechargeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rechargeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rechargeModel);
        }

        // GET: RechargeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RechargeModel == null)
            {
                return NotFound();
            }

            var rechargeModel = await _context.RechargeModel.FindAsync(id);
            if (rechargeModel == null)
            {
                return NotFound();
            }
            return View(rechargeModel);
        }

        // POST: RechargeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlanName,Price,Description")] RechargeModel rechargeModel)
        {
            if (id != rechargeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rechargeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RechargeModelExists(rechargeModel.Id))
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
            return View(rechargeModel);
        }

        // GET: RechargeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RechargeModel == null)
            {
                return NotFound();
            }

            var rechargeModel = await _context.RechargeModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rechargeModel == null)
            {
                return NotFound();
            }

            return View(rechargeModel);
        }

        // POST: RechargeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RechargeModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RechargeModel'  is null.");
            }
            var rechargeModel = await _context.RechargeModel.FindAsync(id);
            if (rechargeModel != null)
            {
                _context.RechargeModel.Remove(rechargeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RechargeModelExists(int id)
        {
          return (_context.RechargeModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
