using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudApp.Models.BusinessModel
{
    public class Treatment
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
      
        public Custmer Custmer { get; set; }
        [Display(Name = "العميل")]
        public long CustmerId { get; set; }
        public BankModel BankModel { get; set; }
        [Display(Name = "البنك")]
        public long BankModelId { get; set; }
        [Display(Name = "الخاص بالعميل")]
        public string Scustmer { get; set; }
        [Display(Name = "المالك")]
        public string Owner { get; set; }
       
        [ Display(Name = "رقم الصك")]
        public string SNum { get; set; }
        [Display(Name = "تاريخ الصك")]
        public string DateSNum { get; set; }
        [Display(Name = "المدينة")]
        public string City { get; set; }
        [Display(Name = "الحي")]
        public string Gada { get; set; }

        [Display(Name = "التاريخ")]
        [Column(TypeName = "date")]
        public DateTime DateOfBegin { get; set; }
        [Display(Name = "الموقع")]
        public string Local { get; set; }
        [Display(Name = "اسم الشارع")]
        public string Street { get; set; }

        [Display(Name = "رقم المخطط")]
        public string Plane { get; set; }
        [Display(Name = "نوع العقار")]
        public string AqarType { get; set; }

        [Display(Name = "قيمة الاتعاب")]
        public double Price { get; set; }
        [Display(Name = " اتعاب المثمن")]
        public double MuthminPrice { get; set; }

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
        public bool IsUnlockFin { get; set; }


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



        // حساب مسطح البناء

        [Display(Name = "المساحة")]
        public double AreaEarth { get; set; }

        [Display(Name = "سعر المتر")]
        public double MeterPriceEarh { get; set; }

        [Display(Name = "المجموع")]
        public double TotalEarh { get; set; }

        [Display(Name = "المساحة")]
        public double AreaQabo { get; set; }

        [Display(Name = "سعر المتر")]
        public double MeterPriceQabo { get; set; }

        [Display(Name = "المجموع")]
        public double TotalQabo { get; set; }

        [Display(Name = "المساحة")]
        public double AreaDorEarth { get; set; }

        [Display(Name = "سعر المتر")]
        public double MeterPriceDorEarth { get; set; }

        [Display(Name = "المجموع")]
        public double TotalDorerath { get; set; }

        [Display(Name = "المساحة")]
        public double AreaFirstDoor { get; set; }

        [Display(Name = "سعر المتر")]
        public double MeterPriceFirstDoor { get; set; }

        [Display(Name = "المجموع")]
        public double TotalFirstDoor { get; set; }

        [Display(Name = "المساحة")]
        public double AreareptDoor { get; set; }

        [Display(Name = "سعر المتر")]
        public double MeterPriceReptDoor { get; set; }

        [Display(Name = "المجموع")]
        public double TotalReptDoor { get; set; }

        [Display(Name = "المساحة")]
        public double AreaApnedxEarth { get; set; }

        [Display(Name = "سعر المتر")]
        public double MeterPriceApendexErth { get; set; }

        [Display(Name = "المجموع")]
        public double TotalApendxEarth { get; set; }

        [Display(Name = "المساحة")]
        public double AreaApendxup { get; set; }

        [Display(Name = "سعر المتر")]
        public double MeterPriceapendxup { get; set; }

        [Display(Name = "المجموع")]
        public double Totalapendxup { get; set; }

        [Display(Name = "المساحة")]
        public double AreaSwar { get; set; }

        [Display(Name = "سعر المتر")]
        public double MeterPriceAsawr { get; set; }

        [Display(Name = "المجموع")]
        public double TotalAswar { get; set; }

        [Display(Name = "المساحة")]
        public double Areagarden { get; set; }

        [Display(Name = "سعر المتر")]
        public double MeterPricegarden { get; set; }

        [Display(Name = "المجموع")]
        public double Totalgarden { get; set; }

        [Display(Name = "المساحة")]
        public double AreaSwimingpool { get; set; }

        [Display(Name = "سعر المتر")]
        public double MeterPriceswiminpoo { get; set; }

        [Display(Name = "المجموع")]
        public double Totalswimingpool { get; set; }

        [Display(Name = "المساحة")]
        public double AreaCars { get; set; }

        [Display(Name = "سعر المتر")]
        public double MeterPriceCars { get; set; }

        [Display(Name = "المجموع")]
        public double TotalCars { get; set; }

        [Display(Name = "المساحة")]
        public double AreaOthers { get; set; }

        [Display(Name = "سعر المتر")]
        public double MeterPriceothers { get; set; }

        [Display(Name = "المجموع")]
        public double Totalothers { get; set; }


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
        public double MantinCost { get; set; }
        [Display(Name = "القيمة الاجمالية للارض")]
        public double TotalForEarcth { get; set; }
        [Display(Name = "القيمة الاجمالية للبناء")]
        public double TotalBulding { get; set; }
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
        [Display(Name = "ملاحظات")]
        public string FinNote { get; set; }

        [Display(Name = "تاريخ الاقفال المالي")]
        [Column(TypeName = "date")]
        public DateTime FinDateClose { get; set; } = DateTime.Now.Date;
        [Display(Name = "قيمة الاقفال المالي")]
        public double FinPriceClose { get; set; }
        [Display(Name = "خالص")]
        public bool FinPartClose { get; set; }

        public List<AttachmentForTreament> AttachmentForTreaments { get; set; }
        [Display(Name = "خــط طول")]
        public string Longtute { get; set; }
        [Display(Name = "خــط العرض")]
        public string Latute { get; set; }

        public DateTime DateRiminder { get; set; }

        [NotMapped]
        public DateTime CurrentDateFromClint { get; set; }


        public string Fincial { get; set; }
    }
}
