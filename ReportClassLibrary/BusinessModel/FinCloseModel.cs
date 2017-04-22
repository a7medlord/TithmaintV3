using System.ComponentModel.DataAnnotations;

namespace ReportClassLibrary.BusinessModel
{
    public class FinCloseModel
    {
        public long Id { get; set; }
        [Display(Name = "العميل")]
        public string Custmer { get; set; }

        [Display(Name = "الخاص بالعميل")]
        public string Scustmer { get; set; }

        [Display(Name = "البنك")]
        public string Bank { get; set; }

        [Display(Name = "المالك")]
        public string Owner { get; set; }

        [Display(Name = "نوع العقار")]
        public string Tbuild { get; set; }

        [Display(Name = "المكان")]
        public string Place { get; set; }

        [Display(Name = "ملاحظات")]
        public string FinNote { get; set; }

        [Display(Name = "تاريخ الاقفال ")]
        public string FinDateClose { get; set; }

        [Display(Name = "قيمة الاقفال ")]
        public double FinPriceClose { get; set; }
        [Display(Name = "قيمة الاتعاب")]
        public double Price { get; set; }
        [Display(Name = "الحالة")]
        public string FinPartClose { get; set; }
        [Display(Name = "تاريخ الطلب")]
        public string FinDate { get; set; }

        [Display(Name = "رقم الصك")]
        public string SNum { get; set; }

        public int Type { get; set; }
   

    }
}
