using EthernetShop.DAL.Entities;
using EthernetShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EthernetShop.DAL.Repositories
{
    public class ContentRepositoryBase<T> : BaseRepository<T> where T: ItemBase
    {
        public override void Add(T model)
        {
            if (model.Category is Category)
                DB.Set<Category>().Attach(model.Category);
            DB.Set<T>().Add(model);
            DB.SaveChanges();
        }
        public override void Add(ICollection<T> models)
        {
            if(models != null)
            {
                foreach (var model in models)
                    if (model.Category is Category)
                        DB.Set<Category>().Attach(model.Category);
                DB.Set<T>().AddRange(models);
                DB.SaveChanges();
            }
        }
        public override T Get(int id)
        {
            try
            {
                return DB.Set<T>().Include(x => x.ImagesPath).Include(x => x.Category).Where(c => c.Id == id).FirstOrDefault();
            }
            catch
            { return null; }
        }
        public override T Get(Func<T, bool> where)
        {
            return DB.Set<T>().Where(where).FirstOrDefault();
        }
        public override ICollection<T> GetList()
        {
           try
           {
                return DB.Set<T>().Include(x => x.Category).Include(x => x.ImagesPath).ToList<T>();
           }
           catch
           { return null; }
        }
        public override void Delete(int id)
        {
            var content = DB.Set<T>().Include(x => x.ImagesPath).FirstOrDefault(x => x.Id == id);
            if(content != null)
            {
                if (content.ImagesPath != null)
                    DB.Set<ImagePath>().RemoveRange(content.ImagesPath);
                DB.Entry(content).State = EntityState.Deleted;
                DB.SaveChanges();
            }
        }
        public ContentRepositoryBase() : base()
        {  }
    }
}
