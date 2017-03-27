using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudApp.Data;
using CloudApp.Models.BusinessModel;
using Microsoft.Reporting.WebForms;

namespace CloudApp.Controllers
{
    public class R2SmapleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public R2SmapleController(ApplicationDbContext context)
        {
            _context = context;    
        }

        public IActionResult GetSample2Report()
        {

            List<R1Smaple> smaples = new List<R1Smaple>() { new R1Smaple() { Acce = true } };

            ReportDataSource reportDataSource = new ReportDataSource();

            // Qoution Report
            reportDataSource.Name = "DataSetS2";
            reportDataSource.Value = smaples;




            LocalReport local = new LocalReport();
            local.DataSources.Add(reportDataSource);
            //local.SubreportProcessing += delegate (object sender, SubreportProcessingEventArgs args)
            //{
            //    args.DataSources.Add(custmertDataSource);
            //    args.DataSources.Add(instrumentsDataSource);

            //};

            local.ReportPath = "Report/Sm2Report.rdlc";
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

        // GET: R2Smaple
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.R2Smaple.Include(r => r.Custmer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: R2Smaple/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var r2Smaple = await _context.R2Smaple
                .Include(r => r.Custmer)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (r2Smaple == null)
            {
                return NotFound();
            }

            return View(r2Smaple);
        }

        // GET: R2Smaple/Create
        public IActionResult Create()
        {
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");
            return View();
        }

        // POST: R2Smaple/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustmerId,Owner,SCustmer,SNum,DateSNum,City,Gada,Local,Street,Plane,Tbuild,Wland,ResWland,Npiece,Napartment,Area,Agbuild,OccBuild,CaseBuild,StyleBuild,IsIntered,IsThmin,IsAduit,IsApproved,ElictFire,Acce,PurpApp")] R2Smaple r2Smaple)
        {
            if (ModelState.IsValid)
            {
                _context.Add(r2Smaple);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r2Smaple.CustmerId);
            return View(r2Smaple);
        }

        // GET: R2Smaple/Edit/5
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
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r2Smaple.CustmerId);
            return View(r2Smaple);
        }

        // POST: R2Smaple/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CustmerId,Owner,SCustmer,SNum,DateSNum,City,Gada,Local,Street,Plane,Tbuild,Wland,ResWland,Npiece,Napartment,Area,Agbuild,OccBuild,CaseBuild,StyleBuild,IsIntered,IsThmin,IsAduit,IsApproved,ElictFire,Acce,PurpApp")] R2Smaple r2Smaple)
        {
            if (id != r2Smaple.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
                return RedirectToAction("Index");
            }
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r2Smaple.CustmerId);
            return View(r2Smaple);
        }

        // GET: R2Smaple/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var r2Smaple = await _context.R2Smaple
                .Include(r => r.Custmer)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (r2Smaple == null)
            {
                return NotFound();
            }

            return View(r2Smaple);
        }

        // POST: R2Smaple/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var r2Smaple = await _context.R2Smaple.SingleOrDefaultAsync(m => m.Id == id);
            _context.R2Smaple.Remove(r2Smaple);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool R2SmapleExists(long id)
        {
            return _context.R2Smaple.Any(e => e.Id == id);
        }
    }
}
