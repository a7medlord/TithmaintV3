using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudApp.Models.BusinessModel
{
    public class Custmer
    {
        public long Id { get; set; }
        [Required , Display(Name = "اسم العميل")]
        public string Name { get; set; }
        [Display(Name = "رقم الهاتف")]
        public string Phone { get; set; }
        [DisplayName("الايميل")]
        public string Email { get; set; }
        public List<Quotation> Quotations { get; set; }

    }
}
