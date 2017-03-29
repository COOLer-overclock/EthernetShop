using EthernetShop.DAL.Entities;
using EthernetShop.DAL.EntityFramework;
using EthernetShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public override User Get(Func<User, bool> where)
        {
            return DB.Users.Include(x => x.Role).Where(where).FirstOrDefault();
        }
        /*   EthernetShopContext db;
           public UserRepository()
           {
               this.db = new EthernetShopContext();
           }
           public UserRepository(EthernetShopContext context)
           {
              this.db = context;
           }
           public IEnumerable<User> GetList()
           {
               return db.Users.ToList<User>();
           }
           public IEnumerable<User> GetList(Func<User, bool> where)
           {
               return db.Users.Where(where).ToList();
           }

           public User Get(int id)
           {
               return db.Users.Find(id);
           }

           public User Get(Func<User, bool> where)
           {
               return db.Users.Where(where).FirstOrDefault<User>();
           }
           public void Add(User model)
           {
               db.Users.Add(model);
               db.SaveChanges();
           }
           public void Add(IEnumerable<User> models)
           {
               db.Users.AddRange(models);
               db.SaveChanges();
           }
           public void Update(User model)
           {
               db.Entry(model).State = EntityState.Modified;
           }
           public void Delete(int id)
           {
               User user = db.Users.Find(id);
               if (user != null)
                   db.Users.Remove(user);
               db.SaveChanges();
           }
           public void Save()
           {
               db.SaveChanges();
           }*/
    }
}
