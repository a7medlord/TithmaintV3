using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudApp.Data;
using CloudApp.Models.BusinessModel;

namespace CloudApp.Controllers
{
    public class R2SmapleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public R2SmapleController(ApplicationDbContext context)
        {
            _context = context;    
        }

    
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] R2Smaple r2Smaple)
        {
            if (ModelState.IsValid)
            {
                _context.Add(r2Smaple);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r2Smaple.ApplicationUserId);
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r2Smaple.CustmerId);
            return View(r2Smaple);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var r2Smaple = await _context.R2Smaple.SingleOrDefaultAsync(m => m.Id == id);
            if (r2Smaple == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r2Smaple.ApplicationUserId);
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r2Smaple.CustmerId);
            return View(r2Smaple);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind] R2Smaple r2Smaple)
        {
            if (id != r2Smaple.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(r2Smaple);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!R2SmapleExists(r2Smaple.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r2Smaple.ApplicationUserId);
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r2Smaple.CustmerId);
            return View(r2Smaple);
        }
        
       
        private bool R2SmapleExists(long id)
        {
            return _context.R2Smaple.Any(e => e.Id == id);
        }
    }
}
