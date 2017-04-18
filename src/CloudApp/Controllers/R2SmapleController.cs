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
using CloudApp.RepositoriesClasses;
using CloudApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Reporting.WebForms;

namespace CloudApp.Controllers
{
    public class R2SmapleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _env;
        private readonly CustemerRepostry _custemerRepostry;
        private readonly SampleTreeServices _sampleTreeServices;

        public R2SmapleController(ApplicationDbContext context, UserManager<ApplicationUser> user, IHostingEnvironment env)
        {
            _context = context;
            _userManager = user;
            _env = env;
            _custemerRepostry = new CustemerRepostry(context);
            _sampleTreeServices = new SampleTreeServices(context,_custemerRepostry);
        }



        public IActionResult GetSample2Report(long id)
        {

            byte[] rendervalue = _sampleTreeServices.GetSample2ReportasStreem(id ,HttpContext,_env);

            return File(rendervalue, "application/pdf");
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
         GetBinding();
            var cms = _custemerRepostry.GetbyId(ids);
            ViewData["City"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.City), "Value", "Value");
            ViewData["Gada"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gada), "Value", "Value");
            ViewData["cmsname"] = cms;
            return View(new R2Smaple());
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] R2Smaple r2Smaple, string ids)
        {
            if (ModelState.IsValid)
            {
                r2Smaple.Id = _sampleTreeServices.GetAutoIncreesNumber(r2Smaple.DateOfBegin);
              
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
                _sampleTreeServices.CreatNewTreamnt(r2Smaple);
 
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

        public IActionResult Edit(long id)
        {
            var r2Smaple = _sampleTreeServices.GetTrementWithAttachmentFiles(id);
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

         GetBinding();
            ViewData["City"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.City), "Value", "Value");
            ViewData["Gada"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gada), "Value", "Value");
            ViewData["cmsname"] = r2Smaple.Custmer;
            return View(r2Smaple);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(long id, [Bind] R2Smaple r2Smaple , string ids)
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

                    _sampleTreeServices.UpdateExistTreament(r2Smaple);
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
                return RedirectToAction("Index", "MainSamples");
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r2Smaple.ApplicationUserId);
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r2Smaple.CustmerId);
            return View(r2Smaple);
        }

        public void  EditAprove(long id)
        {
            var row = _sampleTreeServices.GetTrementById(id);
            row.IsApproved = true;
            _sampleTreeServices.UpdateExistTreament(row);
        }
        private bool R2SmapleExists(long id)
        {
            return _context.R2Smaple.Any(e => e.Id == id);
        }

        void GetBinding()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["aqartype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Aqar), "Value", "Value");
            ViewData["butype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.BulsingType), "Value", "Value");
            ViewData["InterFaces"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Interfaces), "Value", "Value");
            ViewData["azltype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.AzlType), "Value", "Value");
            ViewData["downstair"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.DownSir), "Value", "Value");

        }
    }
}
