using System.ComponentModel.DataAnnotations;

namespace CloudApp.Models.BusinessModel
{
    public class TreamntsModelViewForInddex
    {
        [Display(Name = "رقم المعاملة")]
        public long Id { get; set; }
        [Display(Name = "جهة التقيم")]
        public string SampleId { get; set; }
        [Display(Name = "المثمن")]
        public string Mothmen { get; set; }
        [Display(Name = "العميل")]
        public string Clint { get; set; }
        [Display(Name = "نوع العقار")]
        public string AqarType { get; set; }
        [Display(Name = "المالك")]
        public string Owner { get; set; }
        [Display(Name = "المدينه / الحي")]
        public string CityAndHy { get; set; }
        [Display(Name = "الحـــــــــــــالة")]
        public string State { get; set; }

        [Display(Name = "الزمن المتبقي علي انتهاء المعاملة")]
        public string TimeRimnder { get; set; }

        public int StateColor { get; set; }

        public int Type { get; set; }


    }
}
