using System;
using System.Collections.Generic;
using CloudApp.Data;
using CloudApp.HelperClass;
using CloudApp.Models.BusinessModel;
using CloudApp.RepositoriesClasses;
using CloudApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
namespace CloudApp.Controllers
{
    public class MainSamplesController : Controller
    {
        private ApplicationDbContext _context;
        private readonly CustemerRepostry _cmsRepostry;
        private readonly CheckHelper _helper;
        private readonly SampleOneServices _oneservice;
        private readonly SampleTreeServices _sampleTreeServices;
        private readonly DateTimeHlper _dateTimeHlper;
        private readonly SampleTowServices _towServices;
        private UserManager<ApplicationUser> userManager;
        public MainSamplesController(ApplicationDbContext context , UserManager<ApplicationUser> _userManager)
        {
            _context = context;
            _cmsRepostry = new CustemerRepostry(context);
            _helper = new CheckHelper();
            _oneservice = new SampleOneServices(context , _cmsRepostry);

            _towServices = new SampleTowServices(context , _cmsRepostry);
            _sampleTreeServices = new SampleTreeServices(context, _cmsRepostry);
            _dateTimeHlper = new DateTimeHlper();

            userManager = _userManager;
        }

        public IActionResult Index(DateTime? currentTime)
        {
            if (currentTime != null)
            {
                if (!User.IsInRole("th"))
                {
                    return View(GetALlWithNoConstrain(currentTime.Value));
                }
                return View(GetALlWithMothmenConstrain(currentTime.Value , userManager.GetUserId(User)));
            }
            DateTime time = Convert.ToDateTime(DateTime.Now.ToString("HH:m:s"));
            if (!User.IsInRole("th"))
            {
                return View(GetALlWithNoConstrain(time));
            }
            return View(GetALlWithMothmenConstrain(time, userManager.GetUserId(User)));
        }
        
        
        public IActionResult Select_custmer()
        {
            ViewData["CustmerId"] = new SelectList(_cmsRepostry.Getall(), "Id", "Name");
            return View("Models_Custmor");
        }

        public  IActionResult Create(int id)
        {
            Custmer cms = _cmsRepostry.GetbyId(id);
            var sampleid = cms.SampleId;
            switch (sampleid)
            {
                case 1:
                    return RedirectToAction("Create" , "Treatments" , new { ids = cms.Id });
                case 2:
                    return RedirectToAction("Create", "R1Smaple", new { ids = cms.Id });
                case 3:
                    return RedirectToAction("Create", "R2Smaple", new { ids = cms.Id });
                default:
                    return View("Index");
            }
        }

        public IActionResult EditRouter(string id)
        {
            string[] data = id.Split(';');

            if (data[1] == "1")
            {
                return RedirectToAction("Edit", "Treatments", new { id = data[0] });
            }
            if (data[1] == "2")
            {
                return RedirectToAction("Edit", "R1Smaple", new { id = data[0] });
            }
            if (data[1] == "3")
            {
                return RedirectToAction("Edit", "R2Smaple", new { id = data[0] });
            }

            return RedirectToAction("Index");
        }

        public IActionResult Printout(string id)
        {
            string[] data = id.Split(';');

            if (data[1] == "1")
            {
                return RedirectToAction("GetSample0Report", "Treatments", new { id = data[0] });
            }
            if (data[1] == "2")
            {
                return RedirectToAction("GetSample1Report", "R1Smaple", new { id = data[0] });
            }
            if (data[1] == "3")
            {
                return RedirectToAction("GetSample2Report", "R2Smaple", new { id = data[0] });
            }

            return RedirectToAction("Index");
        }

        public bool SendEmailRoute(string id, IHostingEnvironment env, HttpContext contex)
        {
            string[] data = id.Split(';');
            if (data[1] == "1")
            {
                return _oneservice.SendEmail(Convert.ToInt64(data[0]), contex, env);
            }
            else if (data[1] == "2")
            {
                return _towServices.SendEmail(Convert.ToInt64(data[0]), contex, env);
            }
    
            return _sampleTreeServices.SendEmail(Convert.ToInt64(data[0]), contex, env);
        
        }

        public JsonResult Delete(long id, int type)
        {
            if (type == 1)
            {
                _oneservice.DeleteTrement(_oneservice.GetTrementById(id));
            }
            else if (type == 2)
            {
                _towServices.DeleteTrement(_towServices.GetTrementById(id));
            }
       
            else if (type == 3)
            {
                _sampleTreeServices.DeleteTrement(_sampleTreeServices.GetTrementById(id));
            }
            return Json("true");
        }

        List<TreamntsModelViewForInddex> GetALlWithNoConstrain(DateTime currentTime)
        {
            List<TreamntsModelViewForInddex> lists = new List<TreamntsModelViewForInddex>();
            var listoftremantsample1 = _oneservice.GetTreamentWithSampleAndAppUserCms();
            var listoftremantsample3 = _sampleTreeServices.GetTreamentWithSampleAndAppUserCms();
            var listoftremantsample2 = _towServices.GetTreamentWithSampleAndAppUserCms();
           
            DisplaySampleOne(lists , listoftremantsample1 , currentTime);

            DisplaySampleTow(lists , listoftremantsample2 , currentTime);
           
            DisplaySampleThree(lists , listoftremantsample3 , currentTime);

            return lists;
        }

        List<TreamntsModelViewForInddex> GetALlWithMothmenConstrain(DateTime currentTime , string userid)
        {
            List<TreamntsModelViewForInddex> lists = new List<TreamntsModelViewForInddex>();
            var listoftremantsample1 = _oneservice.TremntWihtMothmenwhere(userid);
            var listoftremantsample3 = _sampleTreeServices.TremntWihtMothmenwhere(userid);
            var listoftremantsample2 = _towServices.TremntWihtMothmenwhere(userid);

            DisplaySampleOne(lists, listoftremantsample1, currentTime);

            DisplaySampleTow(lists, listoftremantsample2, currentTime);

            DisplaySampleThree(lists, listoftremantsample3, currentTime);

            return lists;
        }

        void DisplaySampleOne(List<TreamntsModelViewForInddex> listToShow , IEnumerable<Treatment> repo , DateTime currentTime)
        {
            foreach (Treatment treatment in repo)
            {
                TreamntsModelViewForInddex row = new TreamntsModelViewForInddex()
                {
                    Id = treatment.Id,
                    Clint = _helper.CheckNullValue(treatment.Custmer.Name),
                    Owner = _helper.CheckNullValue(treatment.Owner),
                    AqarType = _helper.CheckNullValue(treatment.AqarType),
                    CityAndHy = _helper.CheckNullValue(treatment.City + " / " + treatment.Gada),
                    Mothmen = _helper.ChekNull(treatment.ApplicationUser),
                    SampleId = _helper.CheckNullValue(treatment.Custmer.Sample.Name),
                    State = _helper.GetState(treatment.IsIntered, treatment.IsThmin, treatment.IsAduit, treatment.IsApproved),
                    Type = 1 ,
                    TimeRimnder = _dateTimeHlper.GetDateTimeRimnder(treatment.DateRiminder , currentTime), 
                    StateColor = _dateTimeHlper.GetSatate()
                };

                listToShow.Add(row);
            }
        }

        void DisplaySampleTow(List<TreamntsModelViewForInddex> listToShow, IEnumerable<R1Smaple> repo, DateTime currentTime)
        {
            foreach (R1Smaple sample in repo)
            {
                TreamntsModelViewForInddex row = new TreamntsModelViewForInddex()
                {
                    Id = sample.Id,
                    Clint = _helper.CheckNullValue(sample.Custmer.Name),
                    Owner = _helper.CheckNullValue(sample.Owner),
                    AqarType = _helper.CheckNullValue(sample.AqarType),
                    CityAndHy = _helper.CheckNullValue(sample.City + " / " + sample.Gada),
                    Mothmen = _helper.ChekNull(sample.ApplicationUser),
                    SampleId = _helper.CheckNullValue(sample.Custmer.Sample.Name),
                    State = _helper.GetState(sample.IsIntered, sample.IsThmin, sample.IsAduit, sample.IsApproved),
                    Type = 2,
                    TimeRimnder = _dateTimeHlper.GetDateTimeRimnder(sample.DateRiminder , currentTime),
                    StateColor = _dateTimeHlper.GetSatate()
                };

                listToShow.Add(row);
            }
        }

        void DisplaySampleThree(List<TreamntsModelViewForInddex> listToShow, IEnumerable<R2Smaple> repo, DateTime currentTime)
        {
            foreach (R2Smaple sample in repo)
            {
                TreamntsModelViewForInddex row = new TreamntsModelViewForInddex()
                {
                    Id = sample.Id,
                    Clint = _helper.CheckNullValue(sample.Custmer.Name),
                    Owner = _helper.CheckNullValue(sample.Owner),
                    AqarType = _helper.CheckNullValue(sample.AqarType),
                    CityAndHy = _helper.CheckNullValue(sample.City + " / " + sample.Gada),
                    Mothmen = _helper.ChekNull(sample.ApplicationUser),
                    SampleId = _helper.CheckNullValue(sample.Custmer.Sample.Name),
                    State = _helper.GetState(sample.IsIntered, sample.IsThmin, sample.IsAduit, sample.IsApproved),
                    Type = 3 ,
                    TimeRimnder = _dateTimeHlper.GetDateTimeRimnder(sample.DateRiminder , currentTime),
                    StateColor = _dateTimeHlper.GetSatate()
                };

                listToShow.Add(row);
            }
        }
    }
}