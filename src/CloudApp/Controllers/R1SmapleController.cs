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
    public class R1SmapleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public R1SmapleController(ApplicationDbContext context)
        {
            _context = context;    
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
               new R1Smaple(){Id = 1  ,InterfcaesEast = "ÏåÇä",InterfcaesWest= "ÏåÇä",InterfcaesSouth = "ÏåÇä",InterfcaesNorth = "ÏåÇä",MarkterRoad = "ÎÇáÏ Èä ÇáæáíÏ",Owner = "ãÍãÏ Úáí ÇáãÓÊæÑ",South = "ÔÇÑÚ 30",SouthTall = "22 ã",West = "ÔÇÑÚ 30",WestTall = "22 ã",East = "ÔÇÑÚ 30",EastTall = "22 ã",North = "ÔÇÑÚ 30",NorthTall = "22 ã",IsDonForSndElectric =true,IslAder =true ,BuldingNumber = "232444",IsDoublWall =true ,IsDoublGlass = true,BulState ="ãåÊÑÆ", AqarType = "ÝíáÇ", AqarScope = "äØÇÞ ÇáÚÞÇÑ" , Mansob = "ãáí" }


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

            //double price = treatments.Sum(d => d.TotalPriceNumber);

            //ToWord toWord = new ToWord((decimal)price, new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));
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

            //ReportParameter[] parameters = {
            //    new ReportParameter("sample",sample),
            //    new ReportParameter("custmer",custmer),
            //    new ReportParameter("muthmen", muthmenname),
            //     new ReportParameter("audit", aduitname),
            //      new ReportParameter("approver", appovename),
            //    new ReportParameter("totprice",  toWord.ConvertToArabic()),


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


            //   };

            //local.SetParameters(parameters);

            return local.Render("Pdf", "");
        }


        // GET: R1Smaple
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.R1Smaple.Include(r => r.ApplicationUser).Include(r => r.Custmer);
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
                .Include(r => r.ApplicationUser)
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");
            return View();
        }

        // POST: R1Smaple/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustmerId,City,Gada,KotatNumber,PiceNumber,BlockNumber,AqarScope,AqarType,ArchDesgin,Mansob,BulState,BuldingType,BuldinIsNull,RoadSeflt,RoadLight,AqarAge,JarIsBulding,AqaraAttachment,AttchType,TshteebType,BuldingNumber,North,South,East,West,NorthTall,SouthTall,EastTall,WestTall,Owner,MarkterRoad,InterfcaesNorth,InterfcaesSouth,InterfcaesEast,InterfcaesWest,XtrenalDoor,InnerDoor,Ahwash,Rescptions,Inner,Rooms,ArchConstract,AsqfType,AzlType,IsCetral,IsDesrt,IsWindo,IsSeprat,IsDoublWall,IsDoublGlass,IsJebsForSaqf,IsHidingLight,IsDonForSndElectric,IsKrajEletcru,IslAder,IsNormalKraj,IsGates,IsLifts,Ishoter,IsArbicTut,IsForinTut,IsElectricCount,IsWaterConut,IsElectricCountMostgl,IsWatrerCountMostgl,IsElectricServicesInGada,IsWaterServicesInGada,AqarIsMosas,ElcrictyCount,ElcrictyNumber,WatrerCount,WaterNumber,AreaEarth,MeterPriceEarh,TotalEarh,AreaQabo,MeterPriceQabo,TotalQabo,AreaDorEarth,MeterPriceDorEarth,TotalDorerath,AreaFirstDoor,MeterPriceFirstDoor,TotalFirstDoor,AreareptDoor,MeterPriceReptDoor,TotalReptDoor,AreaApnedxEarth,MeterPriceApendexErth,TotalApendxEarth,AreaApendxup,MeterPriceapendxup,Totalapendxup,AreaSwar,MeterPriceAsawr,TotalAswar,Areagarden,MeterPricegarden,Totalgarden,AreaSwimingpool,MeterPriceswiminpoo,Totalswimingpool,AreaCars,MeterPriceCars,TotalCars,AreaOthers,MeterPriceothers,Totalothers,ProfitPrecntage,AhlakPrecentage,LastTaqeem,MantinancePrice,MothmenOpnion,CountShowromms,DetlisShowRooms,EffictiveEjarShowRooms,AqarTgeemShowrooms,CountForOffice,DetlisOffice,EffictiveEjarOffice,AqarTgeemOffices,CountAprtment,DetlisApartment,EffictiveEjarApartment,AqarTgeem,TotalOfRending,IncomePrecentage,CountshowRoom,RendingCompnyShowRoom,ContractCountShowRoom,RendingTypeShowRoom,Countoffice,RendingCompnyoffice,ContractCountoffice,RendingTypeoffice,CountAprtmentfor,RendingCompnyapartment,ContractCountapartment,RendingTypeapartment,ApplicationUserId,Muthmen,Adutit,Approver,Intered,Longtute,Latute,IsIntered,IsThmin,IsAduit,IsApproved")] R1Smaple r1Smaple)
        {
            if (ModelState.IsValid)
            {
                _context.Add(r1Smaple);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r1Smaple.ApplicationUserId);
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r1Smaple.ApplicationUserId);
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r1Smaple.CustmerId);
            return View(r1Smaple);
        }

        // POST: R1Smaple/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CustmerId,City,Gada,KotatNumber,PiceNumber,BlockNumber,AqarScope,AqarType,ArchDesgin,Mansob,BulState,BuldingType,BuldinIsNull,RoadSeflt,RoadLight,AqarAge,JarIsBulding,AqaraAttachment,AttchType,TshteebType,BuldingNumber,North,South,East,West,NorthTall,SouthTall,EastTall,WestTall,Owner,MarkterRoad,InterfcaesNorth,InterfcaesSouth,InterfcaesEast,InterfcaesWest,XtrenalDoor,InnerDoor,Ahwash,Rescptions,Inner,Rooms,ArchConstract,AsqfType,AzlType,IsCetral,IsDesrt,IsWindo,IsSeprat,IsDoublWall,IsDoublGlass,IsJebsForSaqf,IsHidingLight,IsDonForSndElectric,IsKrajEletcru,IslAder,IsNormalKraj,IsGates,IsLifts,Ishoter,IsArbicTut,IsForinTut,IsElectricCount,IsWaterConut,IsElectricCountMostgl,IsWatrerCountMostgl,IsElectricServicesInGada,IsWaterServicesInGada,AqarIsMosas,ElcrictyCount,ElcrictyNumber,WatrerCount,WaterNumber,AreaEarth,MeterPriceEarh,TotalEarh,AreaQabo,MeterPriceQabo,TotalQabo,AreaDorEarth,MeterPriceDorEarth,TotalDorerath,AreaFirstDoor,MeterPriceFirstDoor,TotalFirstDoor,AreareptDoor,MeterPriceReptDoor,TotalReptDoor,AreaApnedxEarth,MeterPriceApendexErth,TotalApendxEarth,AreaApendxup,MeterPriceapendxup,Totalapendxup,AreaSwar,MeterPriceAsawr,TotalAswar,Areagarden,MeterPricegarden,Totalgarden,AreaSwimingpool,MeterPriceswiminpoo,Totalswimingpool,AreaCars,MeterPriceCars,TotalCars,AreaOthers,MeterPriceothers,Totalothers,ProfitPrecntage,AhlakPrecentage,LastTaqeem,MantinancePrice,MothmenOpnion,CountShowromms,DetlisShowRooms,EffictiveEjarShowRooms,AqarTgeemShowrooms,CountForOffice,DetlisOffice,EffictiveEjarOffice,AqarTgeemOffices,CountAprtment,DetlisApartment,EffictiveEjarApartment,AqarTgeem,TotalOfRending,IncomePrecentage,CountshowRoom,RendingCompnyShowRoom,ContractCountShowRoom,RendingTypeShowRoom,Countoffice,RendingCompnyoffice,ContractCountoffice,RendingTypeoffice,CountAprtmentfor,RendingCompnyapartment,ContractCountapartment,RendingTypeapartment,ApplicationUserId,Muthmen,Adutit,Approver,Intered,Longtute,Latute,IsIntered,IsThmin,IsAduit,IsApproved")] R1Smaple r1Smaple)
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r1Smaple.ApplicationUserId);
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
                .Include(r => r.ApplicationUser)
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
