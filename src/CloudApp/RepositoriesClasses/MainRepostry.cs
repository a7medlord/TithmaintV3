using System;
using System.Collections.Generic;
using System.Linq;
using CloudApp.Data;

namespace CloudApp.RepositoriesClasses
{
    public class MainRepostry<T> where T : class 
    {
        private readonly ApplicationDbContext _db;
        public MainRepostry(ApplicationDbContext db)
        {
            _db = db;
        }

        public virtual bool Add(T entity)
        {
            _db.Add(entity);
            return SaveChanges();
        }

        public virtual bool Update(T entity)
        {
            _db.Update(entity);
            return SaveChanges();
        }
        
        public virtual bool Delete(T entity)
        {
            _db.Remove(entity);
           return SaveChanges();
           
        }

        public virtual T GetbyId(long id)
        {
         return _db.Find<T>(id);
        }
        
        public virtual IEnumerable<T> GetByexpr(Func<T , bool> expr)
        {
          return  _db.Set<T>().Where(expr);
        }
        
        public virtual IEnumerable<T> Getall()
        {
            return _db.Set<T>().ToList();
        }
        
        //Helper Method
        bool SaveChanges()
        {
            if (_db.SaveChanges() > 0)
            {
                return true;
            }
         
            return false;
        }


    }
}
