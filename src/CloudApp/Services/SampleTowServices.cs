using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using CloudApp.Data;
using CloudApp.Models.BusinessModel;
using CloudApp.Models.ManpulateModel;
using CloudApp.RepositoriesClasses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WebForms;

namespace CloudApp.Services
{
    public class SampleTowServices
    {
        private readonly SampleTowRepostry _repostry;
        private readonly CustemerRepostry _cmsrepo;
        public SampleTowServices(ApplicationDbContext contex, CustemerRepostry cmsrepo)
        {
         _repostry = new SampleTowRepostry(contex);
            _cmsrepo = cmsrepo;
        }

        public bool CreatNewTreamnt(R1Smaple trement)
        {
            return _repostry.Add(trement);
        }

        public bool UpdateExistTreament(R1Smaple treament)
        {
            return _repostry.Update(treament);
        }

        public R1Smaple GetTrementById(long id)
        {
            return _repostry.GetbyId(id);
        }

        public bool DeleteTrement(R1Smaple tremnt)
        {
            return _repostry.Delete(tremnt);
        }

        public R1Smaple GetTrementWithAttachmentFiles(long trementid)
        {
            return _repostry.GetTrementWithAttachmentFiles(trementid);
        }

        public IEnumerable<R1Smaple> GetTreamentWithSampleAndAppUserCms()
        {
            return _repostry.GetTreamentWithSampleAndAppUserCms();
        }

        public bool SendEmail(long id, HttpContext context, IHostingEnvironment env)
        {
            R1Smaple trement = _repostry.GetbyId(id);
            Custmer custmer = _cmsrepo.GetbyId(trement.CustmerId);

            var fromAddress = new MailAddress("ma3az333333@gmail.com", "شركة التثمينات العقاريه");
            string frompassword = "maazahmed1111111";

            var toAddress = new MailAddress(custmer.Email, custmer.Name);

            Attachment attacher = new Attachment(new MemoryStream(GetSample1ReportasStreem(id, context, env)), MediaTypeNames.Application.Pdf);
            attacher.ContentDisposition.FileName = trement.Id + ".pdf";

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
            // msg.Attachments.Add(attacher);
            msg.Subject = "عرض سعر عملية تثمين";
            msg.Body = "الرجاء الاطلاع علي عرض السعر ";
            msg.To.Add(toAddress);
            msg.From = fromAddress;
            smptclints.Send(msg);

            return true;
        }

        public byte[] GetSample1ReportasStreem(long id, HttpContext context, IHostingEnvironment env)
        {
            ReportDataSource reportDataSource = new ReportDataSource();

            //get attachment
            var rsample1 = _repostry.DircAccessToDb.AttachmentForR1Samples.Where(d => d.R1SmapleId == id);
            string images = null;
            foreach (var r1Samples in rsample1)
            {
                images += "http://" + context.Request.Host + "/attachs2/" + r1Samples.AttachmentId + ".jpg" + ",";
            }

            // R1 Report
            var r1Sample = _repostry.DircAccessToDb.R1Smaple.Include(d => d.Custmer).ThenInclude(s => s.Sample).Where(d => d.Id == id);
            reportDataSource.Name = "DataSetR1Sample";
            reportDataSource.Value = r1Sample;
            string sample = r1Sample.SingleOrDefault()?.Custmer.Sample.Name;
            string longtute = r1Sample.SingleOrDefault()?.Longtute;
            string latute = r1Sample.SingleOrDefault()?.Latute;
            LocalReport local = new LocalReport();
            local.DataSources.Add(reportDataSource);

            local.ReportPath = env.WebRootPath + "/Report/Sm1Report.rdlc";
            local.EnableExternalImages = true;

            double price = r1Sample.Sum(d => d.LastTaqeem);

            ToWord toWord = new ToWord((decimal)price, new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));
            ////get name
            string muthmenname = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Muthmen)?.EmployName;
            string aduitname = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Adutit)?.EmployName;
            string appovename = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Approver)?.EmployName;
            // get member id
            string muthmenid = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Muthmen)?.MemberId;
            string aduitid = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Adutit)?.MemberId;
            string appoveid = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Approver)?.MemberId;
            //get image sign
            string muthminsign = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Muthmen)?.SigImage;
            string auditsign = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Adutit)?.SigImage;
            string approvesign = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r1Sample.SingleOrDefault().Approver)?.SigImage;
            //get image url
            string sigurlmuthmen = "http://" + context.Request.Host + "/ProfPic/" + muthminsign + ".jpg";
            string sigurlauditsign = "http://" + context.Request.Host + "/ProfPic/" + auditsign + ".jpg";
            string sigurlapprovesign = "http://" + context.Request.Host + "/ProfPic/" + approvesign + ".jpg";

            string earthmap = Mapgen(longtute, latute, "satellite", "16", "283", "750");
            string map = Mapgen(longtute, latute, "ROADMAP", "16", "249", "739");
            string zoommap = Mapgen(longtute, latute, "satellite", "19", "265", "530");
            ReportParameter[] parameters = {
                new ReportParameter("sample",sample),
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
        public string Mapgen(string longtut, string lutit, string type, string zoom, string hight, string with)
        {
            string url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lutit + "," + longtut + "&zoom=" + zoom + "&size=" + with + "x" + hight + "&maptype=" + type + "&key=AIzaSyDi_nL0Zh0BYDb5iZTndmJCr-uHjd1Pvhs" + "&language=ar" + "&markers=color:red|label:C|" + lutit + "," + longtut;
            return url;
        }

        public long GetAutoIncreesNumber(DateTime date)
        {
            string time = date.ToString("yy-MM-dd");
            string[] data = time.Split('-');
            long id = _repostry.GetAutoIncreesNumber();
            string dateformater = data[0] + "" + data[1] + "" + id;
            return Convert.ToInt32(dateformater);
        }
    }
}
