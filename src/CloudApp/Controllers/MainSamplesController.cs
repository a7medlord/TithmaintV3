using System;
using System.Collections.Generic;
using System.Linq;
using CloudApp.Data;
using CloudApp.HelperClass;
using CloudApp.Models.BusinessModel;
using CloudApp.RepositoriesClasses;
using CloudApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CloudApp.Controllers
{
    public class MainSamplesController : Controller
    {
        private ApplicationDbContext _context;
        private CustemerRepostry _cmsRepostry;
        private CheckHelper _helper;
        private readonly SampleOneServices _oneservice;

        public MainSamplesController(ApplicationDbContext context)
        {
            _context = context;
            _cmsRepostry = new CustemerRepostry(context);
            _helper = new CheckHelper();
            _oneservice = new SampleOneServices(context , _cmsRepostry);
        }

        public IActionResult Index()
        {
            List<TreamntsModelViewForInddex> lists = new List<TreamntsModelViewForInddex>();
            var listoftremantsample1 = _oneservice.GetTreamentWithSampleAndAppUserCms();
            var listoftremantsample2 = _context.R1Smaple.Include(treatment => treatment.Custmer).ThenInclude(custmer => custmer.Sample).Include(treatment => treatment.ApplicationUser).ToList();
            var listoftremantsample3 = _context.R2Smaple.Include(treatment => treatment.Custmer).ThenInclude(custmer => custmer.Sample).Include(treatment => treatment.ApplicationUser).ToList();
            foreach (Treatment treatment in listoftremantsample1)
            {
                TreamntsModelViewForInddex row = new TreamntsModelViewForInddex()
                {
                    Id = treatment.Id,
                    Clint = _helper.CheckNullValue(treatment.Custmer.Name),
                    Owner = _helper.CheckNullValue(treatment.Owner),
                    AqarType = _helper.CheckNullValue(treatment.Tbuild),
                    CityAndHy = _helper.CheckNullValue(treatment.City + " / " + treatment.Gada),
                    Mothmen = _helper.ChekNull(treatment.ApplicationUser),
                    SampleId = _helper.CheckNullValue(treatment.Custmer.Sample.Name),
                    State = _helper.GetState(treatment.IsIntered, treatment.IsThmin, treatment.IsAduit, treatment.IsApproved),
                    Type = 1
                };

                lists.Add(row);
            }

            foreach (R1Smaple sample in listoftremantsample2)
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
                    Type = 2
                };

                lists.Add(row);
            }

            foreach (R2Smaple sample in listoftremantsample3)
            {
                TreamntsModelViewForInddex row = new TreamntsModelViewForInddex()
                {
                    Id = sample.Id,
                    Clint = _helper.CheckNullValue(sample.Custmer.Name),
                    Owner = _helper.CheckNullValue(sample.Owner),
                    AqarType = _helper.CheckNullValue(sample.BuldingType),
                    CityAndHy = _helper.CheckNullValue(sample.City + " / " + sample.Gada),
                    Mothmen = _helper.ChekNull(sample.ApplicationUser),
                    SampleId = _helper.CheckNullValue(sample.Custmer.Sample.Name),
                    State = _helper.GetState(sample.IsIntered, sample.IsThmin, sample.IsAduit, sample.IsApproved),
                    Type = 3
                };

                lists.Add(row);
            }

            return View(lists);
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
                return _oneservice.SendEmail(Convert.ToInt32(data[0]), contex, env);
            }
            //else if (data[1] == "2")
            //{
            //    return RedirectToAction("", "R1Smaple" , new { id = data[0] });
            //}
            //return RedirectToAction("Index");
            return false;
        }

        public JsonResult Delete(long id, int type)
        {
            if (type == 1)
            {
                _oneservice.DeleteTrement(_oneservice.GetTrementById(id));
            }
            //else if (type == 2)
            //{
            //    _context.Remove(_context.R1Smaple.SingleOrDefault(treatment => treatment.Id == id));
            //    _context.SaveChanges();
            //}
            //else if (type == 3)
            //{
            //    _context.Remove(_context.R2Smaple.SingleOrDefault(treatment => treatment.Id == id));
            //    _context.SaveChanges();
            //}
            return Json("true");
        }

    }
}