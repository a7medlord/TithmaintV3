using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApp.Models.BusinessModel
{
    public class FinModel
    {
        public long Id { get; set; }
        [Display(Name = "العميل")]
        public string Sample { get; set; }
        [Display(Name = "المالك")]
        public string Owner { get; set; }
        [Display(Name = "طالب التقييم")]
        public string Custmer { get; set; }
        [Display(Name = "نوع العقار")]
        public string Tbuild { get; set; }

        [Display(Name = "مكان العقار")]
        public string Place { get; set; }

        [Display(Name = "تاريخ  الطلب")]
        public string DateOfBegin { get; set; }

        [Display(Name = "قيمة الاتعاب")]
        public double Price { get; set; }

        [Display(Name = " اتعاب المدخل")]
        public double InterPrice { get; set; }

        [Display(Name = " اتعاب المثمن")]
        public double MuthmnPrice { get; set; }

        [Display(Name = " اتعاب المقيم")]
        public double AduitPrice { get; set; }

        [Display(Name = " اتعاب المشرفين")]
        public double AproferPrice { get; set; }

        [Display(Name = " الصافي")]
        public double Net { get; set; }

    }
}
