using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EthernetShop.DAL.Entities;

namespace EthernetShop.DAL.EntityFramework
{
    public class EthernetShopContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ImagePath> Images { get; set; }
        public EthernetShopContext(string connectionString) : base(connectionString)
        {
            // Database.SetInitializer(new EthernetShopDBInitializer());
            this.Configuration.ProxyCreationEnabled = false;
        }

        public EthernetShopContext()
        {
            // Database.SetInitializer(new EthernetShopDBInitializer());
            this.Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CPU>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("CPUs");
                });
            modelBuilder.Entity<GPU>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("GPUs");
                });
        }
    }
}
