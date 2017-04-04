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
using CloudApp.Models.ManpulateModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace CloudApp.Controllers
{
    public class R2SmapleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _env;

        public R2SmapleController(ApplicationDbContext context, UserManager<ApplicationUser> user, IHostingEnvironment env)
        {
            _context = context;
            _userManager = user;
            _env = env;
        }

        [HttpPost]
        public async Task<JsonResult> UploadFile()
        {
            string guid = Guid.NewGuid().ToString();
            string filepath = "sample3attachment/" + guid + ".jpg";
            var strem = new FileStream(Path.Combine(_env.WebRootPath, filepath), FileMode.Create);
            await Request.Form.Files[0].CopyToAsync(strem);
            strem.Close();
            strem.Dispose();
            return Json(guid);
        }

        public IActionResult Create(int ids)
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            var cms = _context.Custmer.SingleOrDefault(custmer => custmer.Id == ids);
            ViewData["aqartype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Aqar), "Value", "Value");
            ViewData["desinArch"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.DesginArch), "Value", "Value");
            ViewData["Mansob"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Mansob), "Value", "Value");
            ViewData["buldingtype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.BuildingStatus), "Value", "Value");
            ViewData["butype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.BulsingType), "Value", "Value");
            ViewData["AqarScope"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.AqarScope), "Value", "Value");
            ViewData["BuldingBuzy"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.BuldingBuzy), "Value", "Value");
            ViewData["RoadSeflt"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.RoadSeflt), "Value", "Value");
            ViewData["RoadLighting"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.RoadLighting), "Value", "Value");
            ViewData["JarIsBulding"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.JarIsBulding), "Value", "Value");
            ViewData["AqarIsAttch"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.AqarIsAttch), "Value", "Value");
            ViewData["TshteebType"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.TshteebType), "Value", "Value");
            ViewData["InterFaces"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Interfaces), "Value", "Value");
            ViewData["AsqfType"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.SqfTypeAndArch), "Value", "Value");
            ViewData["azltype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.AzlType), "Value", "Value");
            ViewData["cmsname"] = cms;
            return View(new R2Smaple());
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] R2Smaple r2Smaple, string ids)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(ids))
                {
                    string[] imgsids = ids.Split(';');
                    r2Smaple.AttachmentForR2Samples = new List<AttachmentForR2Sample>();
                    for (int i = 0; i < imgsids.Length - 1; i++)
                    {
                        r2Smaple.AttachmentForR2Samples.Add(new AttachmentForR2Sample() { AttachmentId = imgsids[i] });
                    }
                }

                if (r2Smaple.IsAduit && User.IsInRole("au"))
                {
                    r2Smaple.Adutit = _userManager.GetUserId(User);
                }
                if (r2Smaple.IsApproved && User.IsInRole("apr"))
                {
                    r2Smaple.Approver = _userManager.GetUserId(User);
                }
                if (r2Smaple.IsIntered && User.IsInRole("en"))
                {
                    r2Smaple.Intered = _userManager.GetUserId(User);
                }
                if (r2Smaple.IsThmin && User.IsInRole("th"))
                {
                    r2Smaple.Muthmen = _userManager.GetUserId(User);
                }

                _context.Add(r2Smaple);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", new { id = r2Smaple.Id });
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r2Smaple.ApplicationUserId);
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r2Smaple.CustmerId);
            return View(r2Smaple);
        }

        public JsonResult RemoveFile(string name)
        {
            _context.Remove(_context.AttachmentForR2Samples.SingleOrDefault(treament => treament.AttachmentId == name));
            _context.SaveChanges();
            return Json("true");
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
            string files = "";
            foreach (AttachmentForR2Sample file in r2Smaple.AttachmentForR2Samples)
            {
                files += file.AttachmentId + ";";
            }
            ViewData["imgs"] = files;

            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r2Smaple.ApplicationUserId);
            ViewData["cmsname"] = r2Smaple.Custmer;
            return View(r2Smaple);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind] R2Smaple r2Smaple , string ids)
        {
            if (id != r2Smaple.Id)
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
                        r2Smaple.AttachmentForR2Samples = new List<AttachmentForR2Sample>();
                        for (int i = 0; i < imgsids.Length - 1; i++)
                        {
                            r2Smaple.AttachmentForR2Samples.Add(new AttachmentForR2Sample() { AttachmentId = imgsids[i] });
                        }
                    }

                    if (r2Smaple.IsAduit && User.IsInRole("au"))
                    {
                        r2Smaple.Adutit = _userManager.GetUserId(User);
                    }
                    if (r2Smaple.IsApproved && User.IsInRole("apr"))
                    {
                        r2Smaple.Approver = _userManager.GetUserId(User);
                    }
                    if (r2Smaple.IsIntered && User.IsInRole("en"))
                    {
                        r2Smaple.Intered = _userManager.GetUserId(User);
                    }
                    if (r2Smaple.IsThmin && User.IsInRole("th"))
                    {
                        r2Smaple.Muthmen = _userManager.GetUserId(User);
                    }
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
                return RedirectToAction("Index", "Treatments");
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
