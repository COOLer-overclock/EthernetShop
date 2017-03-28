using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthernetShop.Models
{
    public class GPUViewModel : BaseContentViewModel
    {
        public int CoresAmount { get; set; }
        public float CoreClockFrequency { get; set; }
        public int MemorySize { get; set; }
        public float MemoryClockFrequency { get; set; }
    }
}