using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthernetShop.Models
{
    public class CPUViewModel : BaseContentViewModel
    {
        public int CoresAmount { get; set; }
        public float ClockFrequency { get; set; }
        public int? CashL1 { get; set; }
        public int? CashL2 { get; set; }
        public int? CashL3 { get; set; }
    }
}