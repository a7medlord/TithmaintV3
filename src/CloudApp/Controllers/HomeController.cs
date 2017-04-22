using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using CloudApp.Data;
using CloudApp.Models;
using CloudApp.Models.ManpulateModel;
using CloudApp.Models.BusinessModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CloudApp.Controllers
{




    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _env;
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> user, IHostingEnvironment env)
        {
            _context = context;
            _userManager = user;
            _env = env;
        }


        public int Isthmin()
        {
            int count1 = _context.Treatment.Count(d => d.IsIntered & d.IsThmin == false & d.IsAduit == false & d.IsApproved == false);
            int count2 = _context.R1Smaple.Count(d => d.IsIntered & d.IsThmin == false & d.IsAduit == false & d.IsApproved == false);
            int count3 = _context.R2Smaple.Count(d => d.IsIntered & d.IsThmin == false & d.IsAduit == false & d.IsApproved == false);
            return  count1 + count2 + count3;
          
        }

        public int IsAduit()
        {
            int count1 = _context.Treatment.Count(d => d.IsIntered & d.IsThmin & d.IsAduit == false & d.IsApproved == false);
            int count2 = _context.R1Smaple.Count(d => d.IsIntered & d.IsThmin  & d.IsAduit == false & d.IsApproved == false);
            int count3 = _context.R2Smaple.Count(d => d.IsIntered & d.IsThmin  & d.IsAduit == false & d.IsApproved == false);
            return count1 + count2 + count3;

        }

        public int IsApproved()
        {
            int count1 = _context.Treatment.Count(d => d.IsIntered & d.IsThmin & d.IsAduit & d.IsApproved == false);
            int count2 = _context.R1Smaple.Count(d => d.IsIntered & d.IsThmin & d.IsAduit  & d.IsApproved == false);
            int count3 = _context.R2Smaple.Count(d => d.IsIntered & d.IsThmin & d.IsAduit  & d.IsApproved == false);
            return count1 + count2 + count3;

        }

        public int Approved()
        {
            int count1 = _context.Treatment.Count(d => d.IsIntered & d.IsThmin & d.IsAduit & d.IsApproved );
            int count2 = _context.R1Smaple.Count(d => d.IsIntered & d.IsThmin & d.IsAduit & d.IsApproved );
            int count3 = _context.R2Smaple.Count(d => d.IsIntered & d.IsThmin & d.IsAduit & d.IsApproved );
            return count1 + count2 + count3;

        }

        public int Financial()
        {
            int count1 = _context.Treatment.Count(d => d.IsUnlockFin);
            int count2 = _context.R1Smaple.Count(d =>  d.IsUnlockFin);
            int count3 = _context.R2Smaple.Count(d => d.IsUnlockFin);
            return count1 + count2 + count3;

        }

        public int Sample1()
        {
            int count1 = _context.Treatment.Count(d => d.IsIntered & d.IsThmin & d.IsAduit & d.IsApproved);
            return count1;
        }
        public int Sample2()
        {
            int count1 = _context.R1Smaple.Count(d => d.IsIntered & d.IsThmin & d.IsAduit & d.IsApproved);
            return count1;
        }
        public int Sample3()
        {
            int count1 = _context.R2Smaple.Count(d => d.IsIntered & d.IsThmin & d.IsAduit & d.IsApproved);
            return count1;
        }

        public double FSample1()
        {
            double count1 = _context.Treatment.Sum(d => d.Price);
            return count1;
        }
        public double FSample2()
        {
            double count1 = _context.R1Smaple.Sum(d => d.Price);
            return count1;
        }
        public double FSample3()
        {
            double count1 = _context.R2Smaple.Sum(d => d.Price);
            return count1;
        }

        public List<ModelView> GetSamples()
        {
            List<ModelView> model = new List<ModelView>();
            foreach (var treatment in _context.Treatment.Where(d => d.IsIntered & d.IsThmin & d.IsAduit & d.IsApproved == false))
            {
                model.Add(new ModelView() {type=1,Id = treatment.Id , DateOfBegin = treatment.DateOfBegin, City = treatment.City ,Gada = treatment.Gada});
            }
            foreach (var treatment in _context.R1Smaple.Where(d => d.IsIntered & d.IsThmin & d.IsAduit & d.IsApproved == false))
            {
                model.Add(new ModelView() { type = 2, Id = treatment.Id, DateOfBegin = treatment.DateOfBegin, City = treatment.City, Gada = treatment.Gada });
            }
            foreach (var treatment in _context.R2Smaple.Where(d => d.IsIntered & d.IsThmin & d.IsAduit & d.IsApproved == false))
            {
                model.Add(new ModelView() { type = 3, Id = treatment.Id, DateOfBegin = treatment.DateOfBegin, City = treatment.City, Gada = treatment.Gada });
            }
            return model;
        }
        public IActionResult Index()
        {
            if (!IsEntring() && !IsMothmen() && !IsAud())
            {
                ViewBag.thmin = Isthmin();
                ViewBag.aduit = IsAduit();
                ViewBag.approved = IsApproved();
                ViewBag.approveded = Approved();
                ViewBag.financ = Financial();
                ViewBag.smaple1 = Sample1();
                ViewBag.smaple2 = Sample2();
                ViewBag.smaple3 = Sample3();
                ViewBag.fsmaple1 = FSample1();
                ViewBag.fsmaple2 = FSample2();
                ViewBag.fsmaple3 = FSample3();


                return View(GetSamples());
            }
            DateTime time = Convert.ToDateTime(DateTime.Now.ToString("HH:m:s"));

            return RedirectToAction("Index", "MainSamples" , new { currentTime =  time});
        }


        bool IsEntring()
        {
            bool value = User.IsInRole("en");
            return value;
        }

        bool IsMothmen()
        {
            return User.IsInRole("th");
        }

        bool IsAud()
        {
            return User.IsInRole("au");
        }

        bool Isapr()
        {
            return User.IsInRole("apr");
        }

        bool IsFincal()
        {
            return User.IsInRole("fn");
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
            ViewData["Aqartypelist"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Aqar), "Value", "Value");
            ViewData["city"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.City), "Value", "Value");
            ViewData["gada"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gada), "Value", "Value");
        }

        [HttpPost]
        public IActionResult PriceMap(PricParameter pric)
        {
            var data = GetDataByFilter(pric);
            ViewData["pricemap"] = data;
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
                    treatment.AqarType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.Gada == pric.Gada);
              var data2 =  FilterExpr2(treatment =>
                    treatment.AqarType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.Gada == pric.Gada);

               var data3 = FilterExpr3(treatment =>
                    treatment.AqarType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To  && treatment.Gada == pric.Gada);

                reslt.AddRange(dat1);
                reslt.AddRange(data2);
                reslt.AddRange(data3);
            }

            if (pric.Gada == "الكل")
            {
              var data1 =  FilterExpr1(treatment =>
                    treatment.AqarType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.City == pric.City );
              var data2 =  FilterExpr2(treatment =>
                    treatment.AqarType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.City == pric.City);
              var data3 =  FilterExpr3(treatment =>
                    treatment.AqarType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.City == pric.City);

                reslt.AddRange(data1);
                reslt.AddRange(data2);
                reslt.AddRange(data3);
            }

            else
            {
                var data1 = FilterExpr1(treatment =>
                    treatment.AqarType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.City == pric.City && treatment.Gada == pric.Gada);
                var data2 = FilterExpr2(treatment =>
                    treatment.AqarType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
                    treatment.DateOfBegin <= pric.To && treatment.City == pric.City && treatment.Gada == pric.Gada);
                var data3 = FilterExpr3(treatment =>
                    treatment.AqarType == pric.TypeOfAqar && treatment.DateOfBegin >= pric.From &&
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

            var allTrementWith1 = _context.Treatment.Where(xpr1);

            foreach (Treatment treatment in allTrementWith1)
            {
                PriceMapModelView item = new PriceMapModelView()
                {
                    TypeOfAqar = treatment.AqarType,
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

            var allTrementWith2 = _context.R1Smaple.Where(xpr1);

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

            var allTrementWith3 = _context.R2Smaple.Where(xpr1);

            foreach (R2Smaple treatment in allTrementWith3)
            {
                PriceMapModelView item = new PriceMapModelView()
                {
                    TypeOfAqar = treatment.AqarType,
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
