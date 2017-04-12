using System.Collections.Generic;
using CloudApp.Models.BusinessModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CloudApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string EmployName { get; set; }

        public string IdentityId { get; set; }

        public string MemberId { get; set; }
        public double InterPercentage { get; set; }
        public bool IsInterPercentage { get; set; }
        public double MuthminPercentage { get; set; }
        public bool IsMuthminPercentage { get; set; }
        public double AduitPercentage { get; set; }
        public bool IsAduitPercentage { get; set; }
        public double AproverPercentage { get; set; }
        public bool IsAproverPercentage { get; set; }
        public double SupervisionPercentage { get; set; }
        public bool IsSupervisionPercentage { get; set; }

        public string MemberPhotoId { get; set; }

        public string ProfilePic { get; set; }

        public string IdenetityPic { get; set; }

        public string SigImage { get; set; }


        public List<Quotation> Quotations { get; set; }

        public List<Treatment> Treatments { get; set; }

        public List<R1Smaple> R1Smaples { get; set; }
    }
}
