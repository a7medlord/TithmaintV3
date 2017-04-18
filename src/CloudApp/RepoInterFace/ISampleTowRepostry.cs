using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudApp.Models.BusinessModel;

namespace CloudApp.RepoInterFace
{
   public interface ISampleTowRepostry
    {
        IEnumerable<AttachmentForR1Sample> GetTrementAttchment(long tremntid);

        IEnumerable<R1Smaple> GetTrementWithCustmerAndSample(long tremntid);

        R1Smaple GetTrementWithAttachmentFiles(long treamnetid);

        IEnumerable<R1Smaple> GetTreamentWithSampleAndAppUserCms();

        long GetAutoIncreesNumber();
    }
}
