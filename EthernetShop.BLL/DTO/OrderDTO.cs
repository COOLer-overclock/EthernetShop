using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public float Sum { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Adress { get; set; }
        public ICollection<OrderItemDTO> Items { get; set; } 
        public DateTime DateTime { get; set; }
    }
    public class OrderItemDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
    }
}
