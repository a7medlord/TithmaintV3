using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudApp.Data;
using CloudApp.HelperClass;
using CloudApp.Models;
using CloudApp.Models.BusinessModel;
using CloudApp.Models.ManpulateModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Reporting.WebForms;
using Microsoft.AspNetCore.Hosting;

namespace CloudApp.Controllers
{

    public class FinModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _env;
       
        public FinModelsController(ApplicationDbContext context, UserManager<ApplicationUser> user , IHostingEnvironment env)
        {
            _context = context;
            _userManager = user;
            _env = env;
        }



        public IActionResult FinFilter(DateTime? date1 = null, DateTime? date2 = null, long? cms = null , string aqartype = null , string city = null , string gada = null )
        {
            ViewData["City"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.City), "Value", "Value");
            ViewData["Gada"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gada), "Value", "Value");
            ViewData["aqartype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Aqar), "Value", "Value");

            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");
            ViewData["BankId"] = new SelectList(_context.BankModel, "AccountNumber", "Name");
            if (!date1.HasValue)
            {
                date1 = DateTime.Now.Date;
            }

            if (!date2.HasValue)
            {
                date2 = DateTime.Now.Date;
            }
            if (!cms.HasValue)
            {
                cms = _context.Custmer.FirstOrDefault()?.Id;
            }
            if (aqartype == null)
            {
                aqartype = "الكل";
            }
            if (city==null)
            {
                city = "الكل";
            }
            if (gada == null)
            {
                gada = "الكل";
            }


            List<FinCloseModel> models = new List<FinCloseModel>();

            foreach (var treatment in  GlobelFilter(cms.ToString(),aqartype ,city ,gada))
            {
                if (treatment != null)
                {
                    FinCloseModel row = new FinCloseModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        Scustmer = treatment.Scustmer,
                        Bank = treatment.BankModel.Name,
                        Place = treatment.City + " - " + treatment.Gada,
                        Tbuild = treatment.AqarType,
                        Price = treatment.Price,
                        Id = treatment.Id,
                        Owner = treatment.Owner,
                    
                        Type = 1
                    };
                    models.Add(row);
                }
            }



            #region Tables for R1 and R2
            //foreach (var treatment in await _context.R1Smaple.Include(s => s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose == false && d.CustmerId == cms).ToListAsync())
            //{
            //    if (treatment != null)
            //    {


            //        models.Add(new FinCloseModel()
            //        {
            //            Custmer = treatment.Custmer.Name,
            //            Scustmer = treatment.Scustmer,
            //            Bank = treatment.BankModel.Name,
            //            Place = treatment.City + " - " + treatment.Gada,
            //            Tbuild = treatment.AqarType,
            //            Price = treatment.Price,
            //            Id = treatment.Id,
            //            Owner = treatment.Owner,
            //            FinDate = treatment.DateOfBegin.ToShortDateString(),
            //            SNum = treatment.SukNumber,
            //            FinPriceClose = treatment.FinPriceClose,
            //            Type = 2

            //        });
            //    }
            //}
            //foreach (var treatment in await _context.R2Smaple.Include(s => s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose == false && d.CustmerId == cms).ToListAsync())
            //{
            //    if (treatment != null)
            //    {


            //        models.Add(new FinCloseModel()
            //        {
            //            Custmer = treatment.Custmer.Name,
            //            Scustmer = treatment.Scustmer,
            //            Bank = treatment.BankModel.Name,
            //            Place = treatment.City + " - " + treatment.Gada,
            //            Tbuild = treatment.AqarType,
            //            Price = treatment.Price,
            //            Id = treatment.Id,
            //            Owner = treatment.Owner,
            //            FinDate = treatment.DateOfBegin.ToShortDateString(),
            //            SNum = treatment.SukNumber,
            //            FinPriceClose = treatment.FinPriceClose,
            //            Type = 3

            //        });
            //    }
            //}

            #endregion



            return View(models);
        }

        public List<Treatment> GlobelFilter(string cms , string aqartype, string city, string gada)
        {

            string baseSqlString = "SELECT * FROM Treatment ";
            string query = $"{baseSqlString} {AllWhereCluse(cms, aqartype, city,gada ) } ";

            var rows = _context.Treatment.FromSql(query).Include(d => d.Custmer).Include(d=>d.BankModel).ToList();
            return rows;
        }

        static string AllWhereCluse(string cms, string aqartype, string city, string gada)
        {
            string cmswhere = $"CustmerId = {cms}";

            string aqartypewhere = $"AqarType = N'{aqartype}' ";

            string citywhere = $"city = N'{city}'";

            string gadawhere = $"Gada = N'{gada}'";


            string lastwhere = null;
            string where = "where ";

            int count = 0;


            if (cms != "الكل")
            {
                count = 1;
                lastwhere += where+ cmswhere;
            
            }

            if (aqartype != "الكل")
            {
                if (count == 1)
                {
                    lastwhere += " AND " + aqartypewhere;
                    count = 1;
                }
                else
                {
                    lastwhere += where+ aqartypewhere;
                    count = 1;
                }
            }

            if (city != "الكل")
            {
                if (count == 1)
                {
                    lastwhere += " AND " + citywhere;
                    count = 1;
                }
                else
                {
                    lastwhere += where + citywhere;
                    count = 1;
                }

            }


            if (gada != "الكل")
            {

                if (count == 1)
                {
                    lastwhere += " AND " + gadawhere;
                }
                else
                {
                    lastwhere += where+ gadawhere;
                }

            }
            return lastwhere;

        }

        public async Task<IActionResult> FinCloseforReq(DateTime? date1 = null, DateTime? date2 = null, long? cms = null)
        {
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");
            ViewData["BankId"] = new SelectList(_context.BankModel, "AccountNumber", "Name");
            if (!date1.HasValue)
            {
                date1 = DateTime.Now.Date;
            }

            if (!date2.HasValue)
            {
                date2 = DateTime.Now.Date;
            }
            if (!cms.HasValue)
            {
                cms = _context.Custmer.FirstOrDefault()?.Id;
            }

            List<FinCloseModel> models = new List<FinCloseModel>();

            foreach (var treatment in await _context.Treatment.Include(s => s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose == false  && d.CustmerId == cms).ToListAsync())
            {
                if (treatment != null)
                {

                    models.Add(new FinCloseModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        Scustmer = treatment.Scustmer,
                        Bank = treatment.BankModel.Name,
                        Place = treatment.City + " - " + treatment.Gada,
                        Tbuild = treatment.AqarType,
                        Price = treatment.Price,
                        Id = treatment.Id,
                        Owner = treatment.Owner,
                        FinDate = treatment.DateOfBegin.ToShortDateString(),
                        SNum = treatment.SNum,
                        FinPriceClose = treatment.FinPriceClose,
                        Type = 1

                    });
                }
            }
            foreach (var treatment in await _context.R1Smaple.Include(s => s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose == false && d.CustmerId == cms).ToListAsync())
            {
                if (treatment != null)
                {


                    models.Add(new FinCloseModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        Scustmer = treatment.Scustmer,
                        Bank = treatment.BankModel.Name,
                        Place = treatment.City + " - " + treatment.Gada,
                        Tbuild = treatment.AqarType,
                        Price = treatment.Price,
                        Id = treatment.Id,
                        Owner = treatment.Owner,
                        FinDate = treatment.DateOfBegin.ToShortDateString(),
                        SNum = treatment.SukNumber,
                        FinPriceClose = treatment.FinPriceClose,
                        Type = 2

                    });
                }
            }
            foreach (var treatment in await _context.R2Smaple.Include(s => s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose == false && d.CustmerId == cms).ToListAsync())
            {
                if (treatment != null)
                {


                    models.Add(new FinCloseModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        Scustmer = treatment.Scustmer,
                        Bank = treatment.BankModel.Name,
                        Place = treatment.City + " - " + treatment.Gada,
                        Tbuild = treatment.AqarType,
                        Price = treatment.Price,
                        Id = treatment.Id,
                        Owner = treatment.Owner,
                        FinDate = treatment.DateOfBegin.ToShortDateString(),
                        SNum = treatment.SukNumber,
                        FinPriceClose = treatment.FinPriceClose,
                        Type = 3

                    });
                }
            }

            return View(models);
        }

        public async Task<IActionResult> FinReqReport(DateTime? date1 = null, DateTime? date2 = null , long? cms = null , string bank=null)
        {
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");
            if (!date1.HasValue)
            {
                date1 = DateTime.Now.Date;
            }

            if (!date2.HasValue)
            {
                date2 = DateTime.Now.Date;
            }
            if (!cms.HasValue)
            {
                cms = _context.Custmer.FirstOrDefault()?.Id;
            }
            List<HelpBank> banks = new List<HelpBank>();
            if (bank!=null)
            {

              
                string[] tag1 = bank.Split(',');

                for (int i = 0; i < tag1.Length - 1; i++)
                {
                    string[] tag2 = tag1[i].Split(';');
                    string account = tag2[0];
                    string bankname = tag2[1];
                    banks.Add(new HelpBank(){BankAccount = account ,BankName = bankname, FinCloseModelCmsId =Convert.ToInt64(cms)});

                }


            }

            List<FinCloseModel> models = new List<FinCloseModel>();

            foreach (var treatment in await _context.Treatment.Include(s => s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose == false && d.CustmerId ==cms).ToListAsync())
            {
                if (treatment != null)
                {

                    models.Add(new FinCloseModel()
                    {
                      
                        Custmer = treatment.Custmer.Name,
                        Scustmer = treatment.Scustmer,
                        Bank = treatment.BankModel.Name,
                        Place = treatment.City + " - " + treatment.Gada,
                        Tbuild = treatment.AqarType,
                        Price = treatment.Price,
                        Id = treatment.Id,
                        Owner = treatment.Owner,
                        FinDate = treatment.DateOfBegin.ToShortDateString(),
                        SNum = treatment.SNum,
                        FinPriceClose = treatment.FinPriceClose,   
                        Type = 1

                    });
                }
            }
            foreach (var treatment in await _context.R1Smaple.Include(s => s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose == false && d.CustmerId == cms).ToListAsync())
            {
                if (treatment != null)
                {


                    models.Add(new FinCloseModel()
                    {

                        
                        Custmer = treatment.Custmer.Name,
                        Scustmer = treatment.Scustmer,
                        Bank = treatment.BankModel.Name,
                        Place = treatment.City + " - " + treatment.Gada,
                        Tbuild = treatment.AqarType,
                        Price = treatment.Price,
                        Id = treatment.Id,
                        Owner = treatment.Owner,
                        FinDate = treatment.DateOfBegin.ToShortDateString(),
                        SNum = treatment.SukNumber,
                        FinPriceClose = treatment.FinPriceClose,
                        Type = 2

                    });
                }
            }
            foreach (var treatment in await _context.R2Smaple.Include(s => s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose == false && d.CustmerId == cms).ToListAsync())
            {
                if (treatment != null)
                {

                    models.Add(new FinCloseModel()
                    {
                        
                        Custmer = treatment.Custmer.Name,
                        Scustmer = treatment.Scustmer,
                        Bank = treatment.BankModel.Name,
                        Place = treatment.City + " - " + treatment.Gada,
                        Tbuild = treatment.AqarType,
                        Price = treatment.Price,
                        Id = treatment.Id,
                        Owner = treatment.Owner,
                        FinDate = treatment.DateOfBegin.ToShortDateString(),
                        SNum = treatment.SukNumber,
                        FinPriceClose = treatment.FinPriceClose,
                        Type = 3
                    });
                }
            }



            ReportDataSource reportDataSource = new ReportDataSource();
            ReportDataSource bankDataSource = new ReportDataSource();

            // Qoution Report
            reportDataSource.Name = "DataSetFinreq";
            reportDataSource.Value = models;

            bankDataSource.Name = "DataSetHelpBank";
            bankDataSource.Value = banks;



            LocalReport local = new LocalReport();
            local.DataSources.Add(reportDataSource);

            local.SubreportProcessing += delegate (object sender, SubreportProcessingEventArgs args)
            {
                args.DataSources.Add(bankDataSource);

            };

            local.ReportPath = _env.WebRootPath + "/Report/FinREqReport.rdlc";
            local.EnableExternalImages = true;

            decimal totalprice = (decimal) models.Sum(d => d.Price);
             ToWord toWord = new ToWord(totalprice, new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));

            ReportParameter[] parameters = {
                new ReportParameter("num",toWord.ConvertToArabic()),
                new ReportParameter("clint",_context.Custmer.SingleOrDefault(d=>d.Id == cms)?.FromClint),
                new ReportParameter("cmsid" , cms.ToString()), 

            };

            local.SetParameters(parameters);

            byte[] rendervalue = local.Render("Pdf", "");

            return File(rendervalue, "application/pdf");
        }


        public async Task<IActionResult> FinCloseReport(DateTime? date1 = null, DateTime? date2 = null)
        {
            ViewData["BankId"] = new SelectList(_context.BankModel, "Id", "Name");
            if (!date1.HasValue)
            {
                date1 = DateTime.Now.Date;
            }

            if (!date2.HasValue)
            {
                date2 = DateTime.Now.Date;
            }

            List<FinCloseModel> models = new List<FinCloseModel>();

            foreach (var treatment in await _context.Treatment.Include(s => s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose).ToListAsync())
            {
                if (treatment != null)
                {

                    models.Add(new FinCloseModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        Scustmer = treatment.Scustmer,
                        Bank = treatment.BankModel.Name,
                        Place = treatment.City + " - " + treatment.Gada,
                        Tbuild = treatment.AqarType,
                        Price = treatment.Price,
                        Id = treatment.Id,
                        Owner = treatment.Owner,
                        FinPriceClose = treatment.FinPriceClose,
                        FinPartClose = treatment.FinPartClose == false ? "جزئي" : "كامل",
                        Type = 1

                    });
                }
            }
            foreach (var treatment in await _context.R1Smaple.Include(s => s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose).ToListAsync())
            {
                if (treatment != null)
                {


                    models.Add(new FinCloseModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        Scustmer = treatment.Scustmer,
                        Bank = treatment.BankModel.Name,
                        Place = treatment.City + " - " + treatment.Gada,
                        Tbuild = treatment.AqarType,
                        Price = treatment.Price,
                        Id = treatment.Id,
                        Owner = treatment.Owner,
                        FinPriceClose = treatment.FinPriceClose,
                        FinPartClose = treatment.FinPartClose == false ? "جزئي" : "كامل",
                        Type = 2

                    });
                }
            }

            foreach (var treatment in await _context.R2Smaple.Include(s => s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose).ToListAsync())
            {
                if (treatment != null)
                {


                    models.Add(new FinCloseModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        Scustmer = treatment.Scustmer,
                        Bank = treatment.BankModel.Name,
                        Place = treatment.City + " - " + treatment.Gada,
                        Tbuild = treatment.AqarType,
                        Price = treatment.Price,
                        Id = treatment.Id,
                        Owner = treatment.Owner,
                        FinPriceClose = treatment.FinPriceClose,
                        FinPartClose = treatment.FinPartClose == false ? "جزئي" : "كامل",
                        Type = 3

                    });
                }
            }
            ViewBag.totalpartprice = models.Sum(d => d.FinPriceClose);
            ViewBag.totalprice = models.Sum(d => d.Price);

            return View(models);
        }
        public async Task<IActionResult> FinClose(DateTime? date1 = null, DateTime? date2 = null)
        {
            ViewData["BankId"] = new SelectList(_context.BankModel, "Id", "Name");
            if (!date1.HasValue)
            {
                date1 = DateTime.Now.Date;
            }

            if (!date2.HasValue)
            {
                date2 = DateTime.Now.Date;
            }

            List<FinCloseModel> models = new List<FinCloseModel>();

            foreach (var treatment in await _context.Treatment.Include(s=>s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose == false).ToListAsync())
            {
                if (treatment != null)
                {
                 
                    models.Add(new FinCloseModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        Scustmer = treatment.Scustmer,
                        Bank = treatment.BankModel.Name,
                        Place = treatment.City + " - " + treatment.Gada ,
                        Tbuild = treatment.AqarType,
                        Price = treatment.Price,
                        Id = treatment.Id,
                        Owner = treatment.Owner,
                        FinPriceClose = treatment.FinPriceClose,
                        FinPartClose = treatment.FinPartClose == false ? "ÌÒÆí":"ÎÇáÕ",
                        Type = 1

                    });
                }
            }
            foreach (var treatment in await _context.R1Smaple.Include(s => s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose == false).ToListAsync())
            {
                if (treatment != null)
                {


                    models.Add(new FinCloseModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        Scustmer = treatment.Scustmer,
                        Bank = treatment.BankModel.Name,
                        Place = treatment.City + " - " + treatment.Gada,
                        Tbuild = treatment.AqarType,
                        Price = treatment.Price,
                        Id = treatment.Id,
                        Owner = treatment.Owner,
                        FinPriceClose = treatment.FinPriceClose,
                        FinPartClose = treatment.FinPartClose == false ? "ÌÒÆí" : "ÎÇáÕ",
                        Type = 2

                    });
                }
            }

            foreach (var treatment in await _context.R2Smaple.Include(s => s.BankModel).Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.FinPartClose == false).ToListAsync())
            {
                if (treatment != null)
                {


                    models.Add(new FinCloseModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        Scustmer = treatment.Scustmer,
                        Bank = treatment.BankModel.Name,
                        Place = treatment.City + " - " + treatment.Gada,
                        Tbuild = treatment.AqarType,
                        Price = treatment.Price,
                        Id = treatment.Id,
                        Owner = treatment.Owner,
                        FinPriceClose = treatment.FinPriceClose,
                        FinPartClose = treatment.FinPartClose == false ? "ÌÒÆí" : "ÎÇáÕ",
                        Type = 3

                    });
                }
            }

            return View(models);
        }



        public async Task<IActionResult> GetInvoice(DateTime? date1 = null, DateTime? date2 = null, long? cms = null, string type = null)
        {
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");
            if (!date1.HasValue)
            {
                date1 = DateTime.Now.Date;
            }

            if (!date2.HasValue)
            {
                date2 = DateTime.Now.Date;
            }

            if (type ==null)
            {
                type = "التقييم العقاري";
            }


            List<InvoiceModel> models  = new List<InvoiceModel>();
            if (cms!=null)
            {
                
      
            foreach (var treatment in await _context.Treatment.Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.CustmerId == cms).ToListAsync())
            {
                if (treatment != null)
                {
                    models.Add(new InvoiceModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        DateOfBegin = treatment.DateOfBegin.ToShortDateString(),
                        Price = treatment.Price,
                        SCustmer = treatment.Scustmer,
                        ServiceType = type,
                        Descrip = treatment.AqarType + " - " + treatment.City + " - " + treatment.Gada +
                                  " -معاملة رقم " + treatment.Id

                    });
                }
            }


            foreach (var treatment in await _context.R1Smaple.Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.CustmerId == cms).ToListAsync())
            {
                if (treatment != null)
                {
                    models.Add(new InvoiceModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        DateOfBegin = treatment.DateOfBegin.ToShortDateString(),
                        Price = treatment.Price,
                        SCustmer = treatment.Scustmer,
                        ServiceType = type,
                        Descrip = treatment.AqarType + " - " + treatment.City + " - " + treatment.Gada +
                                  " - معاملة رقم  " + treatment.Id

                    });
                }
            }

            foreach (var treatment in await _context.R2Smaple.Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.CustmerId == cms).ToListAsync())
            {
                if (treatment != null)
                {
                    models.Add(new InvoiceModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        DateOfBegin = treatment.DateOfBegin.ToShortDateString(),
                        Price = treatment.Price,
                        SCustmer = treatment.Scustmer,
                        ServiceType = type,
                        Descrip = treatment.AqarType + " - " + treatment.City + " - " + treatment.Gada +
                                  " -معاملة رقم " + treatment.Id

                    });
                }
            }

            ViewBag.totalprice = models.Sum(d => d.Price);
            }

            return View(models);
        }






        public async Task<IActionResult> GetInvoiceReport(DateTime? date1 = null, DateTime? date2 = null, long? cms = null,string type = null)
        {
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name");
            if (!date1.HasValue)
            {
                date1 = DateTime.Now.Date;
            }

            if (!date2.HasValue)
            {
                date2 = DateTime.Now.Date;
            }
      
            if (type == null)
            {
                type = "التقييم العقاري";
            }

            List<InvoiceModel> models = new List<InvoiceModel>();
            if (cms!=null)
            {

            foreach (var treatment in await _context.Treatment.Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.CustmerId == cms).ToListAsync())
            {
                if (treatment != null)
                {
                    models.Add(new InvoiceModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        DateOfBegin = treatment.DateOfBegin.ToShortDateString(),
                        Price = treatment.Price,
                        SCustmer = treatment.Scustmer,
                        ServiceType = type,
                        Id = treatment.Id
                        ,
                        Descrip = treatment.AqarType + " - " + treatment.City + " - " + treatment.Gada +
                                  " - معاملة رقم " + treatment.Id

                    });
                }
            }

            foreach (var treatment in await _context.R1Smaple.Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.CustmerId == cms).ToListAsync())
            {
                if (treatment != null)
                {
                    models.Add(new InvoiceModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        DateOfBegin = treatment.DateOfBegin.ToShortDateString(),
                        Price = treatment.Price,
                        SCustmer = treatment.Scustmer,
                        ServiceType = type,
                        Id = treatment.Id
                        ,
                        Descrip = treatment.AqarType + " - " + treatment.City + " - " + treatment.Gada +
                                  " - معاملة رقم " + treatment.Id

                    });
                }
            }

            foreach (var treatment in await _context.R2Smaple.Include(d => d.Custmer).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && d.IsUnlockFin && d.CustmerId == cms).ToListAsync())
            {
                if (treatment != null)
                {
                    models.Add(new InvoiceModel()
                    {
                        Custmer = treatment.Custmer.Name,
                        DateOfBegin = treatment.DateOfBegin.ToShortDateString(),
                        Price = treatment.Price,
                        SCustmer = treatment.Scustmer,
                        ServiceType = type,
                        Id = treatment.Id
                        ,
                        Descrip = treatment.AqarType + " - " + treatment.City + " - " + treatment.Gada +
                                  " - معاملة رقم " + treatment.Id

                    });
                }
            }

            }

            ReportDataSource reportDataSource = new ReportDataSource();


            // Qoution Report
            reportDataSource.Name = "DataSet1Invoice";

            reportDataSource.Value = models;

            LocalReport local = new LocalReport();
            local.DataSources.Add(reportDataSource);

            local.ReportPath = _env.WebRootPath + "/Report/Report1.rdlc";
            local.EnableExternalImages = true;
    

           // ToWord toWord = new ToWord((decimal)amount, new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));
     

            byte[] rendervalue = local.Render("Pdf", "");

            return  File(rendervalue, "application/pdf"); 
        }






        // GET: FinModels
        public async Task<IActionResult> GetEmployee(DateTime? date1 = null, DateTime? date2 = null , string emp=null)
        {

            ViewData["ApplicationId"] = new SelectList(_context.Users, "Id", "EmployName");
            if (!date1.HasValue)
            {
                date1 = new DateTime(1753, 1, 1);
            }

            if (!date2.HasValue)
            {
                date2 = new DateTime(9999, 1, 1);
            }
            if (string.IsNullOrEmpty(emp))
            {
                emp = _userManager.GetUserId(User);
            }
            // intering 
            ViewBag.Name = "لا يوجد";
            
            var testName = _context.Users.SingleOrDefault(d => d.Id == emp);
            if (testName !=null)
            {
                ViewBag.Name = testName.EmployName;
            }

            double inter = 0;
            var x = _context.Users.SingleOrDefault(d => d.Id == emp);
            if (x!=null)
            {
                inter = x.InterPercentage;
                if (x.IsInterPercentage)
                {
                    ViewBag.interpercen =  inter + " %";
                }
                else
                {
                    ViewBag.interpercen = inter;
                }
            
            }

            int intercount1 = _context.Treatment.Count(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int intercount2 = _context.R1Smaple.Count(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int intercount3 = _context.R2Smaple.Count(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int intercount=  intercount1 + intercount2 + intercount3;
            ViewBag.intercount = intercount;
            double interprice1 = 0, interprice2 = 0, interprice3 = 0;
            if (x != null)
            {
                if (x.IsInterPercentage)
                {
                    inter = x.InterPercentage / 100;

                    interprice1 = _context.Treatment.Where(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * inter);
                    interprice2 = _context.R1Smaple.Where(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * inter);
                    interprice3 = _context.R2Smaple.Where(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * inter);
                }
                else
                {
                    inter = x.InterPercentage;
                    interprice1 = _context.Treatment.Count(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2) * inter;
                    interprice2 = _context.R1Smaple.Count(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2) * inter;
                    interprice3 = _context.R2Smaple.Count(d => d.Intered == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2) * inter;
                }

            }

            double interprice = interprice1 + interprice2 + interprice3;
            ViewBag.TotalInter = interprice;


            // Thminat
            int muthmincount1 = _context.Treatment.Count(d => d.Muthmen == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int muthmincount2 = _context.R1Smaple.Count(d => d.Muthmen == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int muthmincount3 = _context.R2Smaple.Count(d => d.Muthmen == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int muthmincount = muthmincount1 + muthmincount2 + muthmincount3;
            ViewBag.muthmincount = muthmincount;

            double muthminprice1 = _context.Treatment.Where(d => d.Muthmen == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.MuthminPrice);
            double muthminprice2 = _context.R1Smaple.Where(d => d.Muthmen == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.MuthminPrice);
            double muthminprice3 = _context.R2Smaple.Where(d => d.Muthmen == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.MuthminPrice);
            double muthminprice = muthminprice1 + muthminprice2 + muthminprice3;
            ViewBag.Totalmuthmin = muthminprice;

            // Aduit
            double aduit = 0;
            var testaduit =   _context.Users.SingleOrDefault(d => d.Id == emp);
            if (testaduit!=null)
            {
                aduit = testaduit.AduitPercentage;
                if (testaduit.IsAduitPercentage)
                {
                    ViewBag.aduitpercen = aduit + " %"; 
                }
                else
                {
                    ViewBag.aduitpercen = aduit;
                }
            }
          
            int aduitcount1 = _context.Treatment.Count(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int aduitcount2 = _context.R1Smaple.Count(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int aduitcount3 = _context.R2Smaple.Count(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int aduitcount = aduitcount1 + aduitcount2 + aduitcount3;
            ViewBag.aduitcount = aduitcount;
            double aduitprice1 = 0, aduitprice2 = 0, aduitprice3 = 0;
            if (testaduit!=null)
            {
                if (testaduit.IsAduitPercentage)
                {
                    aduit = testaduit.AduitPercentage / 100;
                    aduitprice1 = _context.Treatment.Where(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * aduit);
                    aduitprice2 = _context.R1Smaple.Where(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * aduit);
                    aduitprice3 = _context.R2Smaple.Where(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * aduit);
                }
                else
                {
                    aduit = testaduit.AduitPercentage;
                    aduitprice1 = _context.Treatment.Count(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2)* aduit;
                    aduitprice2 = _context.R1Smaple.Count(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2) * aduit;
                    aduitprice3 = _context.R2Smaple.Count(d => d.Adutit == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2) * aduit;
                }

            }

         
            double aduitprice = aduitprice1 + aduitprice2 + aduitprice3;
            ViewBag.Totaladuit = aduitprice;
            //aprover
            double aprove = 0;
            var testaprove = _context.Users.SingleOrDefault(d => d.Id == emp);
            if (testaprove !=null)
            {
                aprove = testaprove.AproverPercentage;
                if (testaprove.IsAproverPercentage)
                {
                    ViewBag.aprovepercen = aprove + " %";
                }
                else
                {
                    ViewBag.aprovepercen = aprove;
                }
            }
           
            int aprovecount1 = _context.Treatment.Count(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int aprovecount2 = _context.R1Smaple.Count(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int aprovecount3 = _context.R2Smaple.Count(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2);
            int aprovecount = aprovecount1 + aprovecount2 + aprovecount3;
            ViewBag.aprovecount = aprovecount;
            double aproveprice1 = 0, aproveprice2 = 0, aproveprice3 = 0;
            if (testaprove!=null)
            {
                if (testaprove.IsAproverPercentage)
                {
                    aprove = testaprove.AproverPercentage / 100;
                    aproveprice1 = _context.Treatment.Where(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * aprove);
                    aproveprice2 = _context.R1Smaple.Where(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * aprove);
                    aproveprice3 = _context.R2Smaple.Where(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2).Sum(d => d.Price * aprove);

                }
                else
                {
                    aprove = testaprove.AproverPercentage;
                    aproveprice1 = _context.Treatment.Count(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2)* aprove;
                    aproveprice2 = _context.R1Smaple.Count(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2) * aprove;
                    aproveprice3 = _context.R2Smaple.Count(d => d.Approver == emp & d.DateOfBegin >= date1 & d.DateOfBegin <= date2) * aprove;
                }
            }

            double aproveprice = aproveprice1 + aproveprice2 + aproveprice3;
            ViewBag.Totalaprove = aproveprice;

            ViewBag.TotalCount = intercount + muthmincount + aduitcount + aprovecount;
            ViewBag.TotalPrice = interprice + muthminprice + aduitprice + aproveprice;
            List<FinModel> models = new List<FinModel>();


            foreach (var treatment in await _context.Treatment.Include(d => d.Custmer).ThenInclude(d => d.Sample).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && (d.Intered==emp ||d.Muthmen == emp || d.Adutit ==emp ||  d.Approver == emp) ).ToListAsync())
            {
                if (treatment != null)
                {
                    models.Add(new FinModel()
                    {
                        Id = treatment.Id,
                        Custmer = treatment.Custmer.Name,
                        Tbuild = treatment.AqarType,
                        Owner = treatment.Owner,
                        DateOfBegin = treatment.DateOfBegin.ToShortDateString(),
                        Sample = treatment.Custmer.Sample.Name,
                        Place = treatment.City + " " + treatment.Gada,
                        Price = treatment.Price
                    });
                }
           
            }


            foreach (var treatment in await _context.R1Smaple.Include(d => d.Custmer).ThenInclude(d => d.Sample).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && (d.Intered == emp || d.Muthmen == emp || d.Adutit == emp || d.Approver == emp)).ToListAsync())
            {
                if (treatment != null)
                {
                    models.Add(new FinModel()
                    {
                        Id = treatment.Id,
                        Custmer = treatment.Custmer.Name,
                        Tbuild = treatment.AqarType,
                        Owner = treatment.Owner,
                        DateOfBegin = treatment.DateOfBegin.ToShortDateString(),
                        Sample = treatment.Custmer.Sample.Name,
                        Place = treatment.City + " " + treatment.Gada,
                        Price = treatment.Price
                    });
                }

            }

            foreach (var treatment in await _context.R2Smaple.Include(d => d.Custmer).ThenInclude(d => d.Sample).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2 && (d.Intered == emp || d.Muthmen == emp || d.Adutit == emp || d.Approver == emp)).ToListAsync())
            {
                if (treatment != null)
                {
                    models.Add(new FinModel()
                    {
                        Id = treatment.Id,
                        Custmer = treatment.Custmer.Name,
                        Tbuild = treatment.AqarType,
                        Owner = treatment.Owner,
                        DateOfBegin = treatment.DateOfBegin.ToShortDateString(),
                        Sample = treatment.Custmer.Sample.Name,
                        Place = treatment.City + " " + treatment.Gada,
                        Price = treatment.Price
                    });
                }

            }






            return View(models);
        }


        // GET: FinModels
        public async Task<IActionResult> Index(DateTime? date1=null, DateTime? date2=null )
        {
            // init date
            if (!date1.HasValue)
            {
                date1 = new DateTime(1753, 1 , 1 );
            }

            if (!date2.HasValue)
            {
                date2 = new DateTime(9999, 1, 1);
            }


            List<FinModel> models =  new List<FinModel>();

            foreach (var treatment in await _context.Treatment.Include(d=>d.Custmer).ThenInclude(d=>d.Sample).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2).ToListAsync())
            {


                double inter = 0;
                double adutit = 0;
                double approver = 0;
                var x = _context.Users.SingleOrDefault(d => d.Id == treatment.Intered);
                if (x !=null)
                {
                    if (x.IsInterPercentage)
                    {
                        inter = (x.InterPercentage / 100) * treatment.Price;
                    
                    }
                    else
                    {
                        inter = x.InterPercentage;
                    }
                    
                }
                var y  = _context.Users.SingleOrDefault(d => d.Id == treatment.Adutit);
                if (y!=null)
                {
                    if (y.IsAduitPercentage)
                    {
                        adutit = (y.AduitPercentage / 100) * treatment.Price;
                       
                    }
                    else
                    {
                        adutit = y.AduitPercentage;
                    }
       
                }

                var z = _context.Users.SingleOrDefault(d => d.Id == treatment.Approver);
                if (z != null)
                {
                    if (z.IsAproverPercentage)
                    {
                        approver = (z.AproverPercentage / 100) * treatment.Price;
                    }
                    else
                    {
                        approver = z.AproverPercentage;
                    }
                  
                }

                models.Add(new FinModel()
             {
                   Id = treatment.Id ,Custmer = treatment.Custmer.Name , Tbuild = treatment.AqarType, Owner = treatment.Owner , DateOfBegin = treatment.DateOfBegin.ToShortDateString()
                ,Sample = treatment.Custmer.Sample.Name,Place = treatment.City + " " + treatment.Gada , Price = treatment.Price  , Net = treatment.Price -(inter+ treatment.MuthminPrice + adutit +approver) , InterPrice = inter , MuthmnPrice = treatment.MuthminPrice, AduitPrice = adutit , AproferPrice = approver
             });
                

            }

            foreach (var treatment in await _context.R1Smaple.Include(d => d.Custmer).ThenInclude(d => d.Sample).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2).ToListAsync())
            {
                double inter = 0;
                double adutit = 0;
                double approver = 0;
                var x = _context.Users.SingleOrDefault(d => d.Id == treatment.Intered);
                if (x != null)
                {
                    if (x.IsInterPercentage)
                    {
                        inter = (x.InterPercentage / 100) * treatment.Price;

                    }
                    else
                    {
                        inter = x.InterPercentage;
                    }

                }
                var y = _context.Users.SingleOrDefault(d => d.Id == treatment.Adutit);
                if (y != null)
                {
                    if (y.IsAduitPercentage)
                    {
                        adutit = (y.AduitPercentage / 100) * treatment.Price;

                    }
                    else
                    {
                        adutit = y.AduitPercentage;
                    }

                }

                var z = _context.Users.SingleOrDefault(d => d.Id == treatment.Approver);
                if (z != null)
                {
                    if (z.IsAproverPercentage)
                    {
                        approver = (z.AproverPercentage / 100) * treatment.Price;
                    }
                    else
                    {
                        approver = z.AproverPercentage;
                    }

                }

                models.Add(new FinModel()
                {
                    Id = treatment.Id,
                    Custmer = treatment.Custmer.Name,
                    Tbuild = treatment.AqarType,
                    Owner = treatment.Owner,
                    DateOfBegin = treatment.DateOfBegin.ToShortDateString()
                    ,
                    Sample = treatment.Custmer.Sample.Name,
                    Place = treatment.City + " " + treatment.Gada,
                    Price = treatment.Price,
                    Net = treatment.Price - (inter + treatment.MuthminPrice + adutit + approver),
                    InterPrice = inter,
                    MuthmnPrice = treatment.MuthminPrice,
                    AduitPrice = adutit,
                    AproferPrice = approver
                });


            }

            foreach (var treatment in await _context.R2Smaple.Include(d => d.Custmer).ThenInclude(d => d.Sample).Where(d => d.DateOfBegin >= date1 && d.DateOfBegin <= date2).ToListAsync())
            {
                double inter = 0;
                double adutit = 0;
                double approver = 0;
                var x = _context.Users.SingleOrDefault(d => d.Id == treatment.Intered);
                if (x != null)
                {
                    if (x.IsInterPercentage)
                    {
                        inter = (x.InterPercentage / 100) * treatment.Price;

                    }
                    else
                    {
                        inter = x.InterPercentage;
                    }

                }
                var y = _context.Users.SingleOrDefault(d => d.Id == treatment.Adutit);
                if (y != null)
                {
                    if (y.IsAduitPercentage)
                    {
                        adutit = (y.AduitPercentage / 100) * treatment.Price;

                    }
                    else
                    {
                        adutit = y.AduitPercentage;
                    }

                }

                var z = _context.Users.SingleOrDefault(d => d.Id == treatment.Approver);
                if (z != null)
                {
                    if (z.IsAproverPercentage)
                    {
                        approver = (z.AproverPercentage / 100) * treatment.Price;
                    }
                    else
                    {
                        approver = z.AproverPercentage;
                    }

                }
                models.Add(new FinModel()
                {
                    Id = treatment.Id,
                    Custmer = treatment.Custmer.Name,
                    Tbuild = treatment.BuildType,
                    Owner = treatment.Owner,
                    DateOfBegin = treatment.DateOfBegin.ToShortDateString()
                    ,
                    Sample = treatment.Custmer.Sample.Name,
                    Place = treatment.City + " " + treatment.Gada,
                    Price = treatment.Price,
                    Net = treatment.Price - (inter + treatment.MuthminPrice + adutit + approver),
                    InterPrice = inter,
                    MuthmnPrice = treatment.MuthminPrice,
                    AduitPrice = adutit,
                    AproferPrice = approver
                });


            }


            ViewBag.totalprice = models.Sum(d => d.Price);
            ViewBag.totalNet = models.Sum(d => d.Net);
            ViewBag.totalInterprice = models.Sum(d => d.InterPrice);
            ViewBag.totalMuthmnPrice = models.Sum(d => d.MuthmnPrice);
            ViewBag.totalAduitPrice = models.Sum(d => d.AduitPrice);
            ViewBag.totalAproferPrice = models.Sum(d => d.AproferPrice);

            return View( models);
        }

        // GET: FinModels/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finModel = await _context.FinModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (finModel == null)
            {
                return NotFound();
            }

            return View(finModel);
        }

        // GET: FinModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FinModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sample,Owner,Custmer,Tbuild,Place,DateOfBegin,Price,InterPrice,MuthmnPrice,AproferPrice")] FinModel finModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(finModel);
        }

        // GET: FinModels/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finModel = await _context.FinModel.SingleOrDefaultAsync(m => m.Id == id);
            if (finModel == null)
            {
                return NotFound();
            }
            return View(finModel);
        }

        // POST: FinModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Sample,Owner,Custmer,Tbuild,Place,DateOfBegin,Price,InterPrice,MuthmnPrice,AproferPrice")] FinModel finModel)
        {
            if (id != finModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinModelExists(finModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(finModel);
        }

        // GET: FinModels/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finModel = await _context.FinModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (finModel == null)
            {
                return NotFound();
            }

            return View(finModel);
        }

        // POST: FinModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var finModel = await _context.FinModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.FinModel.Remove(finModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FinModelExists(long id)
        {
            return _context.FinModel.Any(e => e.Id == id);
        }
    }
}
