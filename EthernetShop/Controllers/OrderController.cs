using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EthernetShop.Attributes;
using EthernetShop.BLL.DTO;
using EthernetShop.Models;
using AM = EthernetShop.Util;
using EthernetShop.BLL.Interfaces;
using Ninject;

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
                OrderService.AddOrder(AM.AutoMapper.Mapper.Map<OrderCreateViewModel, OrderDTO>(order));
            }
            return RedirectToAction("Index", "Home");
        }
    }
}