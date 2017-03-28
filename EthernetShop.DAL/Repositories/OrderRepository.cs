using EthernetShop.DAL.Entities;
using System.Data.Entity;
using EthernetShop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.DAL.Repositories
{
    public class OrderRepository: BaseRepository<Order>
    {
        public override Order Get(int id)
        {
            return DB.Orders.Include(x => x.Items).FirstOrDefault(x => x.Id == id);
        }
        public override Order Get(Func<Order, bool> where)
        {
            return DB.Orders.Include(x => x.Items).Where(where).FirstOrDefault();
        }
        public override ICollection<Order> GetList()
        {
            return DB.Orders.Include(x => x.Items).ToList();
        }
        public override ICollection<Order> GetList(Func<Order, bool> where)
        {
            return DB.Orders.Include(x => x.Items).Where(where).ToList();
        }
    }
}
