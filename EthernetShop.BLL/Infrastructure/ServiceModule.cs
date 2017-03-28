using Ninject.Modules;
using EthernetShop.DAL.Interfaces;
using EthernetShop.DAL.Repositories;

namespace EthernetShop.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {

        }
    }
}
