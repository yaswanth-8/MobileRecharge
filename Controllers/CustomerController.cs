﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileRecharge.Data;
using MobileRecharge.Models;

namespace MobileRecharge.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public CustomerController(ApplicationDbContext context,UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
              return _context.RechargeModel != null ? 
                          View(await _context.RechargeModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.RechargeModel'  is null.");
        }

        // GET: Customer/Details/5
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
        public async Task<IActionResult> Buy(int id)
        {
            // Get the current user ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            // Create a new history object with the user ID
            var history = new History();
            history.PlanId = id;
            history.CustomerId = user;
            

            // Add the history object to the database
            _context.History.Add(history);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}


/*var curUser = await _userManager.GetUserAsync(User);
History history = new History();
history.CustomerId = curUser;
history.PlanId = id;
await _context.History.AddAsync(history);*/