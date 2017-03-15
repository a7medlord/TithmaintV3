using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApp.Models.BusinessModel
{
    public class Sample
    {
        public long Id { get; set; }
        [Display(Name = "النموذج")]
        public string Name { get; set; }
        public List<Custmer> Custmers { get; set; }

    }
}
