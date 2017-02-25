using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudApp.Models.BusinessModel
{
    public class Custmer
    {
        public long Id { get; set; }
        [Required , DisplayName("اسم العميل")]
        public string Name { get; set; }
        [DisplayName("رقم الهاتف")]
        public string Phone { get; set; }
        [DisplayName("الايميل")]
        public string Email { get; set; }
        public List<Quotation> Quotations { get; set; }

    }
}
