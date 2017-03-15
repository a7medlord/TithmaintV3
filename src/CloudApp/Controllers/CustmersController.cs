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
    public class CustmersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustmersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Custmers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Custmer.Include(c => c.Sample);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Custmers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custmer = await _context.Custmer.SingleOrDefaultAsync(m => m.Id == id);
            if (custmer == null)
            {
                return NotFound();
            }

            return View(custmer);
        }

        // GET: Custmers/Create
        public IActionResult Create()
        {
            ViewData["SampleId"] = new SelectList(_context.Samples, "Id", "Name");
            return View();
        }

        // POST: Custmers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Name,Phone,SampleId")] Custmer custmer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(custmer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SampleId"] = new SelectList(_context.Samples, "Id", "Name", custmer.SampleId);
            return View(custmer);
        }

        // GET: Custmers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custmer = await _context.Custmer.SingleOrDefaultAsync(m => m.Id == id);
            if (custmer == null)
            {
                return NotFound();
            }
            ViewData["SampleId"] = new SelectList(_context.Samples, "Id", "Name", custmer.SampleId);
            return View(custmer);
        }

        // POST: Custmers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Email,Name,Phone,SampleId")] Custmer custmer)
        {
            if (id != custmer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(custmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustmerExists(custmer.Id))
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
            ViewData["SampleId"] = new SelectList(_context.Samples, "Id", "Name", custmer.SampleId);
            return View(custmer);
        }

        // GET: Custmers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custmer = await _context.Custmer.SingleOrDefaultAsync(m => m.Id == id);
            if (custmer == null)
            {
                return NotFound();
            }

            return View(custmer);
        }

        // POST: Custmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var custmer = await _context.Custmer.SingleOrDefaultAsync(m => m.Id == id);
            _context.Custmer.Remove(custmer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CustmerExists(long id)
        {
            return _context.Custmer.Any(e => e.Id == id);
        }
    }
}
