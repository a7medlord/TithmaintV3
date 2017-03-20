using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReportClassLibrary.BusinessModel
{
    public class Quotation
    {
        public long Id { get; set; }
        [Description("تاريخ عرض السعر") , Display(Name = "التاريخ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime QDate { get; set; }
        public Custmer Custmer { get; set; }
        [Display(Name = "العميل")]
        public long CustmerId { get; set; }
        [Description("مدة الانجاز"), Display(Name = "مدة الانجاز")]
        public string Complate { get; set; }
        [Description("خاص بالعميل"), Display(Name = "خاص بالعميل")]
        public string SCustmer { get; set; }
        [Description("الدفعة الاولي")  , Display(Name="الدفعة الاولي")]
        public string FBatch { get; set; }
         [Display(Name = "البنك")]
        public string Bank { get; set; }
        [ Display(Name = "التوقيع")]
        public string Sign { get; set; }
        public List<Instrument> Instruments { get; set; } = new List<Instrument>();



        
    }
}
