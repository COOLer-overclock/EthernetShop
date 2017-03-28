using EthernetShop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.BLL.BusinessModels
{
    public class BasketContent : IEntityContent
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public ICollection<string> Images { get; set; }
        public bool IsInStock { get; set; }
        public int AmountInBasket { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Rating { get; set; }
        public BasketContent()
        {
            Images = new List<string>();
        }
    }
}
