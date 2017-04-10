using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using CloudApp.Data;
using CloudApp.Models;
using CloudApp.Models.ManpulateModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            WebClient clint = new WebClient();
            clint.DownloadFile(new Uri(@"https://maps.googleapis.com/maps/api/staticmap?center=40.714728,-73.998672&zoom=12&size=600x600&maptype=satellite&key=AIzaSyDi_nL0Zh0BYDb5iZTndmJCr-uHjd1Pvhs") , Path.Combine(_env.WebRootPath, "ProfileImg/map.png"));



            return View(GetSamples());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
