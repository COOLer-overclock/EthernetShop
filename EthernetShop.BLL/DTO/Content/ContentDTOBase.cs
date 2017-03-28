using EthernetShop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.BLL.DTO.Content
{
    public abstract class ContentDTOBase : IEntityContent
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
        public ContentDTOBase()
        {
            Images = new List<string>();
        }
    }
}
