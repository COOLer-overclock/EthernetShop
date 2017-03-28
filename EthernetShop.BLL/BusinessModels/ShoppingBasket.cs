using System;
using System.Collections.Generic;
using EthernetShop.DAL.Interfaces;
using EthernetShop.BLL.Interfaces;
using EthernetShop.BLL.DTO.Content;

namespace EthernetShop.BLL.BusinessModels
{
    public class ShoppingBasket
    {
        public ICollection<BasketContent> Basket { get; set; }
        public float TotalSum { get; set; }

        public ShoppingBasket()
        {
            Basket = new List<BasketContent>();
            TotalSum = 0;
        }
    }
}
