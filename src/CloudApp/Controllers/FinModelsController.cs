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
using Microsoft.AspNetCore.Identity;

namespace CloudApp.Controllers
{
    public class FinModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        public FinModelsController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _userManager = user;
        }



        // GET: FinModels
        public async Task<IActionResult> GetEmployee(DateTime? date1 = null, DateTime? date2 = null , string emp=null)
        {

            ViewData["ApplicationId"] = new SelectList(_context.Users, "Id", "EmployName");
            if (!date1.HasValue)
            {
                date1 = new DateTime(1753, 1, 1);
            }

            if (!date2.HasValue)
            {
                date2 = new DateTime(9999, 1, 1);
            }
            if (string.IsNullOrEmpty(emp))
            {
                emp = _userManager.GetUserId(User);
            }
            // intering 
            ViewBag.Name = _context.Users.SingleOrDefault(d => d.Id == emp).EmployName;
            double inter = _context.Users.SingleOrDefault(d => d.Id == emp).InterPercentage;
            ViewBag.interpercen = inter * 100;
            int intercount1 = _context.Treatment.Count(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int intercount2 = _context.R1Smaple.Count(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int intercount3 = _context.R2Smaple.Count(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int intercount=  intercount1 + intercount2 + intercount3;
            ViewBag.intercount = intercount;

            double interprice1 = _context.Treatment.Where(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * inter);
            double interprice2 = _context.R1Smaple.Where(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * inter);
            double interprice3 = _context.R2Smaple.Where(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * inter);
            double interprice = interprice1 + interprice2 + interprice3;
            ViewBag.TotalInter = interprice;
            // Thminat
            int muthmincount1 = _context.Treatment.Count(d => d.Muthmen == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int muthmincount2 = _context.R1Smaple.Count(d => d.Muthmen == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int muthmincount3 = _context.R2Smaple.Count(d => d.Muthmen == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int muthmincount = muthmincount1 + muthmincount2 + muthmincount3;
            ViewBag.muthmincount = muthmincount;

            double muthminprice1 = _context.Treatment.Where(d => d.Muthmen == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.MuthminPrice);
            double muthminprice2 = _context.R1Smaple.Where(d => d.Muthmen == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.MuthminPrice);
            double muthminprice3 = _context.R2Smaple.Where(d => d.Muthmen == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.MuthminPrice);
            double muthminprice = muthminprice1 + muthminprice2 + muthminprice3;
            ViewBag.Totalmuthmin = muthminprice;
            // Aduit
            double aduit = _context.Users.SingleOrDefault(d => d.Id == emp).AduitPercentage;
            ViewBag.aduitpercen = aduit * 100;
            int aduitcount1 = _context.Treatment.Count(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int aduitcount2 = _context.R1Smaple.Count(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int aduitcount3 = _context.R2Smaple.Count(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int aduitcount = aduitcount1 + aduitcount2 + aduitcount3;
            ViewBag.aduitcount = aduitcount;
            double aduitprice1 = _context.Treatment.Where(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * aduit);
            double aduitprice2 = _context.R1Smaple.Where(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * aduit);
            double aduitprice3 = _context.R2Smaple.Where(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * aduit);
            double aduitprice = aduitprice1 + aduitprice2 + aduitprice3;
            ViewBag.Totaladuit = aduitprice;
            //aprover
            double aprove = _context.Users.SingleOrDefault(d => d.Id == emp).AproverPercentage;
            ViewBag.aprovepercen = aprove * 100;
            int aprovecount1 = _context.Treatment.Count(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int aprovecount2 = _context.R1Smaple.Count(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int aprovecount3 = _context.R2Smaple.Count(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int aprovecount = aprovecount1 + aprovecount2 + aprovecount3;
            ViewBag.aprovecount = aprovecount;
            double aproveprice1 = _context.Treatment.Where(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * aprove);
            double aproveprice2 = _context.R1Smaple.Where(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * aprove);
            double aproveprice3 = _context.R2Smaple.Where(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * aprove);

            double aproveprice = aproveprice1 + aproveprice2 + aproveprice3;
            ViewBag.Totalaprove = aproveprice;

            ViewBag.TotalCount = intercount + muthmincount + aduitcount + aprovecount;
            ViewBag.TotalPrice = interprice + muthminprice + aduitprice + aproveprice;
            List<FinModel> models = new List<FinModel>();


            foreach (var treatment in await _context.Treatment.Include(d => d.Custmer).ThenInclude(d => d.Sample).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && (d.Intered==emp ||d.Muthmen == emp || d.Adutit ==emp ||  d.Approver == emp) ).ToListAsync())
            {
                if (treatment != null)
                {
                    models.Add(new FinModel()
                    {
                        Id = treatment.Id,
                        Custmer = treatment.Custmer.Name,
                        Tbuild = treatment.Tbuild,
                        Owner = treatment.Owner,
                        DateOfBegin = treatment.DateOfBegin.ToShortDateString(),
                        Sample = treatment.Custmer.Sample.Name,
                        Place = treatment.City + " " + treatment.Gada,
                        Price = treatment.Price
                    });
                }
           
            }


            foreach (var treatment in await _context.R1Smaple.Include(d => d.Custmer).ThenInclude(d => d.Sample).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && (d.Intered == emp || d.Muthmen == emp || d.Adutit == emp || d.Approver == emp)).ToListAsync())
            {
                if (treatment != null)
                {
                    models.Add(new FinModel()
                    {
                        Id = treatment.Id,
                        Custmer = treatment.Custmer.Name,
                        Tbuild = treatment.AqarType,
                        Owner = treatment.Owner,
                        DateOfBegin = treatment.DateOfBegin.ToShortDateString(),
                        Sample = treatment.Custmer.Sample.Name,
                        Place = treatment.City + " " + treatment.Gada,
                        Price = treatment.Price
                    });
                }

            }

            foreach (var treatment in await _context.R2Smaple.Include(d => d.Custmer).ThenInclude(d => d.Sample).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && (d.Intered == emp || d.Muthmen == emp || d.Adutit == emp || d.Approver == emp)).ToListAsync())
            {
                if (treatment != null)
                {
                    models.Add(new FinModel()
                    {
                        Id = treatment.Id,
                        Custmer = treatment.Custmer.Name,
                        Tbuild = treatment.BuldingType,
                        Owner = treatment.Owner,
                        DateOfBegin = treatment.DateOfBegin.ToShortDateString(),
                        Sample = treatment.Custmer.Sample.Name,
                        Place = treatment.City + " " + treatment.Gada,
                        Price = treatment.Price
                    });
                }

            }






            return View(models);
        }




        // GET: FinModels
        public async Task<IActionResult> Index(DateTime? date1=null, DateTime? date2=null )
        {
            // init date
            if (!date1.HasValue)
            {
                date1 = new DateTime(1753, 1 , 1 );
            }

            if (!date2.HasValue)
            {
                date2 = new DateTime(9999, 1, 1);
            }


            List<FinModel> models =  new List<FinModel>();

            foreach (var treatment in await _context.Treatment.Include(d=>d.Custmer).ThenInclude(d=>d.Sample).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2).ToListAsync())
            {
                double inter = _context.Users.SingleOrDefault(d => d.Id == treatment.Intered).InterPercentage * treatment.Price ;
                double adutit = _context.Users.SingleOrDefault(d => d.Id == treatment.Adutit).AduitPercentage * treatment.Price;
                double approver = _context.Users.SingleOrDefault(d => d.Id == treatment.Approver).AproverPercentage * treatment.Price;

                models.Add(new FinModel()
             {
                   Id = treatment.Id ,Custmer = treatment.Custmer.Name , Tbuild = treatment.Tbuild , Owner = treatment.Owner , DateOfBegin = treatment.DateOfBegin.ToShortDateString()
                ,Sample = treatment.Custmer.Sample.Name,Place = treatment.City + " " + treatment.Gada , Price = treatment.Price  , Net = treatment.Price -(inter+ treatment.MuthminPrice + adutit +approver) , InterPrice = inter , MuthmnPrice = treatment.MuthminPrice, AduitPrice = adutit , AproferPrice = approver
             });
                

            }

            foreach (var treatment in await _context.R1Smaple.Include(d => d.Custmer).ThenInclude(d => d.Sample).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2).ToListAsync())
            {
                double inter = _context.Users.SingleOrDefault(d => d.Id == treatment.Intered).InterPercentage * treatment.Price;
                double adutit = _context.Users.SingleOrDefault(d => d.Id == treatment.Adutit).AduitPercentage * treatment.Price;
                double approver = _context.Users.SingleOrDefault(d => d.Id == treatment.Approver).AproverPercentage * treatment.Price;

                models.Add(new FinModel()
                {
                    Id = treatment.Id,
                    Custmer = treatment.Custmer.Name,
                    Tbuild = treatment.AqarType,
                    Owner = treatment.Owner,
                    DateOfBegin = treatment.DateOfBegin.ToShortDateString()
                    ,
                    Sample = treatment.Custmer.Sample.Name,
                    Place = treatment.City + " " + treatment.Gada,
                    Price = treatment.Price,
                    Net = treatment.Price - (inter + treatment.MuthminPrice + adutit + approver),
                    InterPrice = inter,
                    MuthmnPrice = treatment.MuthminPrice,
                    AduitPrice = adutit,
                    AproferPrice = approver
                });


            }

            foreach (var treatment in await _context.R2Smaple.Include(d => d.Custmer).ThenInclude(d => d.Sample).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2).ToListAsync())
            {
                double inter = _context.Users.SingleOrDefault(d => d.Id == treatment.Intered).InterPercentage * treatment.Price;
                double adutit = _context.Users.SingleOrDefault(d => d.Id == treatment.Adutit).AduitPercentage * treatment.Price;
                double approver = _context.Users.SingleOrDefault(d => d.Id == treatment.Approver).AproverPercentage * treatment.Price;

                models.Add(new FinModel()
                {
                    Id = treatment.Id,
                    Custmer = treatment.Custmer.Name,
                    Tbuild = treatment.BuildType,
                    Owner = treatment.Owner,
                    DateOfBegin = treatment.DateOfBegin.ToShortDateString()
                    ,
                    Sample = treatment.Custmer.Sample.Name,
                    Place = treatment.City + " " + treatment.Gada,
                    Price = treatment.Price,
                    Net = treatment.Price - (inter + treatment.MuthminPrice + adutit + approver),
                    InterPrice = inter,
                    MuthmnPrice = treatment.MuthminPrice,
                    AduitPrice = adutit,
                    AproferPrice = approver
                });


            }
            ViewBag.totalprice = models.Sum(d => d.Price);
            ViewBag.totalNet = models.Sum(d => d.Net);

            ViewBag.totalInterprice = models.Sum(d => d.InterPrice);
            ViewBag.totalMuthmnPrice = models.Sum(d => d.MuthmnPrice);
            ViewBag.totalAduitPrice = models.Sum(d => d.AduitPrice);
            ViewBag.totalAproferPrice = models.Sum(d => d.AproferPrice);

            return View( models);
        }

        // GET: FinModels/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finModel = await _context.FinModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (finModel == null)
            {
                return NotFound();
            }

            return View(finModel);
        }

        // GET: FinModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FinModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sample,Owner,Custmer,Tbuild,Place,DateOfBegin,Price,InterPrice,MuthmnPrice,AproferPrice")] FinModel finModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(finModel);
        }

        // GET: FinModels/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finModel = await _context.FinModel.SingleOrDefaultAsync(m => m.Id == id);
            if (finModel == null)
            {
                return NotFound();
            }
            return View(finModel);
        }

        // POST: FinModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Sample,Owner,Custmer,Tbuild,Place,DateOfBegin,Price,InterPrice,MuthmnPrice,AproferPrice")] FinModel finModel)
        {
            if (id != finModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinModelExists(finModel.Id))
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
            return View(finModel);
        }

        // GET: FinModels/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finModel = await _context.FinModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (finModel == null)
            {
                return NotFound();
            }

            return View(finModel);
        }

        // POST: FinModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var finModel = await _context.FinModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.FinModel.Remove(finModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FinModelExists(long id)
        {
            return _context.FinModel.Any(e => e.Id == id);
        }
    }
}
