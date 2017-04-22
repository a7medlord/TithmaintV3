using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApp.Models.BusinessModel
{
    public class BankModel
    {
        public long Id { get; set; }
        [Display(Name = "اسم الحساب")]
        public string Name { get; set; }
        [Display(Name = "رقم الحساب")]
        public string AccountNumber { get; set; }

        public List<Treatment> Treatments { get; set; }
        public List<R1Smaple> R1Smaples { get; set; }
        public List<R2Smaple> R2Smaples { get; set; }

    }
}
