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
    public class SampleTowRepostry : MainRepostry<R1Smaple> , ISampleTowRepostry
    {
        private ApplicationDbContext _db;
        public SampleTowRepostry(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<AttachmentForR1Sample> GetTrementAttchment(long tremntid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<R1Smaple> GetTrementWithCustmerAndSample(long tremntid)
        {
            throw new NotImplementedException();
        }

        public R1Smaple GetTrementWithAttachmentFiles(long treamnetid)
        {
           return _db.R1Smaple.Include(smaple => smaple.AttachmentForR1Samples).Include(smaple => smaple.Custmer).SingleOrDefault(m => m.Id == treamnetid);
        }

        public IEnumerable<R1Smaple> GetTreamentWithSampleAndAppUserCms()
        {
         return _db.R1Smaple.Include(treatment => treatment.Custmer).ThenInclude(custmer => custmer.Sample).Include(treatment => treatment.ApplicationUser).ToList();
        }
    }
}
