using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudApp.Data;
using CloudApp.Models;
using CloudApp.Models.BusinessModel;
using CloudApp.Models.ManpulateModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Reporting.WebForms;

namespace CloudApp.Controllers
{
    public class TreatmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _env;
        public TreatmentsController(ApplicationDbContext context , UserManager<ApplicationUser> user , IHostingEnvironment env)
        {
            _context = context;
            _userManager = user;
            _env = env;
        }


        public bool SendEmail(long id)
        {
            var qu = _context.Treatment.Include(quotation => quotation.Custmer).SingleOrDefault(quotation => quotation.Id == id);

            var fromAddress = new MailAddress("ma3az333333@gmail.com", "‘—ﬂ… «· À„Ì‰«  «·⁄ﬁ«—ÌÂ");
            string frompassword = "maazahmed1111111";

            var toAddress = new MailAddress(qu.Custmer.Email, qu.Custmer.Name);

            Attachment attacher = new Attachment(new MemoryStream(GetSample0ReportasStreem(id)), MediaTypeNames.Application.Pdf);
            attacher.ContentDisposition.FileName = qu.Id + ".pdf";

            SmtpClient smptclints = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, frompassword)
            };

            MailMessage msg = new MailMessage();
            msg.Attachments.Add(attacher);
            msg.Subject = "⁄—÷ ”⁄— ⁄„·Ì…  À„Ì‰";
            msg.Body = "«·—Ã«¡ «·«ÿ·«⁄ ⁄·Ì ⁄—÷ «·”⁄— ";
            msg.To.Add(toAddress);
            msg.From = fromAddress;
            smptclints.Send(msg);

            return true;
        }

        public IActionResult GetSample0Report(long id)
        {

            byte[] rendervalue = GetSample0ReportasStreem(id);

            return File(rendervalue, "application/pdf");
        }

        public byte[] GetSample0ReportasStreem(long id)
        {
          
            ReportDataSource reportDataSource = new ReportDataSource();

            // get attachment  
            var attament = _context.AttachmentForTreaments.Where(d => d.TreatmentId == id);
            string images = null;
            foreach (var attachmentForTreament in attament)
            {
                images +=   "http://" + HttpContext.Request.Host + "/sample1attachment/" + attachmentForTreament.AttachmentId + ".jpg" + ",";
            }

            // Qoution Report
            var treatments = _context.Treatment.Include(d=> d.Custmer).ThenInclude(s=>s.Sample).Where(d => d.Id == id);
            reportDataSource.Name = "DataSetSample0";
            reportDataSource.Value = treatments;
            string custmer =  treatments.SingleOrDefault()?.Custmer.Name;
            string sample = treatments.SingleOrDefault()?.Custmer.Sample.Name;
            string longtute = treatments.SingleOrDefault()?.Longtute;
            string latute = treatments.SingleOrDefault()?.Latute;
            LocalReport local = new LocalReport();
            local.DataSources.Add(reportDataSource);
            
            local.ReportPath = "Report/Sm0Report.rdlc";
            local.EnableExternalImages = true;

            double price = treatments.Sum(d => d.TotalPriceNumber);

            ToWord toWord = new ToWord((decimal)price, new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));
            //get name
            string muthmenname = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Muthmen)?.EmployName;
            string aduitname = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Adutit)?.EmployName;
            string appovename = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Approver)?.EmployName;
            // get member id
            string muthmenid = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Muthmen)?.MemberId;
            string aduitid = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Adutit)?.MemberId;
            string appoveid = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Approver)?.MemberId;
            //get image sign
            string muthminsign = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Muthmen)?.SigImage;
            string auditsign = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Adutit)?.SigImage;
            string approvesign = _context.Users.SingleOrDefault(d => d.Id == treatments.SingleOrDefault().Approver)?.SigImage;
            //get image url
            string sigurlmuthmen = "http://" + HttpContext.Request.Host + "/ProfPic/" + muthminsign + ".jpg";
            string sigurlauditsign = "http://" + HttpContext.Request.Host + "/ProfPic/" + auditsign + ".jpg";
            string sigurlapprovesign = "http://" + HttpContext.Request.Host + "/ProfPic/" + approvesign + ".jpg";

            string earthmap = Mapgen(longtute, latute, "satellite", "12", "283", "739");
            string map = Mapgen(longtute, latute, "ROADMAP", "12", "249", "739");
            string zoommap = Mapgen(longtute, latute, "satellite", "18", "265", "530");
            ReportParameter[] parameters = {
                new ReportParameter("sample",sample),
                new ReportParameter("custmer",custmer), 
                new ReportParameter("muthmen", muthmenname),
                 new ReportParameter("audit", aduitname),
                  new ReportParameter("approver", appovename),
                new ReportParameter("totprice",  toWord.ConvertToArabic()),


                new ReportParameter("muthminsign",  sigurlmuthmen),
                new ReportParameter("Auditsign",  sigurlauditsign),
                new ReportParameter("Approvesign", sigurlapprovesign),


                new ReportParameter("idmuthmin",  muthmenid),
                new ReportParameter("idaudit",  aduitid),
                new ReportParameter("idapprove", appoveid),
                new ReportParameter("earthmap",  earthmap),
                new ReportParameter("map", map),
                new ReportParameter("zoommap", zoommap),
                new ReportParameter("images",images)


               };

            local.SetParameters(parameters);

            return local.Render("Pdf", "");
        }

        public string Mapgen(string longtut , string lutit , string type , string zoom , string hight , string with)
        {
            string url = "https://maps.googleapis.com/maps/api/staticmap?center=" + longtut +","+lutit +"&zoom="+zoom + "&size="+with+"x" + hight+ "&maptype="+type + "&key=AIzaSyDi_nL0Zh0BYDb5iZTndmJCr-uHjd1Pvhs";
            return url;
        }



        [HttpPost]
        public async Task<JsonResult> UploadFile()
        {
                string guid = Guid.NewGuid().ToString();
                string filepath = "sample1attachment/" + guid + ".jpg";
                var strem = new FileStream(Path.Combine(_env.WebRootPath, filepath), FileMode.Create);
                await Request.Form.Files[0].CopyToAsync(strem);
                strem.Close();
                strem.Dispose();
            return Json(guid);
        }

       
        public  IActionResult Index()
        {
           List<TreamntsModelViewForInddex> lists = new List<TreamntsModelViewForInddex>();
            var listoftremantsample1 = _context.Treatment.Include(treatment => treatment.Custmer).ThenInclude(custmer => custmer.Sample).Include(treatment => treatment.ApplicationUser).ToList();
            var listoftremantsample2 = _context.R1Smaple.Include(treatment => treatment.Custmer).ThenInclude(custmer => custmer.Sample).Include(treatment => treatment.ApplicationUser).ToList();
            foreach (Treatment treatment in listoftremantsample1)
            {
                TreamntsModelViewForInddex row = new TreamntsModelViewForInddex()
                {
                    Id = treatment.Id,
                    Clint = CheckNullValue(treatment.Custmer.Name),
                    Owner = CheckNullValue(treatment.Owner),
                    AqarType = CheckNullValue(treatment.Tbuild),
                    CityAndHy = CheckNullValue(treatment.City + " / " + treatment.Gada),
                    Mothmen =ChekNull(treatment.ApplicationUser),
                    SampleId = CheckNullValue(treatment.Custmer.Sample.Name) ,
                    State = GetState(treatment.IsIntered , treatment.IsThmin , treatment.IsAduit , treatment.IsApproved) ,
                    Type = 1
                };

                lists.Add(row);
            }

            foreach (R1Smaple sample in listoftremantsample2)
            {
                TreamntsModelViewForInddex row = new TreamntsModelViewForInddex()
                {
                    Id = sample.Id,
                    Clint = CheckNullValue(sample.Custmer.Name),
                    Owner = CheckNullValue(sample.Owner),
                    AqarType = CheckNullValue(sample.AqarType),
                    CityAndHy = CheckNullValue(sample.City + " / " + sample.Gada),
                    Mothmen = ChekNull(sample.ApplicationUser),
                    SampleId = CheckNullValue(sample.Custmer.Sample.Name),
                    State = GetState(sample.IsIntered, sample.IsThmin, sample.IsAduit, sample.IsApproved),
                    Type = 2
                };

                lists.Add(row);
            }
            return View(lists);
        }

        private string CheckNullValue(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                return "·« ÌÊÃœ ‘∆ ·⁄—÷Â";
            }
            return item;
        }

        string ChekNull(ApplicationUser user)
        {
            if (user == null)
            {
                return "·„  À„‰ »⁄œ ";
            }
           return user.EmployName;
        }

        string GetState(params bool[] state)
        {
            bool IsIntered = state[0];
            bool IsThmin = state[1];
            bool IsAduit = state[2];
            bool IsApproved = state[3];
            if (IsIntered && IsThmin == false)
            {
                return " Õ  «· À„Ì‰";
            }
            if (IsThmin && IsAduit == false)
            {
                return " Õ  «· œﬁÌﬁ";
            }
            if (IsAduit && IsApproved == false)
            {
                return " Õ  «· ⁄„Ìœ";
            }
            if (IsApproved)
            {
                return "„ﬂ „‹‹·…";
            }
            return " Õ  «·«œŒ«·";
        }

       
        public async Task<IActionResult> Details(long? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatment.SingleOrDefaultAsync(m => m.Id == id);
            if (treatment == null)
            {
                return NotFound();
            }

            return View(treatment);
        }

     
        public async Task<IActionResult> Create(int id)
        {
          

            Custmer cms = _context.Custmer.SingleOrDefault(custmer => custmer.Id == id);
            var sampleid = cms.SampleId;

            switch (sampleid)
            {
                case 1 :
                   
                    ViewData["UserId"] = new SelectList(await _userManager.GetUsersInRoleAsync("th"), "Id", "EmployName");
                    ViewData["Aqartype"] = new SelectList(_context.Flag.Where(d=>d.FlagValue  ==FlagsName.Aqar), "Value", "Value");
                    ViewData["Gentype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gen), "Value", "Value");
                    ViewData["cmsname"] = cms;
                    return View(new Treatment());
                case 2:
                    return RedirectToAction("Create","R1Smaple" , new {id = cms.Id});
                case 3:
                    return RedirectToAction("Create", "R2Smaple");
                default:
                    return View();
            } 
        }

        public IActionResult Select_custmer()
        {
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");
            return View("Models_Custmor");
        }
        
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind ]Treatment treatment , string ids)
        {
          
            if (ModelState.IsValid)
            {
             
                if (!string.IsNullOrEmpty(ids))
                {
                    string[] imgsids = ids.Split(';');
                    treatment.AttachmentForTreaments = new List<AttachmentForTreament>();
                    for (int i = 0; i < imgsids.Length - 1; i++)
                    {
                        treatment.AttachmentForTreaments.Add(new AttachmentForTreament() { AttachmentId = imgsids[i] });
                    }
                }
              

                if (treatment.IsAduit && User.IsInRole("au"))
                {
                    treatment.Adutit = _userManager.GetUserId(User);
                }
                if (treatment.IsApproved && User.IsInRole("apr"))
                {
                    treatment.Approver = _userManager.GetUserId(User);
                } if (treatment.IsIntered && User.IsInRole("en"))
                {
                    treatment.Intered = _userManager.GetUserId(User);
                } if (treatment.IsThmin && User.IsInRole("th"))
                {
                    treatment.Muthmen = _userManager.GetUserId(User);
                }
                _context.Add(treatment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", new {Id=treatment.Id});
            }
            await GetListBind(treatment.CustmerId);
            return View("Create",treatment);
        }

        async Task GetListBind(long cmsSelectId)
        {
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", cmsSelectId);
            ViewData["UserId"] = new SelectList(await _userManager.GetUsersInRoleAsync("th"), "Id", "EmployName");
            ViewData["Aqartype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Aqar), "Value", "Value");
            ViewData["Gentype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gen), "Value", "Value");
        }

        public JsonResult RemoveFile(string name)
        {
            _context.Remove(_context.AttachmentForTreaments.SingleOrDefault(treament => treament.AttachmentId == name));
            _context.SaveChanges();
            return Json("true");
        }
     
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatment.Include(treatment1 => treatment1.AttachmentForTreaments).Include(treatment1 => treatment1.Custmer).SingleOrDefaultAsync(m => m.Id == id);

            if (treatment == null)
            {
                return NotFound();
            }

            string files = "";
            foreach (AttachmentForTreament file in treatment.AttachmentForTreaments)
            {
                    files += file.AttachmentId + ";";
            }
            ViewData["imgs"] = files;
           await GetListBind(treatment.CustmerId);
            ViewData["cmsname"] = treatment.Custmer;
            return View(treatment);
        }

        public IActionResult EditRouter(string id)
        {
            string[] data = id.Split(';');

            if (data[1] == "1")
            {
             return   RedirectToAction("Edit", new {id= data[0]});
            }
            if (data[1] == "2")
            {
                return RedirectToAction("Edit", "R1Smaple" , new { id = data[0]});
            }

            return  RedirectToAction("Index");
        }

        public IActionResult SendEmailRoute(string id)
        {
            string[] data = id.Split(';');
            if (data[1] == "1")
            {
                return RedirectToAction("SendEmail", new {id = data[0]});
            }else if (data[1] == "2")
            {
                return RedirectToAction("", "R1Smaple");
            }
            return RedirectToAction("Index");
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind] Treatment treatment , string ids)
        {
            if (id != treatment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(ids))
                    {
                        string[] imgsids = ids.Split(';');
                        treatment.AttachmentForTreaments = new List<AttachmentForTreament>();
                        for (int i = 0; i < imgsids.Length - 1; i++)
                        {
                            treatment.AttachmentForTreaments.Add(new AttachmentForTreament() { AttachmentId = imgsids[i] });
                        }
                    }


                    if (treatment.IsAduit && User.IsInRole("au"))
                    {
                        treatment.Adutit = _userManager.GetUserId(User);
                    }
                    if (treatment.IsApproved && User.IsInRole("apr"))
                    {
                        treatment.Approver = _userManager.GetUserId(User);
                    }
                    if (treatment.IsIntered && User.IsInRole("en"))
                    {
                        treatment.Intered = _userManager.GetUserId(User);
                    }
                    if (treatment.IsThmin && User.IsInRole("th"))
                    {
                        treatment.Muthmen = _userManager.GetUserId(User);
                    }
                    _context.Update(treatment);
                    await _context.SaveChangesAsync();
                    RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentExists(treatment.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }
          await  GetListBind(treatment.CustmerId);
            return View(treatment);
        }

      
        public JsonResult Delete(long? id , int type)
        {
            if (type == 1)
            {
                _context.Remove(_context.Treatment.SingleOrDefault(treatment => treatment.Id == id));
                _context.SaveChanges();
            } else if (type == 2)
            {
                _context.Remove(_context.R1Smaple.SingleOrDefault(treatment => treatment.Id == id));
                _context.SaveChanges();
            }
            return Json("true");
        }
        
        private bool TreatmentExists(long id)
        {
            return _context.Treatment.Any(e => e.Id == id);
        }
    }
}
