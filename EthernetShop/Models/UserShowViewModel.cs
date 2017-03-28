using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthernetShop.Models
{
    public class UserShowViewModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Adress { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}