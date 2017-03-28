using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthernetShop.DAL.Interfaces;
using EthernetShop.DAL.EntityFramework;
using EthernetShop.DAL.Entities;

namespace EthernetShop.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        EthernetShopContext db;
        CategoryRepository categoryRepository;
        CPURepository cpuRepository;
        GPURepository gpuRepository;
        OrderRepository orderRepository;
        RoleRepository roleRepository;
        UserRepository userRepository;
        ImageRepository imageRepository;

        public IRepository<ImagePath> Images
        {
            get
            {
                if (imageRepository == null)
                    imageRepository = new ImageRepository();
                return imageRepository;
            }
        }
        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository();
                return categoryRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository();
                return orderRepository;
            }
        }
        public IRepository<CPU> CPUs
        {
            get
            {
                if (cpuRepository == null)
                    cpuRepository = new CPURepository();
                return cpuRepository;
            }
        }
        public IRepository<GPU> GPUs
        {
            get
            {
                if (gpuRepository == null)
                    gpuRepository = new GPURepository();
                return gpuRepository;
            }
        }
        public IRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository();
                return roleRepository;
            }
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository();
                return userRepository;
            }
        }
        public IRepository<T> Set<T>()
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(IRepository<T>))
                    return prop.GetValue(this) as IRepository<T>; 
            }
            return null;
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
