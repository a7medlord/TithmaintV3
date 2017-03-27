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
using Microsoft.AspNetCore.Authorization;
using Microsoft.Reporting.WebForms;

namespace CloudApp.Controllers
{
    [Authorize]
    public class QuotationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuotationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        public IActionResult GetQoutionReport(long id )
        {
           
            ReportDataSource custmertDataSource = new ReportDataSource();

            ReportDataSource instrumentsDataSource = new ReportDataSource();

            ReportDataSource reportDataSource = new ReportDataSource(); 


            // Qoution Report
            reportDataSource.Name = "ReportDataSet";
            reportDataSource.Value = _context.Quotation.Where(d=>d.Id == id);
            //Custumer Report
            custmertDataSource.Name = "CustmerDataSet";
            custmertDataSource.Value = _context.Custmer.ToList();
            //Instrument Reprot
            var instruments = _context.Instrument.Where(d => d.QuotationId == id);
            instrumentsDataSource.Name = "SupQtDataSet";
            instrumentsDataSource.Value = instruments;

            LocalReport local = new LocalReport();
            local.DataSources.Add(reportDataSource);
            local.SubreportProcessing += delegate (object sender, SubreportProcessingEventArgs args)
             {
                 args.DataSources.Add(custmertDataSource);
                 args.DataSources.Add(instrumentsDataSource);
              
             };

            local.ReportPath = "Report/QtReport.rdlc";
            local.EnableExternalImages = true;
            double amount = instruments.Sum(d => d.Amount);

            ToWord toWord = new ToWord((decimal) amount, new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));

            ReportParameter[] parameters = {
       
                new ReportParameter("num",  toWord.ConvertToArabic())
               };
            
            local.SetParameters(parameters);
        
            byte[] rendervalue = local.Render("Pdf","");

            return File(rendervalue, "application/pdf");
        }

        // GET: Quotations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Quotation.Include(q => q.Custmer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Quotations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotation.SingleOrDefaultAsync(m => m.Id == id);
            if (quotation == null)
            {
                return NotFound();
            }

            return View(quotation);
        }
        
        // GET: Quotations/Create
        public IActionResult Create()
        {
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");
            return View();
        }

        // POST: Quotations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Quotation quotation)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(quotation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", quotation.CustmerId);
            return View(quotation);
        }

        // GET: Quotations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotation.Include(quotation1 => quotation1.Instruments).SingleOrDefaultAsync(m => m.Id == id);
           
            if (quotation == null)
            {
                return NotFound();
            }
    
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", quotation.CustmerId);
            return View(quotation);
        }
        
        // POST: Quotations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind] Quotation quotation)
        {
                _context.Entry(quotation).State = EntityState.Modified;
                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction("Index");
                }
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", quotation.CustmerId);
            return View(quotation);
        }

        // GET: Quotations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotation.SingleOrDefaultAsync(m => m.Id == id);
            if (quotation == null)
            {
                return NotFound();
            }

            return View(quotation);
        }

        // POST: Quotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var quotation = await _context.Quotation.SingleOrDefaultAsync(m => m.Id == id);
            _context.Quotation.Remove(quotation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool QuotationExists(long id)
        {
            return _context.Quotation.Any(e => e.Id == id);
        }

        [HttpGet]
        public bool Delteinstrement(int id)
        {
            var data =  _context.Instrument.SingleOrDefault(instrument => instrument.Id == id);
            if (data != null)
            {
                _context.Instrument.Remove(data);
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool InsertInstremnt([Bind()] Instrument instr)
        {
            _context.Instrument.Add(instr);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }


        public bool UpdateInstremnt([Bind()] Instrument instr)
        {
            _context.Entry(instr).State = EntityState.Modified;
            if (_context.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
