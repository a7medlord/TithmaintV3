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

        public IActionResult GetSample1Report()
        {

            byte[] rendervalue = GetSample1ReportasStreem();

            return File(rendervalue, "application/pdf");
        }

        public byte[] GetSample1ReportasStreem()
        {
            ReportDataSource reportDataSource = new ReportDataSource();

            // get attachment  
            //var attament = _context.AttachmentForTreaments.Where(d => d.TreatmentId == id);
            //string images = null;
            //foreach (var attachmentForTreament in attament)
            //{
            //    images += "http://" + HttpContext.Request.Host + "/sample1attachment/" + attachmentForTreament.AttachmentId + ".jpg" + ",";
            //}

            List<R1Smaple> sample = new List<R1Smaple>()
           {
               new R1Smaple(){Id = 1  ,LastTaqeem = 455,InterfcaesEast = "ÏåÇä",InterfcaesWest= "ÏåÇä",InterfcaesSouth = "ÏåÇä",InterfcaesNorth = "ÏåÇä",MarkterRoad = "ÎÇáÏ Èä ÇáæáíÏ",Owner = "ãÍãÏ Úáí ÇáãÓÊæÑ",South = "ÔÇÑÚ 30",SouthTall = "22 ã",West = "ÔÇÑÚ 30",WestTall = "22 ã",East = "ÔÇÑÚ 30",EastTall = "22 ã",North = "ÔÇÑÚ 30",NorthTall = "22 ã",IsDonForSndElectric =true,IslAder =true ,BuldingNumber = "232444",IsDoublWall =true ,IsDoublGlass = true,BulState ="ãåÊÑÆ", AqarType = "ÝíáÇ", AqarScope = "äØÇÞ ÇáÚÞÇÑ" , Mansob = "ãáí" }


           };

            // Qoution Report
            //var treatments = _context.Treatment.Include(d => d.Custmer).ThenInclude(s => s.Sample).Where(d => d.Id == id);
            reportDataSource.Name = "DataSetR1Sample";
            reportDataSource.Value = sample;
            //string custmer = treatments.SingleOrDefault()?.Custmer.Name;
            //string sample = treatments.SingleOrDefault()?.Custmer.Sample.Name;
            LocalReport local = new LocalReport();
            local.DataSources.Add(reportDataSource);

            local.ReportPath = "Report/Sm1Report.rdlc";
            local.EnableExternalImages = true;

            double price = sample.Sum(d => d.LastTaqeem);

            ToWord toWord = new ToWord((decimal)price, new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));
            ////get name
            //string muthmenname = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Muthmen)?.EmployName;
            //string aduitname = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Adutit)?.EmployName;
            //string appovename = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Approver)?.EmployName;
            //// get member id
            //string muthmenid = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Muthmen)?.MemberId;
            //string aduitid = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Adutit)?.MemberId;
            //string appoveid = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Approver)?.MemberId;
            ////get image sign
            //string muthminsign = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Muthmen)?.SigImage;
            //string auditsign = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Adutit)?.SigImage;
            //string approvesign = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Approver)?.SigImage;
            ////get image url
            //string sigurlmuthmen = "http://" + HttpContext.Request.Host + "/ProfPic/" + muthminsign + ".jpg";
            //string sigurlauditsign = "http://" + HttpContext.Request.Host + "/ProfPic/" + auditsign + ".jpg";
            //string sigurlapprovesign = "http://" + HttpContext.Request.Host + "/ProfPic/" + approvesign + ".jpg";

            ReportParameter[] parameters = {
            //    new ReportParameter("sample",sample),
            //    new ReportParameter("custmer",custmer),
            //    new ReportParameter("muthmen", muthmenname),
            //     new ReportParameter("audit", aduitname),
            //      new ReportParameter("approver", appovename),
                new ReportParameter("totprice",  toWord.ConvertToArabic()),


                //    new ReportParameter("muthminsign",  sigurlmuthmen),
                //    new ReportParameter("Auditsign",  sigurlauditsign),
                //    new ReportParameter("Approvesign", sigurlapprovesign),


                //    new ReportParameter("idmuthmin",  muthmenid),
                //    new ReportParameter("idaudit",  aduitid),
                //    new ReportParameter("idapprove", appoveid),
                //    new ReportParameter("earthmap",  ""),
                //    new ReportParameter("map", ""),
                //    new ReportParameter("zoommap", ""),
                //    new ReportParameter("images",images)


                   };

            local.SetParameters(parameters);

            return local.Render("Pdf", "");
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
