using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReportClassLibrary.BusinessModel
{
    public class Custmer
    {
        public long Id { get; set; }
        [Required , Display(Name = "اسم العميل")]
        public string Name { get; set; }
        [Display(Name = "رقم الهاتف")]
        public string Phone { get; set; }
        [Display(Name = "الايميل")]
        public string Email { get; set; }
        public List<Quotation> Quotations { get; set; }
        public List<Treatment> Treatments { get; set; }

        public Sample Sample { get; set; }

        [Display(Name = "النموذج")]
        public long SampleId { get; set; }


    }
}
