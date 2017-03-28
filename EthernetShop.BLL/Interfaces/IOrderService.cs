using EthernetShop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.BLL.Interfaces
{
    public interface IOrderService
    {
        OrderDTO GetOrder(int id);
        void AddOrder(OrderDTO orderDTO);
        void DeleteOrder(int id);
        void UpdateOrder(OrderDTO orderDTO);
        ICollection<OrderDTO> GetOrders();
    }
}
