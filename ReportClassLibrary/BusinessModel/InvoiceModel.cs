using System.ComponentModel.DataAnnotations;

namespace ReportClassLibrary.BusinessModel
{
    public class InvoiceModel
    {
        public long Id { get; set; }
        [Display(Name = "العميل")]
        public string Custmer { get; set; }
        [Display(Name = "عناية")]
        public string SCustmer { get; set; }
        [Display(Name = "تاريخ  الفاتورة")]
        public string DateOfBegin { get; set; }
        [Display(Name = "المبلغ")]
        public double Price { get; set; }
        [Display(Name = "الوصف")]
        public string Descrip { get; set; }

        [Display(Name = "نوع الخدمة")]
        public string ServiceType { get; set; }


    }
}
