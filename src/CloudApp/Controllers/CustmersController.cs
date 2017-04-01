using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudApp.Data;
using CloudApp.Models.BusinessModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CloudApp.Controllers
{
    [Authorize]
    public class CustmersController : Controller
    {
        private readonly ApplicationDbContext _context;

        private IHostingEnvironment _env;
        public CustmersController(ApplicationDbContext context , IHostingEnvironment env)
        {
            _context = context;
            ViewData["usernames"] = AccountController.userName;
            _env = env;
        }

   
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Custmer.Include(c => c.Sample);
            return View(await applicationDbContext.ToListAsync());
        }

      
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

    
        public IActionResult Create()
        {
            ViewData["SampleId"] = new SelectList(_context.Samples, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Custmer custmer)
        {
            if (ModelState.IsValid)
            { 
                IFormFile file = Request.Form.Files[0];
                string guid = Guid.NewGuid().ToString();
                string path = "ProfileImg/" + guid+ ".jpg";
                custmer.ImgId = guid;
                await  CreatFile(path, file);
                _context.Add(custmer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SampleId"] = new SelectList(_context.Samples, "Id", "Name", custmer.SampleId);
            return View(custmer);
        }
        public async Task CreatFile(string path, IFormFile file)
        {
            var strem = new FileStream(Path.Combine(_env.WebRootPath, path), FileMode.Create);
            await file.CopyToAsync(strem);
            strem.Close();
            strem.Dispose();

        }
       
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

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind] Custmer custmer)
        {
            if (id != custmer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    IFormFile file = Request.Form.Files[0];
                    if (file.Length > 0 && file.Name == "logo")
                    {
                        string guid = Guid.NewGuid().ToString();
                        string path = "ProfileImg/" + guid + ".jpg";
                        custmer.ImgId = guid;
                        await CreatFile(path, file);
                    }
                    
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

        
        public JsonResult Delete(long? id)
        {
            _context.Remove(_context.Custmer.SingleOrDefault(custmer => custmer.Id == id));
            _context.SaveChanges();
            return Json("true");
        }
        

        private bool CustmerExists(long id)
        {
            return _context.Custmer.Any(e => e.Id == id);
        }
    }
}
