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
    public class TreatmentsController : Controller
    {
        #region CtorVar

        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _env;
        private readonly SampleOneServices _service;
        private readonly CustemerRepostry _cmsrepo;

        #endregion

        public TreatmentsController(ApplicationDbContext context, UserManager<ApplicationUser> user,
            IHostingEnvironment env)
        {
            _context = context;
            _userManager = user;
            _env = env;
            _service = new SampleOneServices(context, new CustemerRepostry(context));
            _cmsrepo = new CustemerRepostry(_context);

        }

        public IActionResult GetSample0Report(long id)
        {

            byte[] rendervalue = _service.GetSample0ReportasStreem(id, HttpContext, _env);

            return File(rendervalue, "application/pdf");
        }

        [HttpPost]
        public async Task<JsonResult> UploadFile()
        {
            string guid = Guid.NewGuid().ToString();
            string filepath = "sample1attachment/" + guid + ".jpg";
            var strem = new FileStream(Path.Combine(_env.WebRootPath, filepath), FileMode.Create);
            await Request.Form.Files[0].CopyToAsync(strem);
            strem.Close();
            strem.Dispose();
            return Json(guid);
        }

        public IActionResult Create(int ids)
        {
            Custmer cms = _cmsrepo.GetbyId(ids);
            IList<ApplicationUser> data = _userManager.GetUsersInRoleAsync("th").Result;
            ViewData["UserId"] = new SelectList(data.ToList(), "Id", "EmployName");
            ViewData["Aqartype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Aqar).Distinct(Comparer), "Value",
                "Value");
          
            ViewData["City"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.City).Distinct(Comparer), "Value",
                "Value");
            ViewData["Gada"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gada).Distinct(Comparer), "Value",
                "Value");
            ViewData["cmsname"] = cms;
            
            return View(new Treatment());
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Treatment treatment, string ids)
        {

            if (ModelState.IsValid)
            {
                treatment.Id = _service.GetAutoIncreesNumber(treatment.DateOfBegin);
                treatment.BankModel = _context.BankModel.FirstOrDefault();

                    treatment.Intered = _userManager.GetUserId(User);

                _service.CreatNewTreamnt(treatment);

                return RedirectToAction("Edit", new {Id = treatment.Id});
            }
            await GetListBind(treatment.CustmerId);
            return View("Create", treatment);
        }

        async Task GetListBind(long cmsSelectId)
        {
            ViewData["CustmerId"] = new SelectList(_cmsrepo.Getall().ToList(), "Id", "Name", cmsSelectId);
            ViewData["UserId"] = new SelectList(await _userManager.GetUsersInRoleAsync("th"), "Id", "EmployName");
            ViewData["Aqartype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Aqar).Distinct(Comparer), "Value",
                "Value");
            ViewData["Gentype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gen).Distinct(Comparer), "Value",
                "Value");
        }

        public JsonResult RemoveFile(string name)
        {
            _context.Remove(_context.AttachmentForTreaments.SingleOrDefault(treament => treament.AttachmentId == name));
            _context.SaveChanges();
            return Json("true");
        }

        public async Task<IActionResult> Edit(long id)
        {
            var treatment = _service.GetTrementWithAtTreatment(id);

            if (treatment == null)
            {
                return NotFound();
            }

            string files = "";
            foreach (AttachmentForTreament file in treatment.AttachmentForTreaments)
            {
                files += file.AttachmentId + ";";
            }
            ViewData["imgs"] = files;
            await GetListBind(treatment.CustmerId);
            ViewData["City"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.City), "Value",
                "Value");
            ViewData["Gada"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gada), "Value",
                "Value");
            ViewData["cmsname"] = treatment.Custmer;
            ViewData["BankId"] = new SelectList(_context.BankModel, "Id", "Name");
            if (User.IsInRole("apr") || User.IsInRole("au"))
            {
                var data = GetData(treatment.Id);

                ViewData["pricemap"] = data;
            }
            return View(treatment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, [Bind] Treatment treatment, string ids)
        {
            if (id != treatment.Id)
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
                        treatment.AttachmentForTreaments = new List<AttachmentForTreament>();
                        for (int i = 0; i < imgsids.Length - 1; i++)
                        {
                            treatment.AttachmentForTreaments.Add(
                                new AttachmentForTreament {AttachmentId = imgsids[i]});
                        }
                    }

                    if (treatment.IsAduit)
                    {
                        if (string.IsNullOrEmpty(treatment.Adutit) && User.IsInRole("apr"))
                        {
                            treatment.Adutit = _userManager.GetUserId(User);

                        }else if (User.IsInRole("au"))
                        {
                            treatment.Adutit = _userManager.GetUserId(User);
                        }
                    }

                    if (treatment.IsApproved && User.IsInRole("apr"))
                    {
                        treatment.Approver = _userManager.GetUserId(User);
                    }

                    if (treatment.IsUnlockFin && User.IsInRole("fn"))
                    {
                    treatment.Fincial = _userManager.GetUserId(User);
                    }

                    _service.UpdateExistTreament(treatment);

                    RedirectToAction("Index", "MainSamples");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentExists(treatment.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction("Index", "MainSamples");
            }
            await GetListBind(treatment.CustmerId);
            return View(treatment);
        }

        //What is this ??? Single Respon
        public void EditAprove(long id)
        {
            var row = _service.GetTrementById(id);
            row.IsApproved = true;
            _service.UpdateExistTreament(row);
        }

        private bool TreatmentExists(long id)
        {
            return _context.Treatment.Any(e => e.Id == id);

        }


        public void EditFin(long id, double partprice, long bankid, DateTime date, bool close)
        {
            var row = _service.GetTrementById(id);
            row.FinPriceClose = partprice;
            row.BankModelId = bankid;
            row.FinDateClose = date;
            row.FinPartClose = close;
            _service.UpdateExistTreament(row);

        }



        public List<PriceMapModelView> FilterExpr1(long id)
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();

            var allTrementWith1 = _context.Treatment.Where(treatment => treatment.Id !=id).ToList();

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

        public List<PriceMapModelView> FilterExpr3()
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();

            var allTrementWith3 = _context.R2Smaple.ToList();

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
            var data1 = FilterExpr1(id);
            var data2 = FilterExpr2();
            var data3 = FilterExpr3();

            reslt.AddRange(data1);
            reslt.AddRange(data2);
            reslt.AddRange(data3);


            return reslt;


        }
    }
}