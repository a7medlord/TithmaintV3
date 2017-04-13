using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudApp.Data;
using CloudApp.Models.BusinessModel;
using CloudApp.RepoInterFace;
using Microsoft.EntityFrameworkCore;

namespace CloudApp.RepositoriesClasses
{
    public class SampleTreeRepostry:MainRepostry<R2Smaple> , ISampleThreeRepostry
    {
        private ApplicationDbContext _db;
        public SampleTreeRepostry(ApplicationDbContext db) : base(db)
        {
            _db = db;
           
        }

        public IEnumerable<AttachmentForR2Sample> GetTrementAttchment(long tremntid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<R2Smaple> GetTrementWithCustmerAndSample(long tremntid)
        {
            throw new NotImplementedException();
        }

        public R2Smaple GetTrementWithAttachmentFiles(long treamnetid)
        {
            return _db.R2Smaple.Include(smaple => smaple.AttachmentForR2Samples).Include(smaple => smaple.Custmer).SingleOrDefault(m => m.Id == treamnetid);
        }

        public IEnumerable<R2Smaple> GetTreamentWithSampleAndAppUserCms()
        {
           return _db.R2Smaple.Include(treatment => treatment.Custmer).ThenInclude(custmer => custmer.Sample).Include(treatment => treatment.ApplicationUser).ToList();
        }
    }
}
