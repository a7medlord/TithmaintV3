using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudApp.Data;
using CloudApp.Models;
using CloudApp.Models.BusinessModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace CloudApp.Controllers
{
    public class R1SmapleController : Controller
    {
        private readonly ApplicationDbContext _context;

        private UserManager<ApplicationUser> _userManager;

        private IHostingEnvironment _env;

        public R1SmapleController(ApplicationDbContext context , UserManager<ApplicationUser> usermanger , IHostingEnvironment env)
        {
            _context = context;
            _userManager = usermanger;
            _env = env;
        }
        
      
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");
            return View(new R1Smaple());
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] R1Smaple r1Smaple , string ids)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(ids))
                {
                    string[] imgsids = ids.Split(';');
                    r1Smaple.AttachmentForR1Samples= new List<AttachmentForR1Sample>();
                    for (int i = 0; i < imgsids.Length - 1; i++)
                    {
                        r1Smaple.AttachmentForR1Samples.Add(new AttachmentForR1Sample() { AttachmentId = imgsids[i] });
                    }
                }

                if (r1Smaple.IsAduit && User.IsInRole("au"))
                {
                    r1Smaple.Adutit = _userManager.GetUserId(User);
                }
                if (r1Smaple.IsApproved && User.IsInRole("apr"))
                {
                    r1Smaple.Approver = _userManager.GetUserId(User);
                }
                if (r1Smaple.IsIntered && User.IsInRole("en"))
                {
                    r1Smaple.Intered = _userManager.GetUserId(User);
                }
                if (r1Smaple.IsThmin && User.IsInRole("th"))
                {
                    r1Smaple.Muthmen = _userManager.GetUserId(User);
                }

                _context.Add(r1Smaple);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit" , new {id= r1Smaple.Id});
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r1Smaple.ApplicationUserId);
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r1Smaple.CustmerId);
            return View(r1Smaple);
        }

        public JsonResult RemoveFile(string name)
        {
            _context.Remove(_context.AttachmentForR1Samples.SingleOrDefault(treament => treament.AttachmentId == name));
            _context.SaveChanges();
            return Json("true");
        }

        [HttpPost]
        public async Task<JsonResult> UploadFile()
        {
            string guid = Guid.NewGuid().ToString();
            string filepath = "sample2attachment/" + guid + ".jpg";
            var strem = new FileStream(Path.Combine(_env.WebRootPath, filepath), FileMode.Create);
            await Request.Form.Files[0].CopyToAsync(strem);
            strem.Close();
            strem.Dispose();
            return Json(guid);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var r1Smaple = await _context.R1Smaple.Include(smaple => smaple.AttachmentForR1Samples).SingleOrDefaultAsync(m => m.Id == id);
            if (r1Smaple == null)
            {
                return NotFound();
            }

            string files = "";
            foreach (AttachmentForR1Sample file in r1Smaple.AttachmentForR1Samples)
            {
                files += file.AttachmentId + ";";
            }
            ViewData["imgs"] = files;

            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r1Smaple.ApplicationUserId);
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r1Smaple.CustmerId);
            return View(r1Smaple);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind] R1Smaple r1Smaple , string ids)
        {
            if (id != r1Smaple.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(ids))
                    {
                        string[] imgsids = ids.Split(';');
                        r1Smaple.AttachmentForR1Samples = new List<AttachmentForR1Sample>();
                        for (int i = 0; i < imgsids.Length - 1; i++)
                        {
                            r1Smaple.AttachmentForR1Samples.Add(new AttachmentForR1Sample() { AttachmentId = imgsids[i] });
                        }
                    }

                    if (r1Smaple.IsAduit && User.IsInRole("au"))
                    {
                        r1Smaple.Adutit = _userManager.GetUserId(User);
                    }
                    if (r1Smaple.IsApproved && User.IsInRole("apr"))
                    {
                        r1Smaple.Approver = _userManager.GetUserId(User);
                    }
                    if (r1Smaple.IsIntered && User.IsInRole("en"))
                    {
                        r1Smaple.Intered = _userManager.GetUserId(User);
                    }
                    if (r1Smaple.IsThmin && User.IsInRole("th"))
                    {
                        r1Smaple.Muthmen = _userManager.GetUserId(User);
                    }
                    _context.Update(r1Smaple);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!R1SmapleExists(r1Smaple.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index" , "Treatments");
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r1Smaple.ApplicationUserId);
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r1Smaple.CustmerId);
            return View(r1Smaple);
        }

      

        private bool R1SmapleExists(long id)
        {
            return _context.R1Smaple.Any(e => e.Id == id);
        }
    }
}
