using System.Collections.Generic;
using CloudApp.Models.BusinessModel;

namespace CloudApp.RepoInterFace
{
  public  interface ISampleOneRepostry
  {
      IEnumerable<AttachmentForTreament> GetTrementAttchment(long tremntid);

      IEnumerable<Treatment> GetTrementWithCustmerAndSample(long tremntid);

      Treatment GetTrementWithAttachmentFiles(long treamnetid);

      IEnumerable<Treatment> GetTreamentWithSampleAndAppUserCms();

      long GetAutoIncreesNumber();

      IEnumerable<Treatment> TrementMothmenWhere();
  }
}
