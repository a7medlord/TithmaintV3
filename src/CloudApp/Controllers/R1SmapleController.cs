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
    public class R1SmapleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public R1SmapleController(ApplicationDbContext context)
        {
            _context = context;    
        }

        public IActionResult GetSample1Report()
        {

            List<R1Smaple> smaples= new List<R1Smaple>(){new R1Smaple(){Acce = true}};

            ReportDataSource reportDataSource = new ReportDataSource();

            // Qoution Report
            reportDataSource.Name = "DataSetS1";
            reportDataSource.Value = smaples;




            LocalReport local = new LocalReport();
            local.DataSources.Add(reportDataSource);
            //local.SubreportProcessing += delegate (object sender, SubreportProcessingEventArgs args)
            //{
            //    args.DataSources.Add(custmertDataSource);
            //    args.DataSources.Add(instrumentsDataSource);

            //};

            local.ReportPath = "Report/Sm1Report.rdlc";
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

        // GET: R1Smaple
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.R1Smaple.Include(r => r.Custmer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: R1Smaple/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var r1Smaple = await _context.R1Smaple
                .Include(r => r.Custmer)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (r1Smaple == null)
            {
                return NotFound();
            }

            return View(r1Smaple);
        }

        // GET: R1Smaple/Create
        public IActionResult Create()
        {
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");
            return View();
        }

        // POST: R1Smaple/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustmerId,Owner,SCustmer,SNum,DateSNum,City,Gada,Local,Street,Plane,Tbuild,Wland,ResWland,Npiece,Napartment,Area,Agbuild,OccBuild,CaseBuild,StyleBuild,IsIntered,IsThmin,IsAduit,IsApproved,ElictFire,Acce")] R1Smaple r1Smaple)
        {
            if (ModelState.IsValid)
            {
                _context.Add(r1Smaple);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r1Smaple.CustmerId);
            return View(r1Smaple);
        }

        // GET: R1Smaple/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var r1Smaple = await _context.R1Smaple.SingleOrDefaultAsync(m => m.Id == id);
            if (r1Smaple == null)
            {
                return NotFound();
            }
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r1Smaple.CustmerId);
            return View(r1Smaple);
        }

        // POST: R1Smaple/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CustmerId,Owner,SCustmer,SNum,DateSNum,City,Gada,Local,Street,Plane,Tbuild,Wland,ResWland,Npiece,Napartment,Area,Agbuild,OccBuild,CaseBuild,StyleBuild,IsIntered,IsThmin,IsAduit,IsApproved,ElictFire,Acce")] R1Smaple r1Smaple)
        {
            if (id != r1Smaple.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
                return RedirectToAction("Index");
            }
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r1Smaple.CustmerId);
            return View(r1Smaple);
        }

        // GET: R1Smaple/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var r1Smaple = await _context.R1Smaple
                .Include(r => r.Custmer)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (r1Smaple == null)
            {
                return NotFound();
            }

            return View(r1Smaple);
        }

        // POST: R1Smaple/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var r1Smaple = await _context.R1Smaple.SingleOrDefaultAsync(m => m.Id == id);
            _context.R1Smaple.Remove(r1Smaple);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool R1SmapleExists(long id)
        {
            return _context.R1Smaple.Any(e => e.Id == id);
        }
    }
}