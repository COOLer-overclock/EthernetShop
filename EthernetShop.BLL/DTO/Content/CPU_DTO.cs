using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.BLL.DTO.Content
{
    public class CPU_DTO : ContentDTOBase
    {
        public int CoresAmount { get; set; }
        public float ClockFrequency { get; set; }
        public int? CashL1 { get; set; }
        public int? CashL2 { get; set; }
        public int? CashL3 { get; set; }
    }
}
