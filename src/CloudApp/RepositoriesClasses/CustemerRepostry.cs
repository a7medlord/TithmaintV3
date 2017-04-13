using CloudApp.Data;
using CloudApp.Models.BusinessModel;
using CloudApp.RepoInterFace;

namespace CloudApp.RepositoriesClasses
{
    public class CustemerRepostry : MainRepostry<Custmer>,ICustemerRepostry
    {
        private ApplicationDbContext _db;
        public CustemerRepostry(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
    }
}