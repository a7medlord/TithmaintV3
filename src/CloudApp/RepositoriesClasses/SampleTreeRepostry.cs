using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudApp.Data;
using CloudApp.Models;
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
           return _db.R2Smaple.Include(treatment => treatment.Custmer).
                ThenInclude(custmer => custmer.Sample).
                Include(treatment => treatment.ApplicationUser).Where(treatment => !treatment.IsUnlockFin).ToList();
        }

        public long GetAutoIncreesNumber()
        {
            AutoIncresTable incresTable = _db.AutoIncresTable.LastOrDefault();
            if (incresTable != null)
            {
                long number = incresTable.LastId;
                SaveToDataBase(number);
                _db.SaveChanges();
                return number + 1;
            }
            SaveToDataBase(0);
            return 0;
        }

        public IEnumerable<R2Smaple> TrementMothmenWhere()
        {
            return _db.R2Smaple.Include(treatment => treatment.Custmer)
                .ThenInclude(custmer => custmer.Sample)
                .Include(treatment => treatment.ApplicationUser).Where(treatment => !treatment.IsUnlockFin && !treatment.IsThmin)
                .ToList();
        }

        void SaveToDataBase(long idof)
        {
            AutoIncresTable incres = new AutoIncresTable() { LastId = idof + 1 };
            _db.Add(incres);
            _db.SaveChanges();
        }
    }
}
