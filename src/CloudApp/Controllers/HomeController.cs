using System;
using System.Collections.Generic;
using System.Linq;
using CloudApp.Data;
using CloudApp.Models.BusinessModel;
using CloudApp.Models.ManpulateModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CloudApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IHostingEnvironment _env;
        private ApplicationDbContext _contex;
        public HomeController(IHostingEnvironment env , ApplicationDbContext context)
        {
            _env = env;
            _contex = context;
        }
        
        
        public IActionResult Index()
        {
            
            return View();
        }
        
        public IActionResult Error()
        {
            return View();
        }


        public IActionResult PriceMap()
        {
           GetBindig(); 
            return View();
        }

        void GetBindig()
        {
            ViewData["Aqartypelist"] = new SelectList(_contex.Flag.Where(d => d.FlagValue == FlagsName.Aqar), "Value", "Value");
            ViewData["city"] = new SelectList(_contex.Flag.Where(d => d.FlagValue == FlagsName.City), "Value", "Value");
            ViewData["gada"] = new SelectList(_contex.Flag.Where(d => d.FlagValue == FlagsName.Gada), "Value", "Value");
        }

        [HttpPost]
        public IActionResult PriceMap(PricParameter pric)
        {
            var data = GetDataByFilter(pric);
            ViewData["data"] = data;
            GetBindig();
            return View();
        }

        List<PriceMapModelView> GetDataByFilter(PricParameter pric)
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();

            if (pric.TypeOfAqar == "الكل")
            {
              var data1 =  FilterExpr1(treatment =>treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.City == pric.City && treatment.Gada == pric.Gada);
              var data2 =  FilterExpr2(treatment => treatment.DateOfBegin >= pric.From &&
                                         treatment.DateOfBegin <= pric.To && treatment.City == pric.City &&
                                         treatment.Gada == pric.Gada);
              var data3 =  FilterExpr3(treatment => treatment.DateOfBegin >= pric.From &&
                                         treatment.DateOfBegin <= pric.To && treatment.City == pric.City &&
                                         treatment.Gada == pric.Gada);
                reslt.AddRange(data1);
                reslt.AddRange(data2);
                reslt.AddRange(data3);
            }

            if (pric.City == "الكل")
            {
            var dat1 =    FilterExpr1(treatment =>
                    treatment.Tbuild == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.Gada == pric.Gada);
              var data2 =  FilterExpr2(treatment =>
                    treatment.AqarType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.Gada == pric.Gada);

               var data3 = FilterExpr3(treatment =>
                    treatment.BuldingType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To  && treatment.Gada == pric.Gada);

                reslt.AddRange(dat1);
                reslt.AddRange(data2);
                reslt.AddRange(data3);
            }

            if (pric.Gada == "الكل")
            {
              var data1 =  FilterExpr1(treatment =>
                    treatment.Tbuild == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.City == pric.City );
              var data2 =  FilterExpr2(treatment =>
                    treatment.AqarType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.City == pric.City);
              var data3 =  FilterExpr3(treatment =>
                    treatment.BuldingType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.City == pric.City);

                reslt.AddRange(data1);
                reslt.AddRange(data2);
                reslt.AddRange(data3);
            }

            else
            {
                var data1 = FilterExpr1(treatment =>
                    treatment.Tbuild == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.City == pric.City && treatment.Gada == pric.Gada);
                var data2 = FilterExpr2(treatment =>
                    treatment.AqarType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.City == pric.City && treatment.Gada == pric.Gada);
                var data3 = FilterExpr3(treatment =>
                    treatment.BuldingType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.City == pric.City && treatment.Gada == pric.Gada);

                reslt.AddRange(data1);
                reslt.AddRange(data2);
                reslt.AddRange(data3);
            }


            return reslt;
        }

        public List<PriceMapModelView> FilterExpr1(Func<Treatment , bool> xpr1)
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();

            var allTrementWith1 = _contex.Treatment.Where(xpr1);

            foreach (Treatment treatment in allTrementWith1)
            {
                PriceMapModelView item = new PriceMapModelView()
                {
                    TypeOfAqar = treatment.Tbuild,
                    Type = 1,
                    Id = treatment.Id,
                    Area = treatment.Area,
                    Classfications = "لا يوجد",
                    PriceOfMeter = treatment.MeterPriceForBulding.ToString()
                    ,
                    SoqfPrice = treatment.TotalPriceNumber.ToString(),
                    Longtut = treatment.Longtute,
                    Latutue = treatment.Latute
                };
                reslt.Add(item);
            }

            return reslt;
        }

        public List<PriceMapModelView> FilterExpr2(Func<R1Smaple, bool> xpr1)
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();

            var allTrementWith2 = _contex.R1Smaple.Where(xpr1);

            foreach (R1Smaple treatment in allTrementWith2)
            {
                PriceMapModelView item = new PriceMapModelView()
                {
                    TypeOfAqar = treatment.AqarType,
                    Type = 2,
                    Id = treatment.Id,
                    Area = "لا يوجد",
                    Classfications = "لا يوجد",
                    PriceOfMeter = "لا يوجد"
                    ,
                    SoqfPrice = "لا يوجد",
                    Longtut = treatment.Longtute,
                    Latutue = treatment.Latute
                };
                reslt.Add(item);
            }

            return reslt;
        }

        public List<PriceMapModelView> FilterExpr3(Func<R2Smaple, bool> xpr1)
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();

            var allTrementWith3 = _contex.R2Smaple.Where(xpr1);

            foreach (R2Smaple treatment in allTrementWith3)
            {
                PriceMapModelView item = new PriceMapModelView()
                {
                    TypeOfAqar = treatment.BuldingType,
                    Type = 3,
                    Id = treatment.Id,
                    Area = "لا يوجد",
                    Classfications = "لا يوجد",
                    PriceOfMeter = "لا يوجد"
                    ,
                    SoqfPrice = "لا يوجد",
                    Longtut = treatment.Longtute,
                    Latutue = treatment.Latute
                };
                reslt.Add(item);
            }

            return reslt;
        }

    }
}
