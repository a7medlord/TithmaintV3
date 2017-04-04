using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CloudApp.Models.BusinessModel
{
    public class R2Smaple
    {

        //comment
        public long Id { get; set; }

        [Display(Name = "نوع العقار")]
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

        //الموقع العام
        [Display(Name = "داخل النطاق")]
        public bool GenralInnerScope { get; set; }

        [Display(Name = "المرحلة الاولي")]
        public bool GenralFirstLevel { get; set; }

        [Display(Name = "المرحلة الثانية")]
        public bool GenralTowLevel { get; set; }

        [Display(Name = "خارج النطاق")]
        public bool GenralExteranlScope { get; set; }


        //تصنيف العقار

        [Display(Name = "سكني")]
        public bool ClassHome { get; set; }

        [Display(Name = "تجاري")]
        public bool ClassComirctal { get; set; }

        [Display(Name = "سكني تجاري")]
        public bool ClassHomeAndComrictal { get; set; }

        [Display(Name = "اخري")]
        public bool ClassOthers { get; set; }


        //التصميم

        [Display(Name = "رديئ")]
        public bool DesinBad { get; set; }
        [Display(Name = "جيد")]
        public bool DesinGood { get; set; }

        [Display(Name = "ممتاز")]
        public bool DesinExlant { get; set; }


        //المنسووب
        [Display(Name = "مرتفع")]
        public bool MansobHeigh { get; set; }
        [Display(Name = "مستوي")]
        public bool MansobLevl { get; set; }

        [Display(Name = "منخفض")]
        public bool MansobLow { get; set; }


        // Street
        [Display(Name = "مسفلتة")]
        public bool Streetsok { get; set; }
        [Display(Name = "غير مسفلته")]
        public bool Streetsno { get; set; }
        [Display(Name = "مضاءة")]
        public bool Streetslite { get; set; }
        [Display(Name = "غي مضاءة")]
        public bool Streetsnolite { get; set; }


        //الجار
        
        [Display(Name = "الجار مبني")]
        public bool JarIsBulding { get; set; }



        // حاله المبني
        [Display(Name = "رديئ")]
        public bool BuldingTypeBad { get; set; }

        [Display(Name = "جيد")]
        public bool BuldingTypeGood { get; set; }

        [Display(Name = "ممتاز")]
        public bool BuldingTypeExlant { get; set; }




        [Display(Name = "تم اطلاق التيار")]
        public bool IsDonForSndElectric { get; set; }

        [Display(Name = "نوع التشطيب")]
        public bool Tashtibtype { get; set; }


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




        // هيكل انشائي

        [Display(Name = "خرساني")]
        public bool ArchKrsany { get; set; }
        [Display(Name = "حوائط حاملة")]
        public bool ArchWallBlanc { get; set; }

        [Display(Name = "مباني معدنية")]
        public bool ArchMatrialBulding { get; set; }

        [Display(Name = "مباني خشبية")]
        public bool ArchWood { get; set; }




        //نوع الاسقف

        [Display(Name = "خرسانة مسلحة")]
        public bool AsqfKrsany { get; set; }

        [Display(Name = "كمرات حديدية")]
        public bool AsqfMatrialCamer { get; set; }
        [Display(Name = "كمرات خشبية")]
        public bool AsqfWoodCamer { get; set; }

        [Display(Name = "اخري")]
        public bool AsqfOthers { get; set; }




        [Display(Name = "الابوب الخارجية")]
        public string Doorout { get; set; }
        [Display(Name = "الأبوب  الداخلية")]
        public string Doorin { get; set; }

        [Display(Name = "نوع  العزل")]
        public string SaprateType { get; set; }



        // خدمات الكهرباء والمياه بالمبني
        

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


        //المسح الشامل

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
        [Display(Name = "المساحة")]
        public string AreaEarth { get; set; }

        [Display(Name = "سعر المتر")]
        public string MeterPriceEarh { get; set; }

        [Display(Name = "المجموع")]
        public string TotalEarh { get; set; }

        [Display(Name = "المساحة")]
        public string AreaQabo { get; set; }

        [Display(Name = "سعر المتر")]
        public string MeterPriceQabo { get; set; }

        [Display(Name = "المجموع")]
        public string TotalQabo { get; set; }

        [Display(Name = "المساحة")]
        public string AreaDorEarth { get; set; }

        [Display(Name = "سعر المتر")]
        public string MeterPriceDorEarth { get; set; }

        [Display(Name = "المجموع")]
        public string TotalDorerath { get; set; }

        [Display(Name = "المساحة")]
        public string AreaFirstDoor { get; set; }

        [Display(Name = "سعر المتر")]
        public string MeterPriceFirstDoor { get; set; }

        [Display(Name = "المجموع")]
        public string TotalFirstDoor { get; set; }

        [Display(Name = "المساحة")]
        public string AreareptDoor { get; set; }

        [Display(Name = "سعر المتر")]
        public string MeterPriceReptDoor { get; set; }

        [Display(Name = "المجموع")]
        public string TotalReptDoor { get; set; }

        [Display(Name = "المساحة")]
        public string AreaApnedxEarth { get; set; }

        [Display(Name = "سعر المتر")]
        public string MeterPriceApendexErth { get; set; }

        [Display(Name = "المجموع")]
        public string TotalApendxEarth { get; set; }

        [Display(Name = "المساحة")]
        public string AreaApendxup { get; set; }

        [Display(Name = "سعر المتر")]
        public string MeterPriceapendxup { get; set; }

        [Display(Name = "المجموع")]
        public string Totalapendxup { get; set; }

        [Display(Name = "المساحة")]
        public string AreaSwar { get; set; }

        [Display(Name = "سعر المتر")]
        public string MeterPriceAsawr { get; set; }

        [Display(Name = "المجموع")]
        public string TotalAswar { get; set; }

        [Display(Name = "المساحة")]
        public string Areagarden { get; set; }

        [Display(Name = "سعر المتر")]
        public string MeterPricegarden { get; set; }

        [Display(Name = "المجموع")]
        public string Totalgarden { get; set; }

        [Display(Name = "المساحة")]
        public string AreaSwimingpool { get; set; }

        [Display(Name = "سعر المتر")]
        public string MeterPriceswiminpoo { get; set; }

        [Display(Name = "المجموع")]
        public string Totalswimingpool { get; set; }

        [Display(Name = "المساحة")]
        public string AreaCars { get; set; }

        [Display(Name = "سعر المتر")]
        public string MeterPriceCars { get; set; }

        [Display(Name = "المجموع")]
        public string TotalCars { get; set; }

        [Display(Name = "المساحة")]
        public string AreaOthers { get; set; }

        [Display(Name = "سعر المتر")]
        public string MeterPriceothers { get; set; }

        [Display(Name = "المجموع")]
        public string Totalothers { get; set; }

        [Display(Name = "نسبه الربح")]
        public string ProfitPrecntage { get; set; }

        [Display(Name = "نسبه الاهلاك")]
        public string AhlakPrecentage { get; set; }
        [Display(Name = "التقيم النهائي")]
        public double LastTaqeem { get; set; }





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

        public List<AttachmentForR2Sample> AttachmentForR2Samples { get; set; }

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
