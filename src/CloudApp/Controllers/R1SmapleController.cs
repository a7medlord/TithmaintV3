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
using Microsoft.Reporting.WebForms;

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

        public IActionResult GetSample1Report(long id)
        {

            byte[] rendervalue = GetSample1ReportasStreem(id);

            return File(rendervalue, "application/pdf");
        }

        public byte[] GetSample1ReportasStreem( long id)
        {
            ReportDataSource reportDataSource = new ReportDataSource();

            //get attachment
            var rsample1 = _context.AttachmentForR1Samples.Where(d => d.R1SmapleId == id);
            string images = null;
            foreach (var r1Samples in rsample1)
            {
                images += "http://" + HttpContext.Request.Host + "/attachs2/" + r1Samples.AttachmentId + ".jpg" + ",";
            }

            // R1 Report
            var r1Sample = _context.R1Smaple.Include(d => d.Custmer).ThenInclude(s => s.Sample).Where(d => d.Id == id);
            reportDataSource.Name = "DataSetR1Sample";
            reportDataSource.Value = r1Sample;
            string sample = r1Sample.SingleOrDefault()?.Custmer.Sample.Name;
            string longtute = r1Sample.SingleOrDefault()?.Longtute;
            string latute = r1Sample.SingleOrDefault()?.Latute;
            LocalReport local = new LocalReport();
            local.DataSources.Add(reportDataSource);

            local.ReportPath = "Report/Sm1Report.rdlc";
            local.EnableExternalImages = true;

            double price = r1Sample.Sum(d => d.LastTaqeem);

            ToWord toWord = new ToWord((decimal)price, new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));
            ////get name
            string muthmenname = _context.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Muthmen)?.EmployName;
            string aduitname = _context.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Adutit)?.EmployName;
            string appovename = _context.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Approver)?.EmployName;
            // get member id
            string muthmenid = _context.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Muthmen)?.MemberId;
            string aduitid = _context.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Adutit)?.MemberId;
            string appoveid = _context.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Approver)?.MemberId;
            //get image sign
            string muthminsign = _context.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Muthmen)?.SigImage;
            string auditsign = _context.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Adutit)?.SigImage;
            string approvesign = _context.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Approver)?.SigImage;
            //get image url
            string sigurlmuthmen = "http://" + HttpContext.Request.Host + "/ProfPic/" + muthminsign + ".jpg";
            string sigurlauditsign = "http://" + HttpContext.Request.Host + "/ProfPic/" + auditsign + ".jpg";
            string sigurlapprovesign = "http://" + HttpContext.Request.Host + "/ProfPic/" + approvesign + ".jpg";

            string earthmap = Mapgen(longtute, latute, "satellite", "10", "283", "750");
            string map = Mapgen(longtute, latute, "ROADMAP", "10", "249", "739");
            string zoommap = Mapgen(longtute, latute, "satellite", "18", "265", "530");
            ReportParameter[] parameters = {
                new ReportParameter("sample",sample),
                new ReportParameter("muthmen", muthmenname),
                 new ReportParameter("audit", aduitname),
                  new ReportParameter("approver", appovename),
                new ReportParameter("totprice",  toWord.ConvertToArabic()),


                    new ReportParameter("muthminsign",  sigurlmuthmen),
                    new ReportParameter("Auditsign",  sigurlauditsign),
                    new ReportParameter("Approvesign", sigurlapprovesign),


                    new ReportParameter("idmuthmin",  muthmenid),
                    new ReportParameter("idaudit",  aduitid),
                    new ReportParameter("idapprove", appoveid),
                    new ReportParameter("earthmap",  earthmap),
                    new ReportParameter("map", map),
                    new ReportParameter("zoommap", zoommap),
                    new ReportParameter("images",images)


                   };

            local.SetParameters(parameters);

            return local.Render("Pdf", "");
        }
        public string Mapgen(string longtut, string lutit, string type, string zoom, string hight, string with)
        {
            string url = "https://maps.googleapis.com/maps/api/staticmap?center=" + longtut + "," + lutit + "&zoom=" + zoom + "&size=" + with + "x" + hight + "&maptype=" + type + "&key=AIzaSyDi_nL0Zh0BYDb5iZTndmJCr-uHjd1Pvhs";
            return url;
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

            var r1Smaple = await _context.R1Smaple.Include(smaple => smaple.AttachmentForR1Samples).Include(smaple => smaple.Custmer).SingleOrDefaultAsync(m => m.Id == id);
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
            ViewData["cmsname"] = r1Smaple.Custmer;
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
