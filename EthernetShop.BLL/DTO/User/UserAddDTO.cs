using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthernetShop.DAL.Entities;

namespace EthernetShop.BLL.DTO
{
    public class UserAddDTO
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Adress { get; set; }
        public string TelephoneNumber { get; set; }
        public int? Age { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public UserAddDTO()
        {
            Role = "User";
        }
    }
}
