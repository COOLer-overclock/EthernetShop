using EthernetShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.DAL.Entities
{
    public class GPU : ItemBase
    {
        public int CoresAmount { get; set; }
        public float CoreClockFrequency { get; set; }
        public int MemorySize { get; set; }
        public float MemoryClockFrequency { get; set; }
    }
}
