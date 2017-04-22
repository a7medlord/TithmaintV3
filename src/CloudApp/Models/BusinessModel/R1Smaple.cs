﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudApp.Models.BusinessModel
{
    public class R1Smaple
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public BankModel BankModel { get; set; }
        [Display(Name = "البنك")]
        public long BankModelId { get; set; }
        [Display(Name = "الخاص بالعميل")]
        public string Scustmer { get; set; }
        public Custmer Custmer { get; set; }
        [Display(Name = "العميل")]
        public long CustmerId { get; set; }
        [Display(Name = "المدينة")]
       
        public string City { get; set; }
        [Display(Name = "الحي")]
        public string Gada { get; set; }

        [Display(Name = "رقم الخطط")]
        public string KotatNumber { get; set; }

        [Display(Name = "رقم القطعة")]
        public string PiceNumber { get; set; }

        [Display(Name = "التاريخ")]
        [Column(TypeName = "date")]
        public DateTime DateOfBegin { get; set; } 

        [Display(Name = "رقم البلك")]
        public string BlockNumber { get; set; }

        [Display(Name = "نطاق العقار")]
        public string AqarScope { get; set; }

        [Display(Name = "نوع العقار")]
        public string AqarType { get; set; }
        [Display(Name = "قيمة الاتعاب")]
        public double Price { get; set; }

        [Display(Name = " اتعاب المثمن")]
        public double MuthminPrice { get; set; }
        [Display(Name = "رقم الصك")]
        public string SukNumber { get; set; }
        [Display(Name = "التصميم المعماري")]
        public string ArchDesgin { get; set; }

        [Display(Name = "المنسوب")]
        public string Mansob { get; set; }

        [Display(Name = "حالة المبني")]
        public string BulState { get; set; }

    
        [Display(Name = "شاغلية المبني")]
        public string BuldinIsNull { get; set; }

        [Display(Name = "سفلتة الشوارع")]
        public string RoadSeflt { get; set; }

        [Display(Name = "اضاءه الشوارع")]
        public string RoadLight { get; set; }

        [Display(Name = "عمر العقار")]
        public string AqarAge { get; set; }

        [Display(Name = "الجار مبني")]
        public string JarIsBulding { get; set; }

        [Display(Name = "العقار مرفق")]
        public string AqaraAttachment { get; set; }

        [Display(Name = "نوع المرفق")]
        public string AttchType { get; set; }

        [Display(Name = "نوع التشطيب")]
        public string TshteebType { get; set; }

        [Display(Name = "رقم المبني")]
        public string BuldingNumber { get; set; }

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

        [Display(Name = "مالك العقار")]
        public string Owner { get; set; }

        [Display(Name = "الشارع التجاري")]
        public string MarkterRoad { get; set; }

        // التشطيب
        [Display(Name = "الشمالية")]
        public string InterfcaesNorth { get; set; }

        [Display(Name = "الجنوبيه")]
        public string InterfcaesSouth { get; set; }
        [Display(Name = "الشرقية")]
        public string InterfcaesEast { get; set; }
        [Display(Name = "الغربيه")]
        public string InterfcaesWest { get; set; }

        [Display(Name = "الابواب الخارجية")]
        public string XtrenalDoor { get; set; }

        [Display(Name = "الابواب الداخلة")]
        public string InnerDoor { get; set; }

        //الارضيات

        [Display(Name = "ارضية الاحواش")]
        public string Ahwash { get; set; }

        [Display(Name = "ارضية الاستقبال")]
        public string Rescptions { get; set; }

        [Display(Name = "ارضية المدخل")]
        public string Inner { get; set; }

        [Display(Name = "ارضية الغرف")]
        public string Rooms { get; set; }

        [Display(Name = "الهيكل الانشائي")]
        public string ArchConstract { get; set; }

        [Display(Name = "نوع الاسقف")]
        public string AsqfType { get; set; }

        [Display(Name = "نوع العزل")]
        public string AzlType { get; set; }

        //التكيف
        [Display(Name = "مركزي")]
        public bool IsCetral { get; set; }

        [Display(Name = "صحراوي")]
        public bool IsDesrt { get; set; }

        [Display(Name = "شباك")]
        public bool IsWindo { get; set; }

        [Display(Name = "منفصل")]
        public bool IsSeprat { get; set; }

        //مميزات العقار

        [Display(Name = "حائط مزدوج")]
        public bool IsDoublWall { get; set; }

        [Display(Name = "زجاج مزدوج")]
        public bool IsDoublGlass { get; set; }

        [Display(Name = "جبس للسقف")]
        public bool IsJebsForSaqf { get; set; }

        [Display(Name = "اضاءه مخفية")]
        public bool IsHidingLight { get; set; }

        [Display(Name = "تم اطلاق التيار")]
        public bool IsDonForSndElectric { get; set; }

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

        [Display(Name = "عدادات كهرباء")]
        public bool IsElectricCount { get; set; }

        [Display(Name = "عدادات مياه")]
        public bool IsWaterConut { get; set; }

        [Display(Name = "عداد كهرباء مستقل")]
        public bool IsElectricCountMostgl { get; set; }

        [Display(Name = "عداد مياه مستقل")]
        public bool IsWatrerCountMostgl { get; set; }

        [Display(Name = "خدمات الكهرباء بالحي")]
        public bool IsElectricServicesInGada { get; set; }

        [Display(Name = "خدمات المياه بالحي")]
        public bool IsWaterServicesInGada { get; set; }

        [Display(Name = "العقار مؤثث")]
        public bool AqarIsMosas { get; set; }

        [Display(Name = "عدد عدادات الكهرباء")]
        public string ElcrictyCount { get; set; }

        [Display(Name = "ارقام العدادات")]
        public string ElcrictyNumber { get; set; }

        [Display(Name = "عدد عدادات المياه")]
        public string WatrerCount { get; set; }

        [Display(Name = "ارقام العدادت")]
        public string WaterNumber { get; set; }

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

        [Display(Name = "نسبه الربح")]
        public string ProfitPrecntage { get; set; }

        [Display(Name = "نسبه الاهلاك")]
        public string AhlakPrecentage { get; set; }
        [Display(Name = "التقيم النهائي")]
        public double LastTaqeem { get; set; }

        [Display(Name = "تكاليف الصيانة التقديرية")]
        public string MantinancePrice { get; set; }

        [Display(Name = "رأي المثمن")]
        public string MothmenOpnion { get; set; }

        [Display(Name = "عدد المعارض")]
        public string CountShowromms { get; set; }
        [Display(Name = "تفاصيل الوحدات")]
        public string DetlisShowRooms { get; set; }
        [Display(Name = "الايجار الفعلي")]
        public string EffictiveEjarShowRooms { get; set; }
        [Display(Name = "تقيم العقارات")]
        public string AqarTgeemShowrooms { get; set; }

        [Display(Name = "عدد المكاتب")]
        public string CountForOffice { get; set; }
        [Display(Name = "تفاصيل الوحدات")]
        public string DetlisOffice { get; set; }
        [Display(Name = "الايجار الفعلي")]
        public string EffictiveEjarOffice { get; set; }
        [Display(Name = "تقيم العقارات")]
        public string AqarTgeemOffices { get; set; }

        [Display(Name = "عدد الشقق")]
        public string CountAprtment { get; set; }
        [Display(Name = "تفاصيل الوحدات")]
        public string DetlisApartment { get; set; }
        [Display(Name = "الايجار الفعلي")]
        public string EffictiveEjarApartment { get; set; }
        [Display(Name = "تقيم العقارات")]
        public string AqarTgeem { get; set; }

        [Display(Name = "مجموع الايجارات")]
        public string TotalOfRending { get; set; }

        [Display(Name = "نسبة الدخل")]
        public string IncomePrecentage { get; set; }


        [Display(Name = "عدد المعارض")]
        public string CountshowRoom { get; set; }
        [Display(Name = "الجهة المستأجرة")]
        public string RendingCompnyShowRoom { get; set; }
        [Display(Name = "عدد العقود")]
        public string ContractCountShowRoom { get; set; }
        [Display(Name = "تصنيف المستأجر")]
        public string RendingTypeShowRoom { get; set; }

        [Display(Name = "عدد المكاتب")]
        public string Countoffice { get; set; }
        [Display(Name = "الجهة المستأجرة")]
        public string RendingCompnyoffice { get; set; }
        [Display(Name = "عدد العقود")]
        public string ContractCountoffice { get; set; }
        [Display(Name = "تصنيف المستأجر")]
        public string RendingTypeoffice { get; set; }


        [Display(Name = "عدد الشقق")]
        public string CountAprtmentfor { get; set; }
        [Display(Name = "الجهة المستأجرة")]
        public string RendingCompnyapartment { get; set; }
        [Display(Name = "عدد العقود")]
        public string ContractCountapartment { get; set; }
        [Display(Name = "تصنيف المستأجر")]
        public string RendingTypeapartment { get; set; }


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
        public bool IsUnlockFin { get; set; }
        [Display(Name = "ملاحظات")]
        public string FinNote { get; set; }



        [Display(Name = "تاريخ الاقفال المالي")]
        [Column(TypeName = "date")]
        public DateTime FinDateClose { get; set; } = DateTime.Now.Date;
        [Display(Name = "قيمة الاقفال المالي")]
        public double FinPriceClose { get; set; }
        [Display(Name = "خالص")]
        public bool FinPartClose { get; set; }

        public DateTime DateRiminder { get; set; }

        [NotMapped]
        public DateTime CurrentDateFromClint { get; set; }
    }
}
