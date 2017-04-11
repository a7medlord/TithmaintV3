using System.ComponentModel.DataAnnotations;

namespace CloudApp.Models.BusinessModel
{
    public class Flag
    {
        public long Id { get; set; }
       [Display(Name = "اسم القيمة المضافة")]
        public string Value { get; set; }
        public long FlagValue { get; set; }
    }
}
