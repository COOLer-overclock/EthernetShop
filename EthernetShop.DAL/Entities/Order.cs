using EthernetShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.DAL.Entities
{
    public class Order : IEntity
    {
        [Key]
        public int Id { get; set; }
        public float Sum { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Adress { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public Order()
        {
            Items = new List<OrderItem>();
        }
    }
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
    }
}
