using EthernetShop.DAL.Entities;
using EthernetShop.DAL.EntityFramework;
using EthernetShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.DAL.Repositories
{
    public class RoleRepository : BaseRepository<Role>
    {
        /*EthernetShopContext db;
        public RoleRepository()
        {
            this.db = new EthernetShopContext();
        }
        public RoleRepository(EthernetShopContext context)
        {
            this.db = context;
        }
        public IEnumerable<Role> GetList()
        {
            return (db.Roles.ToList<Role>());
        }
        public IEnumerable<Role> GetList(Func<Role, bool> where)
        {
            return db.Roles.Where<Role>(where).ToList<Role>();
        }
        public Role Get(int id)
        {
            return (db.Roles.Find(id));
        }
        public Role Get(Func<Role, bool> where)
        {
            return db.Roles.Where<Role>(where).FirstOrDefault<Role>();
        }
        public void Add(Role model)
        {
            db.Roles.Add(model);
            db.SaveChanges();
        }
        public void Add(IEnumerable<Role> models)
        {
            db.Roles.AddRange(models);
            db.SaveChanges();
        }
        public void Update(Role model)
        {
            db.Entry(model).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Role role = db.Roles.Find(id);
            if (role != null)
                db.Roles.Remove(role);
            db.SaveChanges();
        }
        public void Save()
        {
            db.SaveChanges();
        }*/
    }
}
