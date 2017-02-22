using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudApp.Models.BusinessModel
{
    public class Quotation
    {
        public long Id { get; set; }
        [Description("تاريخ عرض السعر") , DataType(DataType.Date)  ]
        [DisplayFormat(ApplyFormatInEditMode = true , DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime QDate { get; set; }
        public Custmer Custmer { get; set; }
        public long CustmerId { get; set; }
        [Description("مدة الانجاز")]
        public string Complate { get; set; }
        [Description("خاص بالعميل")]
        public string SCustmer { get; set; }
        [Description("الدفعة الاولي")]
        public string FBatch { get; set; }
        public string Bank { get; set; }
        public string Sign { get; set; }
        public List<Instrument> Instruments { get; set; }



        
    }
}
