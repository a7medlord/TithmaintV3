using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudApp.Models.BusinessModel;

namespace CloudApp.RepoInterFace
{
  public  interface ISampleThreeRepostry
    {

        IEnumerable<AttachmentForR2Sample> GetTrementAttchment(long tremntid);

        IEnumerable<R2Smaple> GetTrementWithCustmerAndSample(long tremntid);

        R2Smaple GetTrementWithAttachmentFiles(long treamnetid);

        IEnumerable<R2Smaple> GetTreamentWithSampleAndAppUserCms();

        long GetAutoIncreesNumber();
    }
}
