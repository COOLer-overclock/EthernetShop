using EthernetShop.DAL.Interfaces;
using EthernetShop.BLL.Interfaces;
using System.Linq;
using System.Web;
using AM = EthernetShop.BLL.Util;
using EthernetShop.DAL.Entities;
using EthernetShop.BLL.BusinessModels;
using EthernetShop.BLL.DTO.Content;
using Ninject;
using System.Collections.Generic;

namespace EthernetShop.BLL.Services
{
    public class ShoppingBasketService : IShoppingBasketService
    {
        IUnitOfWork _iof;
        HttpContext _httpContext;

        public BasketContent Model { get; set; }
        public ShoppingBasket Basket { get; set; }
        public void SetHttpContext(HttpContext httpContext)
        {
            this._httpContext = httpContext;
            this.Basket = new ShoppingBasket();
        }
        public void Add(int categoryId, int itemId, int amount = 1)
        {
            var category  = _iof.Categories.Get(categoryId);
            if(category != null)
            {
                switch(category.CategoryName.ToUpper())
                {
                    case "CPU":
                        var cpu = _iof.CPUs.Get(itemId);
                        if (cpu != null)
                        {
                            Model = AM.AutoMapper.Mapper.Map<CPU, BasketContent>(cpu);
                            if (cpu.Amount < amount)
                                amount = cpu.Amount;
                        }
                        break;
                    case "GPU":
                        var gpu = _iof.GPUs.Get(itemId);
                        if (gpu != null)
                        {
                            Model = AM.AutoMapper.Mapper.Map<GPU, BasketContent>(gpu);
                            if (gpu.Amount < amount)
                                amount = gpu.Amount;
                        }
                        break;
                    default:
                        Model = null;
                        break;
                }
                if(Model != null)
                {
                    var shopBasket = this._httpContext.Session["ShoppingBasket"] as ShoppingBasket;
                    if (shopBasket == null)
                        shopBasket = Basket;
                    if (!shopBasket.Basket.Any(x => x.Id == Model.Id && x.CategoryId == Model.CategoryId))
                    {
                        Model.AmountInBasket = amount;
                        shopBasket.Basket.Add(Model);
                    }
                    else
                        shopBasket.Basket.First(x => x.Id == Model.Id && x.CategoryId == Model.CategoryId).AmountInBasket += amount;
                    shopBasket.TotalSum += Model.Price * amount;
                    _httpContext.Session["ShoppingBasket"] = shopBasket;
                }
            }
        }
        public void Remove(BasketContent model, int amount = 1)
        {
            if (_httpContext.Session["ShoppingBasket"] != null)
            {
                var shopBasket = _httpContext.Session["ShoppingBasket"] as ShoppingBasket;
                if(shopBasket.Basket.Any(x => x.CategoryId == model.Id && x.Id == model.Id))
                {
                    var temp = shopBasket.Basket.First(x => x.CategoryId == model.CategoryId && x.Id == model.Id);
                    if (temp.AmountInBasket <= amount)
                        shopBasket.Basket.Remove(temp);
                    else
                        temp.AmountInBasket -= amount;
                }
            }
        }
        public void Remove(int categoryId, int itemId, int amount = 1)
        {
            if (_httpContext.Session["ShoppingBasket"] != null)
            {
                var shopBasket = _httpContext.Session["ShoppingBasket"] as ShoppingBasket;
                if (shopBasket.Basket.Any(x => x.CategoryId == categoryId && x.Id == itemId))
                {
                    var temp = shopBasket.Basket.First(x => x.CategoryId == categoryId && x.Id == itemId);
                    if (temp.AmountInBasket <= amount)
                        shopBasket.Basket.Remove(temp);
                    else
                        temp.AmountInBasket -= amount;
                }
            }
        }
        public ShoppingBasket GetBasket()
        {
            var shopBasket = _httpContext.Session["ShoppingBasket"] as ShoppingBasket;
            if (shopBasket == null)
                shopBasket = Basket;
            return shopBasket;
        }
        public void ClearAll()
        {
            _httpContext.Session["ShoppingBasket"] = null;
        }
        public ShoppingBasketService(IUnitOfWork IUoW, HttpContext httpContext)
        {
            this.Basket = new ShoppingBasket();
            this._httpContext = httpContext;
            this._iof = IUoW;
        }
        public ShoppingBasketService(IUnitOfWork IUoW)
        {
            this._iof = IUoW;
            this.Basket = new ShoppingBasket();
        }
    }
}
