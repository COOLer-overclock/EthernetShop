using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using EthernetShop.Models;
using EthernetShop.BLL.DTO;
using static EthernetShop.Util.AutoMapper;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using System.Web;
using EthernetShop.SignalR;

namespace EthernetShop.SignalR
{
    public class OrderProcessingHub : Hub
    {
        public override Task OnConnected()
        {
            Clients.All.addNotification(OrderProcessingHelper.Orders.Count);
            return base.OnConnected();
        }
        public void Send(string message)
        {
            Clients.All.addNotification(OrderProcessingHelper.Orders.Count);
        }
    }
    public static class OrderProcessingHelper
    {
        public static ICollection<OrderCreateViewModel> Orders { get; set; }
        static OrderProcessingHelper()
        {
            Orders = new List<OrderCreateViewModel>();
        }
    }
}