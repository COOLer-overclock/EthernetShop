using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthernetShop.Models
{
    public abstract class BaseContentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }
        public bool IsInStock { get; set; }
        public int Amount { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public ICollection<string> Images { get; set; }
        public BaseContentViewModel()
        {
            Images = new List<string>();
        }
    }
}