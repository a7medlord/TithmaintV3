using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudApp.Data;
using CloudApp.Models.BusinessModel;

namespace CloudApp.Controllers
{
    public class FlagsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlagsController(ApplicationDbContext context)
        {
            _context = context;    
        }

    
        public async Task<IActionResult> Index(long flags)
        {
            return View(await _context.Flag.Where(d=>d.FlagValue==flags).ToListAsync());
        }

       
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flag = await _context.Flag
                .SingleOrDefaultAsync(m => m.Id == id);
            if (flag == null)
            {
                return NotFound();
            }

            return View(flag);

        }

       
        public IActionResult Create(long ids )
        {
            return View(new Flag(){FlagValue = ids});
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Flag flag)
        {

            if (ModelState.IsValid)
            {

                _context.Add(flag);
   
                await _context.SaveChangesAsync();
                return RedirectToAction("Index",new{ flags = flag.FlagValue } );
            }
            return View(flag);
        }
      
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flag = await _context.Flag.SingleOrDefaultAsync(m => m.Id == id);
            if (flag == null)
            {
                return NotFound();
            }
            return View(flag);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Value,FlagValue")] Flag flag)
        {
            if (id != flag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlagExists(flag.Id))
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
            return View(flag);
        }

        
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flag = await _context.Flag
                .SingleOrDefaultAsync(m => m.Id == id);
            if (flag == null)
            {
                return NotFound();
            }

            return View(flag);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var flag = await _context.Flag.SingleOrDefaultAsync(m => m.Id == id);
            _context.Flag.Remove(flag);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FlagExists(long id)
        {
            return _context.Flag.Any(e => e.Id == id);
        }
    }
}
