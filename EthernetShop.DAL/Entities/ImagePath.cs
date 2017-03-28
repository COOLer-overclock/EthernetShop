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
    public class ImagePath : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }

        [ForeignKey("Item")]
        public Nullable<int> ItemId { get; set; }
        public virtual ItemBase Item { get; set; }

        [ForeignKey("Category")]
        public Nullable<int> CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
