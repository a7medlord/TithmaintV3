using System.ComponentModel;

namespace CloudApp.Models.BusinessModel
{
    public class Instrument
    {
        public long Id { get; set; }
        [Description("رقم الصك"), DisplayName("رقم الصك")]
        public string SNum { get; set; }
        [Description("وصف العقار"), DisplayName("وصف العقار ")]
        public string BDiscrib { get; set; }
        [ DisplayName("المساحة ")]
        public string Area { get; set; }
        [Description("الموقع"), DisplayName("الموقع")]
        public string Locat { get; set; }
        [Description("قيمةالاتعاب"), DisplayName(" قيمة الاتعاب")]
        public string Amount { get; set; }
        
        public Quotation Quotation { get; set; }
        public long QuotationId { get; set; }
    }
}
