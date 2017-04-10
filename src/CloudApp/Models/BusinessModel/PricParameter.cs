using System;
using System.ComponentModel.DataAnnotations;

namespace CloudApp.Models.BusinessModel
{
    public class PricParameter
    {
        [Display(Name = "نوع العقار")]
        public string TypeOfAqar { get; set; }
        [Display(Name = "من")]
        public DateTime From { get; set; }
        [Display(Name = "المدينة")]
        public string City { get; set; }
        [Display(Name = "الحي")]
        public string Gada { get; set; }
        [Display(Name = "الي")]
        public DateTime To { get; set; }
    }
}
