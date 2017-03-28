using EthernetShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.DAL.Entities
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        virtual public Role Role { get; set; }
        public string Adress { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int? Age { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
    }
}
