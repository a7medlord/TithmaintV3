using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace CloudApp.Models.BusinessModel
{
    public class AutoIncresTable
    {
        public long Id { get; set; }
        public long LastId { get; set; }
    }
}
