using EthernetShop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthernetShop.SignalR
{
    public class SignalRUser : UserDTO
    {
        public string SignalRId { get; set; }
    }
}