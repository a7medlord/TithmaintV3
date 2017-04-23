﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace ReportClassLibrary.BusinessModel
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string EmployName { get; set; }

        public string IdentityId { get; set; }

        public string MemberId { get; set; }

        public string MemberPhotoId { get; set; }

        public string ProfilePic { get; set; }

        public string IdenetityPic { get; set; }

        public string SigImage { get; set; }

        public List<Quotation> Quotations { get; set; }
       
    }
}
