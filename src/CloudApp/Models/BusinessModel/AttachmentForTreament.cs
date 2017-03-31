using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApp.Models.BusinessModel
{
    public class AttachmentForTreament
    {
        public int Id { get; set; }

        public string AttachmentId { get; set; }

        public Treatment Treatment { get; set; }

        public long TreatmentId { get; set; }
    }
}
