using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CloudApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IHostingEnvironment _env;
        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }
      
        public IActionResult Index()
        {
           
            WebClient clint = new WebClient();
            clint.DownloadFile(new Uri(@"https://maps.googleapis.com/maps/api/staticmap?center=40.714728,-73.998672&zoom=12&size=600x600&maptype=satellite&key=AIzaSyDi_nL0Zh0BYDb5iZTndmJCr-uHjd1Pvhs") , Path.Combine(_env.WebRootPath, "ProfileImg/map.png"));
            return View();
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
