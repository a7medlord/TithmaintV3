using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudApp.Models.BusinessModel
{
    public class Custmer
    {
        public long Id { get; set; }
        [Required]
        
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Quotation> Quotations { get; set; }

    }
}
