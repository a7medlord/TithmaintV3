using System.ComponentModel.DataAnnotations;

namespace CloudApp.Models.BusinessModel
{
    public class Treatment
    {
        public long Id { get; set; }
        public Custmer Custmer { get; set; }
        [Display(Name = "العميل")]
        public long CustmerId { get; set; }
        [Display(Name = "المالك")]
        public string Owner { get; set; }
        [ Display(Name = "اسم عميل البنك")]
        public string SCustmer { get; set; }
        [ Display(Name = "رقم الصك")]
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


        [Display(Name = "رقم القطعة /رقم الشقة")]
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
        public bool IsAduit{ get; set; }
        public bool IsApproved { get; set; }

        //Services
        [Display(Name = "مياه")]
        public bool ServicesWater { get; set; }
        [Display(Name = "هاتف")]
        public bool ServicesPhone { get; set; }
        [Display(Name = "كهرباء")]
        public bool ServicesElectrocitcs { get; set; }
        [Display(Name = "صرف صحي")]
        public bool ServicesSanitation { get; set; }
        [Display(Name = "طرق مسفلتة")]
        public bool ServicesRoad { get; set; }
        [Display(Name = "انارة")]
        public bool ServicesLamp { get; set; }


        //Sround

        [Display(Name = "جامع")]
        public bool SroundMosq { get; set; }

        [Display(Name = "مرفق طبي")]
        public bool Sroundmedicalfacilty { get; set; }

        [Display(Name = "مرفق امني")]
        public bool SroundmedSecurityFacilty { get; set; }
        [Display(Name = "سوق تجاري")]
        public bool SroundSoaq { get; set; }
        [Display(Name = "حديقة")]
        public bool SroundGarden { get; set; }

        [Display(Name = "محطات وقود")]
        public bool SroundFeul { get; set; }
        [Display(Name = "شقق مفروشة")]
        public bool Sroundpartment { get; set; }
        [Display(Name = "فنادق")]
        public bool SroundHotel { get; set; }
        [Display(Name = "مطاعم")]
        public bool SroundRestrant { get; set; }
        [Display(Name = "اسواق عامة")]
        public bool SroundGenralSoaq { get; set; }
        [Display(Name = "اسواق مركزية")]
        public bool SroundCentralSoaq { get; set; }
        [Display(Name = "مراكز طبية")]
        public bool SroundmedicalCenter { get; set; }
        [Display(Name = "مراكز تجارية")]
        public bool SroundComirchalCenter { get; set; }
        [Display(Name = "مستوصفات")]
        public bool SroundDispensares { get; set; }
        [Display(Name = "مستشفيات")]
        public bool SroundHospital { get; set; }
        [Display(Name = "دفاع مدني")]
        public bool SroundciviliDenfencs { get; set; }
        [Display(Name = "بنوك")]
        public bool SroundBank { get; set; }
        [Display(Name = "مدارس")]
        public bool SroundSchools { get; set; }
        [Display(Name = "مركز شرطة")]
        public bool SroundPoilceCenter { get; set; }
        [Display(Name = "دوئر حكومية")]
        public bool SroundGovermentDepartMent { get; set; }
        //Sround end
        [Display(Name = "مسطح البناء")]
        public string Musteh { get; set; }

           [Display(Name = "رأي المثمن")]
          [DataType(DataType.MultilineText)]
        public string MothmnOpnin { get; set; }

        

        //locatins

        [Display(Name = "الموقع العام")]
       public string GenralLocations { get; set; }
        [Display(Name = "شمالا")]
        public string North { get; set; }
        [Display(Name = "جنوبآ")]
        public string South { get; set; }
        [Display(Name = "شرقآ")]
        public string East { get; set; }
        [Display(Name = "غربآ")]
        public string West { get; set; }
        [Display(Name = "بطول")]
        public string NorthTall { get; set; }
        [Display(Name = "بطول")]
        public string SouthTall { get; set; }
        [Display(Name = "بطول")]
        public string EastTall { get; set; }
        [Display(Name = "بطول")]
        public string WestTall { get; set; }

        //end Locations
        [Display(Name = "الملاحظات والنواقص")]
        public string NotesAndAbstracting { get; set; }
        [Display(Name = "تكاليف الصيانة التقديرية")]
        public string MantinCost { get; set; }
        [Display(Name = "القيمة الاجمالية للارض")]
        public string TotalForEarcth { get; set; }
        [Display(Name = "القيمة الاجمالية للبناء")]
        public string TotalBulding { get; set; }
        [Display(Name = "سعر متر الارض")]
        public double MeterPriceForEarth { get; set; }
        [Display(Name = "سعر متر البناء")]
        public double MeterPriceForBulding { get; set; }
        [Display(Name = "القيمة الاجمالية رقما")]
        public double TotalPriceNumber { get; set; }


        [Display(Name = "نطاق العقار")]
        public string GenLoc{ get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "المثمن")]
        public string ApplicationUserId { get; set; }
        public string Muthmen { get; set; }
        public string Adutit { get; set; }
        public string Approver { get; set; }
        public string Intered { get; set; }


    }
}
