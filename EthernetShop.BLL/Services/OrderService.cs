using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthernetShop.BLL.Interfaces;
using EthernetShop.BLL.BusinessModels;
using EthernetShop.DAL.Entities;
using EthernetShop.BLL.DTO;
using AM = EthernetShop.BLL.Util.AutoMapper;
using EthernetShop.DAL.Interfaces;

namespace EthernetShop.BLL.Services
{
    public class OrderService : IOrderService
    {
        [Inject]
        public IShoppingBasketService BasketService { get; set; }
        [Inject]
        public IUnitOfWork DB { get; set; }
        public void AddOrder(OrderDTO orderDTO)
        {
            ShoppingBasket basket = BasketService.GetBasket();
            Order order = AM.Mapper.Map<OrderDTO, Order>(orderDTO);
            order.Items = AM.Mapper.Map<ICollection<BasketContent>, ICollection<OrderItem>>(basket.Basket);
            order.Sum = basket.TotalSum;
            order.DateTime = System.DateTime.Now;
            DB.Orders.Add(order);
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDTO GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderDTO> GetOrders()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(OrderDTO orderDTO)
        {
            throw new NotImplementedException();
        }
    }
}
