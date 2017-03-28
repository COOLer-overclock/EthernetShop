using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthernetShop.BLL.Interfaces;
using EthernetShop.BLL.DTO.Content;
using EthernetShop.BLL.BusinessModels;

namespace EthernetShop.BLL.Interfaces
{
    public interface IShoppingBasketService
    {
        void Add(int categoryId, int itemId, int amount = 1);
        void Remove(BasketContent model, int amount = 1);
        void Remove(int categoryId, int itemId, int amount = 1);
        ShoppingBasket GetBasket();
        void ClearAll();
    }
}
