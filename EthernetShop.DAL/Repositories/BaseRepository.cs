using EthernetShop.DAL.EntityFramework;
using EthernetShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected EthernetShopContext DB;
        public BaseRepository()
        {
            DB = new EthernetShopContext();
        }
        public virtual ICollection<T> GetList()
        {
            return DB.Set<T>().ToList<T>();
        }
        public virtual ICollection<T> GetList(Func<T, bool> where)
        {
            return DB.Set<T>().AsNoTracking().Where(where).ToList<T>();
        }
        public virtual T Get(int id)
        {
            return DB.Set<T>().FirstOrDefault<T>(x => x.Id == id);
        }
        public virtual T Get(Func<T, bool> where)
        {
            return DB.Set<T>().FirstOrDefault<T>(where);
        }
        public virtual void Add(T model)
        {
            DB.Set<T>().Add(model);
            DB.SaveChanges();
        }
        public virtual void Add(ICollection<T> models)
        {
            DB.Set<T>().AddRange(models);
            DB.SaveChanges();
        }
        public virtual void Update(T model)
        {
            try
            {
                DB.Entry<T>(model).State = EntityState.Modified;
            }
            catch
            { }
        }       
        public virtual void Delete(int id)
        {
            var model = DB.Set<T>().FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                //DB.Set<T>().Attach(model);
                DB.Entry(model).State = EntityState.Deleted;
                bool isSaved;
                do
                {
                    isSaved = false;
                    try
                    {
                        DB.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        isSaved = true;
                        var entry = ex.Entries.Single();
                        entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                    }
                } while (isSaved);
            }
        }
        public virtual void Delete(ICollection<int> ids)
        {
            DB.Set<T>().RemoveRange(DB.Set<T>().Where(x => ids.Contains(x.Id)));
            DB.SaveChanges();
        }
        public virtual void Delete(ICollection<T> models)
        {
            foreach (var model in models)
                DB.Set<T>().Attach(model);
            DB.Set<T>().RemoveRange(models);
            DB.SaveChanges();
        }
    }
}
