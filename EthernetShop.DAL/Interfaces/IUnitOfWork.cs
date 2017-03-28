using EthernetShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CPU> CPUs { get; }
        IRepository<GPU> GPUs { get; }
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<Category> Categories { get; }
        IRepository<Order> Orders { get; }
        IRepository<ImagePath> Images { get; }
        IRepository<T> Set<T>();
        void Save();
    }
}
