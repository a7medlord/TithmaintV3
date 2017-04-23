using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudApp.Data;
using CloudApp.Models.BusinessModel;
using CloudApp.Models.ManpulateModel;
using CloudApp.RepositoriesClasses;
using CloudApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

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

        private bool Comparer(Flag flag, Flag flag1)
        {
            if (flag.Value == flag1.Value)
            {
                return true;
            }
            return false;
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

        public  IActionResult Create(int ids)
        {
         GetBinding();
            var cms = _custemerRepostry.GetbyId(ids);
            ViewData["City"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.City).Distinct(Comparer), "Value", "Value");
            ViewData["Gada"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gada).Distinct(Comparer), "Value", "Value");
            ViewData["cmsname"] = cms;
            ViewData["BankId"] = new SelectList(_context.BankModel, "Id", "Name");

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
            ViewData["City"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.City).Distinct(Comparer), "Value", "Value");
            ViewData["Gada"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gada).Distinct(Comparer), "Value", "Value");
            ViewData["cmsname"] = r2Smaple.Custmer;
            ViewData["BankId"] = new SelectList(_context.BankModel, "Id", "Name");

            if (User.IsInRole("apr") || User.IsInRole("au"))
            {
                var data = GetData(r2Smaple.Id);

                ViewData["pricemap"] = data;
            }
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

        public void EditFin(long id, double partprice, long bankid, DateTime date, bool close)
        {
            var row = _context.R2Smaple.SingleOrDefault(d => d.Id == id);
            row.FinPriceClose = partprice;
            row.BankModelId = bankid;
            row.FinDateClose = date;
            row.FinPartClose = close;
            _context.Update(row);
            _context.SaveChanges();

        }

        void GetBinding()
        {
            IList<ApplicationUser> data =  _userManager.GetUsersInRoleAsync("th").Result;

            ViewData["ApplicationUserId"] = new SelectList(data.ToList(), "Id", "EmployName");
            ViewData["aqartype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Aqar).Distinct(Comparer), "Value", "Value");
            ViewData["butype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.BulsingType).Distinct(Comparer), "Value", "Value");
            ViewData["InterFaces"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Interfaces).Distinct(Comparer), "Value", "Value");
            ViewData["azltype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.AzlType).Distinct(Comparer), "Value", "Value");
            ViewData["downstair"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.DownSir).Distinct(Comparer), "Value", "Value");

        }


        public List<PriceMapModelView> FilterExpr1()
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();

            var allTrementWith1 = _context.Treatment.ToList();

            foreach (Treatment treatment in allTrementWith1)
            {
                PriceMapModelView item = new PriceMapModelView()
                {
                    TypeOfAqar = treatment.AqarType,
                    Type = 1,
                    Id = treatment.Id,
                    Area = treatment.Area,
                    Classfications = "لا يوجد",
                    PriceOfMeter = treatment.MeterPriceForBulding.ToString(),
                    SoqfPrice = treatment.TotalPriceNumber.ToString(),
                    Longtut = treatment.Longtute,
                    Latutue = treatment.Latute,
                    IconUrl = "http://maps.google.com/mapfiles/ms/icons/green-dot.png"
                };
                reslt.Add(item);
            }

            return reslt;
        }

        public List<PriceMapModelView> FilterExpr2()
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();

            var allTrementWith2 = _context.R1Smaple.ToList();

            foreach (R1Smaple treatment in allTrementWith2)
            {
                PriceMapModelView item = new PriceMapModelView()
                {
                    TypeOfAqar = treatment.AqarType,
                    Type = 2,
                    Id = treatment.Id,
                    Area = "لا يوجد",
                    Classfications = "لا يوجد",
                    PriceOfMeter = "لا يوجد",
                    SoqfPrice = "لا يوجد",
                    Longtut = treatment.Longtute,
                    Latutue = treatment.Latute,
                    IconUrl = "http://maps.google.com/mapfiles/ms/icons/green-dot.png"
                };
                reslt.Add(item);
            }

            return reslt;
        }

        public List<PriceMapModelView> FilterExpr3(long id)
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();

            var allTrementWith3 = _context.R2Smaple.Where(treatment => treatment.Id != id).ToList();

            foreach (R2Smaple treatment in allTrementWith3)
            {
                PriceMapModelView item = new PriceMapModelView()
                {
                    TypeOfAqar = treatment.AqarType,
                    Type = 3,
                    Id = treatment.Id,
                    Area = "لا يوجد",
                    Classfications = "لا يوجد",
                    PriceOfMeter = "لا يوجد",
                    SoqfPrice = "لا يوجد",
                    Longtut = treatment.Longtute,
                    Latutue = treatment.Latute,
                    IconUrl = "http://maps.google.com/mapfiles/ms/icons/green-dot.png"
                };
                reslt.Add(item);
            }

            return reslt;
        }

        List<PriceMapModelView> GetData(long id)
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();
            var data1 = FilterExpr1();
            var data2 = FilterExpr2();
            var data3 = FilterExpr3(id);

            reslt.AddRange(data1);
            reslt.AddRange(data2);
            reslt.AddRange(data3);


            return reslt;


        }
    }
}
