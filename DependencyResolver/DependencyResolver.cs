using EthernetShop.BLL.BusinessModels;
using EthernetShop.BLL.DTO.Content;
using EthernetShop.BLL.Interfaces;
using EthernetShop.BLL.Services;
using EthernetShop.DAL.Interfaces;
using EthernetShop.DAL.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DependencyResolver
{
    public class DependencyResolver
    {
        public static void Initialization(IKernel kernel)
        {
            kernel.Bind<IUserService>().To<UserService>().WithConstructorArgument("httpContext", ninjectContext => HttpContext.Current);
            kernel.Bind<IShoppingBasketService>().To<ShoppingBasketService>().WithConstructorArgument("httpContext", ninjectContext => HttpContext.Current);
            kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>();
            kernel.Bind<IContentService<CPU_DTO>>().To<CPUContentService>();
            kernel.Bind<IContentService<GPU_DTO>>().To<GPUContentService>();
            kernel.Bind<IOrderService>().To<OrderService>();
        }
    }
}
