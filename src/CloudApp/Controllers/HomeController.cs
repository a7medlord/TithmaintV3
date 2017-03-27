using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

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
            Attachment attach = new Attachment(String.Empty , MediaTypeNames.Application.Pdf);
         
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
