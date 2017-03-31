using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudApp.Data;
using CloudApp.Models;
using CloudApp.Models.BusinessModel;
using CloudApp.Models.ManpulateModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Reporting.WebForms;

namespace CloudApp.Controllers
{
    public class TreatmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        public TreatmentsController(ApplicationDbContext context , UserManager<ApplicationUser> user)
        {
            _context = context;
            _userManager = user;
        }

        public IActionResult GetSample0Report()
        {

            //ReportDataSource custmertDataSource = new ReportDataSource();

            ReportDataSource reportDataSource = new ReportDataSource();

            //List<Treatment> treatments = new List<Treatment>(){new Treatment()
            //{Id = 434344,
            //    Owner = "ÌÇãÏ Úáí ßÈáæ",SCustmer = "Úáí ÈÇÈÇ" ,City = "ÇáÑíÇÖ" , Gada = "ÇáãáÒ",
            //    ServicesWater = true,ServicesElectrocitcs = true ,ServicesLamp = true ,ServicesPhone = true ,ServicesRoad = true,ServicesSanitation = true,
            //    SroundMosq = true ,SroundGarden = true, SroundBank = true , SroundCentralSoaq = false, SroundPoilceCenter = true ,SroundComirchalCenter = true, SroundDispensares = true , SroundFeul = true, SroundGenralSoaq = true , SroundGovermentDepartMent = true , SroundHospital = true ,SroundHotel = true , SroundRestrant = true, SroundSchools = true ,SroundSoaq = true, SroundciviliDenfencs = true ,SroundmedSecurityFacilty = true , SroundmedicalCenter = true, Sroundmedicalfacilty = true ,Sroundpartment = true,
            //    StyleBuild = "äÚã æÇäå ÇáÇÌãá", GenralLocations = "ÏÇÎá ÇáäØÇÞ" , TotalPriceNumber = 1000
            //}};

            // Qoution Report
          var  treatments= _context.Treatment.Where(d => d.Id == 20);
            reportDataSource.Name = "DataSetS0";
            reportDataSource.Value = treatments;
            ////Custumer Report
            //custmertDataSource.Name = "CustmerDataSet";
            //custmertDataSource.Value = _context.Custmer.ToList();
       



            LocalReport local = new LocalReport();
            local.DataSources.Add(reportDataSource);
            //local.SubreportProcessing += delegate (object sender, SubreportProcessingEventArgs args)
            //{
            //    args.DataSources.Add(custmertDataSource);
            //    args.DataSources.Add(instrumentsDataSource);

            //};

            local.ReportPath = "Report/Sm0Report.rdlc";
            local.EnableExternalImages = true;

            double price = treatments.Sum(d => d.TotalPriceNumber);

              ToWord toWord = new ToWord((decimal)price, new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));
            //get name
             string muthmenname=   _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Muthmen)?.EmployName;
            string aduitname = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Adutit)?.EmployName;
            string appovename = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Approver)?.EmployName;
            // get member id
            string muthmenid = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Muthmen)?.MemberId;
            string aduitid = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Adutit)?.MemberId;
            string appoveid = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Approver)?.MemberId;
            //get image sign
            string muthminsign = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Muthmen)?.SigImage;
            string auditsign = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Adutit)?.SigImage;
            string approvesign = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Approver)?.SigImage;
            //get image url
            string sigurlmuthmen = "http://" + HttpContext.Request.Host + "/ProfPic/" + muthminsign + ".jpg";
            string sigurlauditsign = "http://" + HttpContext.Request.Host + "/ProfPic/" + auditsign + ".jpg";
            string sigurlapprovesign = "http://" + HttpContext.Request.Host + "/ProfPic/" + approvesign + ".jpg";

            ReportParameter[] parameters = {
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
                new ReportParameter("earthmap",  ""),
                new ReportParameter("map", ""),
                new ReportParameter("zoommap", ""),
                new ReportParameter("images", "1,2,3,4,5,6")


               };

            local.SetParameters(parameters);

            byte[] rendervalue = local.Render("Pdf", "");

            return File(rendervalue, "application/pdf");
        }

        // GET: Treatments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Treatment.Include(t => t.Custmer).ThenInclude(d=>d.Sample);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Treatments/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatment.SingleOrDefaultAsync(m => m.Id == id);
            if (treatment == null)
            {
                return NotFound();
            }

            return View(treatment);
        }

        // GET: Treatments/Create
        public async Task<IActionResult> Create(int id)
        {
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");

            ViewData["UserId"] = new SelectList(await _userManager.GetUsersInRoleAsync("th"), "Id", "EmployName");

            Custmer cms = _context.Custmer.SingleOrDefault(custmer => custmer.Id == id);
            var sampleid = cms?.SampleId ?? 1;

            switch (sampleid)
            {
                case 1 :
                    ViewData["Aqartype"] = new SelectList(_context.Flag.Where(d=>d.FlagValue  ==FlagsName.Aqar), "Value", "Value");
                    ViewData["Gentype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gen), "Value", "Value");

                    return View(new Treatment());
                case 2:
                    return RedirectToAction("Create","R1Smaple");
                case 3:
                    return RedirectToAction("Create", "R2Smaple");
                default:
                    return View();
            } 
        }
        public IActionResult Select_custmer()
        {
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");
            return View("Models_Custmor");
        }


        // POST: Treatments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind ]Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                if (treatment.IsAduit && this.User.IsInRole("au"))
                {
                    treatment.Adutit = _userManager.GetUserId(this.User);
                }
                if (treatment.IsApproved && User.IsInRole("apr"))
                {
                    treatment.Approver = _userManager.GetUserId(this.User);
                } if (treatment.IsIntered && User.IsInRole("en"))
                {
                    treatment.Intered = _userManager.GetUserId(this.User);
                } if (treatment.IsThmin && User.IsInRole("th"))
                {
                    treatment.Muthmen = _userManager.GetUserId(this.User);
                }
                _context.Add(treatment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", new {Id=treatment.Id});
            }
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", treatment.CustmerId);
            return View("Create",treatment);
        }

        // GET: Treatments/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatment.SingleOrDefaultAsync(m => m.Id == id);
            if (treatment == null)
            {
                return NotFound();
            }
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", treatment.CustmerId);
            return View(treatment);
        }

        // POST: Treatments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind] Treatment treatment)
        {
            if (id != treatment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treatment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentExists(treatment.Id))
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
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", treatment.CustmerId);
            return View(treatment);
        }

        // GET: Treatments/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatment.SingleOrDefaultAsync(m => m.Id == id);
            if (treatment == null)
            {
                return NotFound();
            }

            return View(treatment);
        }

        // POST: Treatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var treatment = await _context.Treatment.SingleOrDefaultAsync(m => m.Id == id);
            _context.Treatment.Remove(treatment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TreatmentExists(long id)
        {
            return _context.Treatment.Any(e => e.Id == id);
        }
    }
}
