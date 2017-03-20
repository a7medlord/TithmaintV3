using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudApp.Models.BusinessModel
{
    public class Instrument
    {
        public long Id { get; set; }
        [Description("رقم الصك"), Display(Name = "رقم الصك")]
        public string SNum { get; set; }
        [Description("وصف العقار"), Display(Name = "وصف العقار ")]
        public string BDiscrib { get; set; }
        [ Display(Name = "المساحة ")]
        public string Area { get; set; }
        [Description("الموقع"), Display(Name = "الموقع")]
        public string Locat { get; set; }
        [Description("قيمةالاتعاب"), Display(Name = " قيمة الاتعاب")]
        public double Amount { get; set; }
        
        public Quotation Quotation { get; set; }
        public long QuotationId { get; set; }
    }
}
