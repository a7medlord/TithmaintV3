using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApp.Models.BusinessModel
{
    public class R2Smaple
    {
        public long Id { get; set; }

        [Display(Name = "نوع المبني")]
        public string BuldingType { get; set; }
        [Display(Name = "مالك العقار")]
        public string Owner { get; set; }
        [Display(Name = "تاريخ التسليم")]
        public DateTime DelverDate { get; set; }

        [Display(Name = "رقم الطلب ")]
        public string Talabnum { get; set; }
        public Custmer Custmer { get; set; }
        [Display(Name = "العميل")]
        public long CustmerId { get; set; }
        [Display(Name = "رقم الصك")]
        public string SukNumber { get; set; }
        [Display(Name = "تاريخ الصك")]
        public DateTime SukDate { get; set; }
                [Display(Name = "فسح البناء ")]
        public string FushBuild { get; set; }
        [Display(Name = "تاريخ فسح البناء")]
        public string FushBuildDate { get; set; }
        [Display(Name = "عمر العقار")]
        public string AqarAge { get; set; }
        [Display(Name = "نوع المبني")]
        public string BuildType { get; set; }
        [Display(Name = "شاغلية المبني")]
        public string BuldinIsNull { get; set; }
        [Display(Name = "المدينة")]
        public string City { get; set; }
        [Display(Name = "الحي")]
        public string Gada { get; set; }
        [Display(Name = "رقم المخطط")]
        public string KotatNumber { get; set; }
        [Display(Name = "رقم القطعة")]
        public string PiceNumber { get; set; }
        [Display(Name = "رقم البلك")]
        public string BlockNumber { get; set; }
        //حدود العقار
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
        [Display(Name = "اقرب الشارع ")]
        public string NearRoad { get; set; }

        [Display(Name = "الموقع العام")]
        public string Genloc { get; set; }

        [Display(Name = "تصنيف العقار")]
        public string Aqarclass { get; set; }

        [Display(Name = "التصميم المعماري")]
        public string ArchDesgin { get; set; }

        [Display(Name = "المنسوب")]
        public string Mansob { get; set; }



        // Street
        [Display(Name = "مسفلتة")]
        public bool Streetsok { get; set; }
        [Display(Name = "غير مسفلته")]
        public bool Streetsno { get; set; }
        [Display(Name = "مضاءة")]
        public bool Streetslite { get; set; }
        [Display(Name = "غي مضاءة")]
        public bool Streetsnolite { get; set; }

        [Display(Name = "الجار مبني")]
        public bool JarIsBulding { get; set; }
        [Display(Name = "حالة المبني")]
        public string BulState { get; set; }
        [Display(Name = "تم اطلاق التيار")]
        public bool IsDonForSndElectric { get; set; }
        //الارضيات

        [Display(Name = "ارضية الاحواش")]
        public string Ahwash { get; set; }

        [Display(Name = "ارضية الاستقبال")]
        public string Rescptions { get; set; }

        [Display(Name = "ارضية المدخل")]
        public string Inner { get; set; }

        [Display(Name = "ارضية الغرف")]
        public string Rooms { get; set; }

        // التشطيب
        [Display(Name = "الواجهة الشمالية")]
        public string InterfcaesNorth { get; set; }

        [Display(Name = "الواجهة الجنوبيه")]
        public string InterfcaesSouth { get; set; }
        [Display(Name = "الواجهة الشرقية")]
        public string InterfcaesEast { get; set; }
        [Display(Name = "الواجهة الغربيه")]
        public string InterfcaesWest { get; set; }

        [Display(Name = "الابواب الخارجية")]
        public string XtrenalDoor { get; set; }

        [Display(Name = "الابواب الداخلة")]
        public string InnerDoor { get; set; }

        //مميزات العقار

        [Display(Name = "حائط مزدوج")]
        public bool IsDoublWall { get; set; }

        [Display(Name = "زجاج مزدوج")]
        public bool IsDoublGlass { get; set; }

        [Display(Name = "جبس للسقف")]
        public bool IsJebsForSaqf { get; set; }

        [Display(Name = "اضاءه مخفية")]
        public bool IsHidingLight { get; set; }
        [Display(Name = "كراج كهربائي")]
        public bool IsKrajEletcru { get; set; }

        [Display(Name = "سلالم")]
        public bool IslAder { get; set; }

        [Display(Name = "كراج عادي")]
        public bool IsNormalKraj { get; set; }

        [Display(Name = "بوابات")]
        public bool IsGates { get; set; }

        [Display(Name = "مصاعد")]
        public bool IsLifts { get; set; }

        [Display(Name = "سخانات")]
        public bool Ishoter { get; set; }

        [Display(Name = "حمام عربي")]
        public bool IsArbicTut { get; set; }

        [Display(Name = "حمام افرنجي")]
        public bool IsForinTut { get; set; }

        //التكيف
        [Display(Name = "مركزي")]
        public bool IsCetral { get; set; }

        [Display(Name = "صحراوي")]
        public bool IsDesrt { get; set; }

        [Display(Name = "شباك")]
        public bool IsWindo { get; set; }

        [Display(Name = "منفصل")]
        public bool IsSeprat { get; set; }

        // 

        [Display(Name = "هيكل انشائي")]
        public string Civelprat { get; set; }
        [Display(Name = "نوع  الاشقف")]
        public string Rooftype { get; set; }

        [Display(Name = "الابوب الخارجية")]
        public string Doorout { get; set; }
        [Display(Name = "الأبوب  الداخلية")]
        public string Doorin { get; set; }

        [Display(Name = "نوع  العزل")]
        public string SaprateType { get; set; }

        // تقييم الارض والمباني

        [Display(Name = "عدد عدادات الكهرباء")]
        public string ElcrictyCount { get; set; }

        [Display(Name = "ارقام العدادات")]
        public string ElcrictyNumber { get; set; }

        [Display(Name = "عدد عدادات المياه")]
        public string WatrerCount { get; set; }

        [Display(Name = "ارقام العدادت")]
        public string WaterNumber { get; set; }
        [Display(Name = "حالة وجود اكثر من عداد ")]
        public string CaseNumber { get; set; }


        //  ايجار
        [Display(Name = "عدد الشقق")]
        public string CountAprtment { get; set; }

        [Display(Name = "ايجار  الشقق")]
        public string  RentAprtment { get; set; }

        [Display(Name = "عدد المحلات التجارية")]
        public string CountTretment { get; set; }

        [Display(Name = "ايجار   المحلات التجارية")]
        public string RentTretment { get; set; }


        [Display(Name = "العقار مؤجر ")]
        public bool Aqarisrent { get; set; }

        [Display(Name = "العقار متوقع ايجاره  ")]
        public bool Aqarissoonrent { get; set; }

        [Display(Name = "به صيانة ")]
        public bool Mantinance { get; set; }

        [Display(Name = "اسباب الصيانة ")]
        public string MantinanceReson { get; set; }

        [Display(Name = "تكاليف الصيانة التقديرية")]
        public string MantinancePrice { get; set; }

        [Display(Name = "رأي المثمن")]
        public string MothmenOpnion { get; set; }

        [Display(Name = " ملاحظات المثمن")]
        public string Mothmennote { get; set; }

        [Display(Name = "شكل الأرض")]
        public string LandShape { get; set; }

        [Display(Name = "موقع العقار بالنسبة للمدينة")]
        public string Aqarforcity { get; set; }
        [Display(Name = "موقع العقار بالنسبة للمخطط")]
        public string Aqarforplane{ get; set; }

        [Display(Name = "نظام الادوار المسموح  بها")]
        public string Toor { get; set; }

        [Display(Name = "الاستخدام الحالي للعقار ")]
        public string AqarUse { get; set; }
        [Display(Name = "الاستخدام الامثل للعقار ")]
        public string AqarPerfect { get; set; }

        [Display(Name = "سعر المتر السكني ")]
        public string Meterpricehouse { get; set; }
        [Display(Name = "سعر المتر التجاري ")]
        public string Meterpricetreentment { get; set; }
        //طريقة التقييم



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

        //service
        [Display(Name = "مساجد")]
        public bool SroundMosq { get; set; }
        [Display(Name = "تشجير")]
        public bool SroundTree { get; set; }

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
        [Display(Name = "تصريف سيول")]
        public bool SroundSeoul { get; set; }
        [Display(Name = "مستوصفات")]
        public bool SroundDispensares { get; set; }
        [Display(Name = "مستشفيات")]
        public bool SroundHospital { get; set; }
        [Display(Name = "دفاع مدني")]
        public bool SroundciviliDenfencs { get; set; }
        [Display(Name = "بنوك")]
        public bool SroundBank { get; set; }
        [Display(Name = "تعليم")]
        public bool SroundSchools { get; set; }
        [Display(Name = "رصف")]
        public bool Sroundrasf { get; set; }
        [Display(Name = "مركز شرطة")]
        public bool SroundPoilceCenter { get; set; }
        [Display(Name = "دوئر حكومية")]
        public bool SroundGovermentDepartMent { get; set; }







        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "المثمن")]
        public string ApplicationUserId { get; set; }
        public string Muthmen { get; set; }
        public string Adutit { get; set; }
        public string Approver { get; set; }
        public string Intered { get; set; }

        public List<AttachmentForR1Sample> AttachmentForR1Samples { get; set; }
        [Display(Name = "خــط طول")]
        public string Longtute { get; set; }
        [Display(Name = "خــط العرض")]
        public string Latute { get; set; }


        public bool IsIntered { get; set; }
        public bool IsThmin { get; set; }
        public bool IsAduit { get; set; }
        public bool IsApproved { get; set; }


    }
}
