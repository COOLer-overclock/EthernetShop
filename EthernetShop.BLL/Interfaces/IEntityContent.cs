using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthernetShop.DAL.Interfaces;

namespace EthernetShop.BLL.Interfaces
{
    public interface IEntityContent : IEntity
    {
        string Name { get; set; }
        float Price { get; set; }
        float Rating { get; set; }
        string Description { get; set; }
        bool IsInStock { get; set; }
        string CategoryName { get; set; }
        int CategoryId { get; set; }
        ICollection<string> Images { get; set; }
    }
}
