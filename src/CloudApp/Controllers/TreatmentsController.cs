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
using Microsoft.Reporting.WebForms;

namespace CloudApp.Controllers
{
    public class TreatmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreatmentsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        public IActionResult GetSample0Report()
        {

            ReportDataSource custmertDataSource = new ReportDataSource();

            ReportDataSource reportDataSource = new ReportDataSource();



            // Qoution Report
            reportDataSource.Name = "ReportDataSet";
            reportDataSource.Value = _context.Treatment.ToList();
            //Custumer Report
            custmertDataSource.Name = "CustmerDataSet";
            custmertDataSource.Value = _context.Custmer.ToList();
       



            LocalReport local = new LocalReport();
            local.DataSources.Add(reportDataSource);
            //local.SubreportProcessing += delegate (object sender, SubreportProcessingEventArgs args)
            //{
            //    args.DataSources.Add(custmertDataSource);
            //    args.DataSources.Add(instrumentsDataSource);

            //};

            local.ReportPath = "Report/Sm0Report.rdlc";
            local.EnableExternalImages = true;
           // double amount = instruments.Sum(d => d.Amount);

        //    ToWord toWord = new ToWord((decimal)amount, new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));

            //ReportParameter[] parameters = {

            //    new ReportParameter("num",  toWord.ConvertToArabic())
            //   };

            //local.SetParameters(parameters);

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
        public IActionResult Create(int id)
        {
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");

            Custmer cms = _context.Custmer.SingleOrDefault(custmer => custmer.Id == id);
            var sampleid = cms?.SampleId ?? 1;

            switch (sampleid)
            {
                case 1 :
                    return View();
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
        public async Task<IActionResult> Create([Bind("Id,Agbuild,Area,CaseBuild,City,CustmerId,DateSNum,Gada,Local,Napartment,Npiece,OccBuild,Owner,Plane,ResWland,SCustmer,SNum,Street,StyleBuild,Tbuild,Wland,IsIntered,IsThmin,IsAduit,IsApproved")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> Edit(long id, [Bind("Id,Agbuild,Area,CaseBuild,City,CustmerId,DateSNum,Gada,Local,Napartment,Npiece,OccBuild,Owner,Plane,ResWland,SCustmer,SNum,Street,StyleBuild,Tbuild,Wland,IsIntered,IsThmin,IsAduit,IsApproved")] Treatment treatment)
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
