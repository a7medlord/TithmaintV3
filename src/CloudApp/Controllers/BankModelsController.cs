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
    public class BankModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BankModelsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: BankModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.BankModel.ToListAsync());
        }

        // GET: BankModels/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankModel = await _context.BankModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bankModel == null)
            {
                return NotFound();
            }

            return View(bankModel);
        }

        // GET: BankModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AccountNumber")] BankModel bankModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bankModel);
        }

        // GET: BankModels/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankModel = await _context.BankModel.SingleOrDefaultAsync(m => m.Id == id);
            if (bankModel == null)
            {
                return NotFound();
            }
            return View(bankModel);
        }

        // POST: BankModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,AccountNumber")] BankModel bankModel)
        {
            if (id != bankModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankModelExists(bankModel.Id))
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
            return View(bankModel);
        }

        // GET: BankModels/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankModel = await _context.BankModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bankModel == null)
            {
                return NotFound();
            }

            return View(bankModel);
        }

        // POST: BankModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var bankModel = await _context.BankModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.BankModel.Remove(bankModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BankModelExists(long id)
        {
            return _context.BankModel.Any(e => e.Id == id);
        }
    }
}
