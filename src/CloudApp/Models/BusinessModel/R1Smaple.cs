using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApp.Models.BusinessModel
{
    public class R1Smaple
    {
        public long Id { get; set; }
        public Custmer Custmer { get; set; }
        [Display(Name = "العميل")]
        public long CustmerId { get; set; }
        [Display(Name = "المالك")]
        public string Owner { get; set; }
        [Display(Name = "اسم عميل البنك")]
        public string SCustmer { get; set; }
        [Display(Name = "رقم الصك")]
        public string SNum { get; set; }
        [Display(Name = "تاريخ الصك")]
        public string DateSNum { get; set; }
        [Display(Name = "المدينة")]
        public string City { get; set; }
        [Display(Name = "الحي")]
        public string Gada { get; set; }

        [Display(Name = "الموقع")]
        public string Local { get; set; }
        [Display(Name = "اسم الشارع")]
        public string Street { get; set; }

        [Display(Name = "رقم المخطط")]
        public string Plane { get; set; }
        [Display(Name = "نوع العقار")]
        public string Tbuild { get; set; }

        [Display(Name = "خضوع العقار لنظام الارض البيضاء")]
        public string Wland { get; set; }

        [Display(Name = "اسباب الخضوع")]
        public string ResWland { get; set; }


        [Display(Name = "رقم القطعة")]
        public string Npiece { get; set; }

        [Display(Name = "رقم الشقة")]
        public string Napartment { get; set; }

        [Display(Name = "مساحة الارض")]
        public string Area { get; set; }

        [Display(Name = "عمر العقار")]
        public string Agbuild { get; set; }

        [Display(Name = "شاغلية العقار")]
        public string OccBuild { get; set; }

        [Display(Name = "حالة البناء")]
        public string CaseBuild { get; set; }
        [Display(Name = "اسلوب البناء")]
        public string StyleBuild { get; set; }
        //is function
        public bool IsIntered { get; set; }
        public bool IsThmin { get; set; }
        public bool IsAduit { get; set; }
        public bool IsApproved { get; set; }

        // pluse
        [Display(Name = "تم اطلاق التيار")]
        public bool ElictFire { get; set; }
        [Display(Name = " التكييف")]
        public bool Acce { get; set; }

    }
}
