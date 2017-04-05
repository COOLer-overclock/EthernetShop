using System.Web.Mvc;
using EthernetShop.Attributes;
using EthernetShop.BLL.DTO;
using EthernetShop.Models;
using AM = EthernetShop.Util;
using EthernetShop.BLL.Interfaces;
using Ninject;
using Microsoft.AspNet.SignalR;
using EthernetShop.SignalR;

namespace EthernetShop.Controllers
{
    public class OrderController : Controller
    {
        [Inject]
        public IOrderService OrderService { get; set; }
        [HttpGet]
        public ActionResult MakeOrder()
        {
            return View(new OrderCreateViewModel());
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderCreateViewModel order)
        {
            if(order != null)
            {
                OrderProcessingHelper.Orders.Add(order);
                //OrderService.AddOrder(AM.AutoMapper.Mapper.Map<OrderCreateViewModel, OrderDTO>(order));
                var context = GlobalHost.ConnectionManager.GetHubContext<OrderProcessingHub>();
                context.Clients.All.addNotification(OrderProcessingHelper.Orders.Count);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}