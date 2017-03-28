using EthernetShop.BLL.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EthernetShop.Controllers
{
    public class ShoppingBasketServiceController : BaseController
    {
        [Inject]
        public IShoppingBasketService basketService { get; set; }

        public void AddItem(int categoryId, int itemId, int amount = 1)
        {
            basketService.Add(categoryId, itemId, amount);
        }
        public void RemoveItem(int categoryId, int itemId, int amount = 1)
        {
            basketService.Remove(categoryId, itemId, amount);
        }
        public ActionResult ShowBasket()
        {
            return View(basketService.GetBasket());
        }
    }
}