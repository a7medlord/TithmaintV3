using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudApp.Data;
using CloudApp.Models.BusinessModel;
using Microsoft.AspNetCore.Authorization;

namespace CloudApp.Controllers
{
    [Authorize]
    public class SamplesController : Controller
    {
        private readonly ApplicationDbContext _context;
        //edit 
        public SamplesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Samples
        public async Task<IActionResult> Index()
        {
            return View(await _context.Samples.ToListAsync());
        }

        // GET: Samples/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sample = await _context.Samples.SingleOrDefaultAsync(m => m.Id == id);
            if (sample == null)
            {
                return NotFound();
            }

            return View(sample);
        }

        // GET: Samples/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Samples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Sample sample)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sample);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sample);
        }

        // GET: Samples/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sample = await _context.Samples.SingleOrDefaultAsync(m => m.Id == id);
            if (sample == null)
            {
                return NotFound();
            }
            return View(sample);
        }

        // POST: Samples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] Sample sample)
        {
            if (id != sample.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sample);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SampleExists(sample.Id))
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
            return View(sample);
        }

        // GET: Samples/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sample = await _context.Samples.SingleOrDefaultAsync(m => m.Id == id);
            if (sample == null)
            {
                return NotFound();
            }

            return View(sample);
        }

        // POST: Samples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var sample = await _context.Samples.SingleOrDefaultAsync(m => m.Id == id);
            _context.Samples.Remove(sample);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SampleExists(long id)
        {
            return _context.Samples.Any(e => e.Id == id);
        }
    }
}
