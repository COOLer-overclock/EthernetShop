using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using EthernetShop.SignalR;

[assembly: OwinStartup(typeof(EthernetShop.Startup))]

namespace EthernetShop
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
