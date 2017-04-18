using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
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
    public class SampleTreeServices
    {
        private readonly CustemerRepostry _cmsrepo;
        private readonly SampleTreeRepostry _repostry;
        public SampleTreeServices(ApplicationDbContext contex, CustemerRepostry cmsrepo)
        {
            _repostry = new SampleTreeRepostry(contex);
            _cmsrepo = cmsrepo;
        }


        public bool CreatNewTreamnt(R2Smaple trement)
        {
            return _repostry.Add(trement);
        }

        public bool UpdateExistTreament(R2Smaple treament)
        {
            return _repostry.Update(treament);
        }

        public R2Smaple GetTrementById(long id)
        {
            return _repostry.GetbyId(id);
        }

        public bool DeleteTrement(R2Smaple tremnt)
        {
            return _repostry.Delete(tremnt);
        }

        public bool SendEmail(long id, HttpContext context, IHostingEnvironment env)
        {
            R2Smaple trement = _repostry.GetbyId(id);
            Custmer custmer = _cmsrepo.GetbyId(trement.CustmerId);

            var fromAddress = new MailAddress("ma3az333333@gmail.com", "شركة التثمينات العقاريه");
            string frompassword = "maazahmed1111111";

            var toAddress = new MailAddress(custmer.Email, custmer.Name);

            Attachment attacher = new Attachment(new MemoryStream(GetSample2ReportasStreem(id, context, env)), MediaTypeNames.Application.Pdf);
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


        public byte[] GetSample2ReportasStreem(long id , HttpContext context, IHostingEnvironment env)
        {
            ReportDataSource reportDataSource = new ReportDataSource();

            //get attachment
            var rsample2 = _repostry.DircAccessToDb.AttachmentForR2Samples.Where(d => d.R2SmapleId == id);
            string images = null;
            foreach (var r2Samples in rsample2)
            {
                images += "http://" + context.Request.Host + "/attachs3/" + r2Samples.AttachmentId + ".jpg" + ",";
            }

            // R1 Report
            var r2Sample = _repostry.DircAccessToDb.R2Smaple.Include(d => d.Custmer).ThenInclude(s => s.Sample).Where(d => d.Id == id);
            reportDataSource.Name = "DataSetS2";
            reportDataSource.Value = r2Sample;
            string sample = r2Sample.SingleOrDefault()?.Custmer.Sample.Name;
            string custmer = r2Sample.SingleOrDefault()?.Custmer.Name;
            string longtute = r2Sample.SingleOrDefault()?.Longtute;
            string latute = r2Sample.SingleOrDefault()?.Latute;
            LocalReport local = new LocalReport();
            local.DataSources.Add(reportDataSource);

            local.ReportPath = env.WebRootPath + "/Report/Sm2Report.rdlc";
            local.EnableExternalImages = true;

            double price = r2Sample.Sum(d => d.LastTaqeem);

            ToWord toWord = new ToWord((decimal)price, new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));
            ////get name
            string muthmenname = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r2Sample.SingleOrDefault().Muthmen)?.EmployName;
            string aduitname = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r2Sample.SingleOrDefault().Adutit)?.EmployName;
            string appovename = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r2Sample.SingleOrDefault().Approver)?.EmployName;
            // get member id
            string muthmenid = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r2Sample.SingleOrDefault().Muthmen)?.MemberId;
            string aduitid = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r2Sample.SingleOrDefault().Adutit)?.MemberId;
            string appoveid = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r2Sample.SingleOrDefault().Approver)?.MemberId;
            //get image sign
            string muthminsign = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r2Sample.SingleOrDefault().Muthmen)?.SigImage;
            string auditsign = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r2Sample.SingleOrDefault().Adutit)?.SigImage;
            string approvesign = _repostry.DircAccessToDb.Users.SingleOrDefault(d => d.Id == r2Sample.SingleOrDefault().Approver)?.SigImage;
            //get image url
            string sigurlmuthmen = "http://" + context.Request.Host + "/ProfPic/" + muthminsign + ".jpg";
            string sigurlauditsign = "http://" + context.Request.Host + "/ProfPic/" + auditsign + ".jpg";
            string sigurlapprovesign = "http://" + context.Request.Host + "/ProfPic/" + approvesign + ".jpg";

            string earthmap = Mapgen(longtute, latute, "satellite", "16", "283", "750");
            string map = Mapgen(longtute, latute, "ROADMAP", "16", "249", "739");
            string zoommap = Mapgen(longtute, latute, "satellite", "19", "265", "530");
            ReportParameter[] parameters = {
                new ReportParameter("sample",sample),
                new ReportParameter("custmer", custmer),
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

        public R2Smaple GetTrementWithAttachmentFiles(long id)
        {
            return _repostry.GetTrementWithAttachmentFiles(id);
        }

        public IEnumerable<R2Smaple> GetTreamentWithSampleAndAppUserCms()
        {
            return _repostry.GetTreamentWithSampleAndAppUserCms();
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
