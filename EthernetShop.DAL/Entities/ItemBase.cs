using EthernetShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EthernetShop.DAL.Entities
{
    public abstract class ItemBase : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }
        public bool IsInStock { get; set; }
        public int Amount { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    
        virtual public ICollection<ImagePath> ImagesPath { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public ItemBase()
        {
            ImagesPath = new List<ImagePath>();
            Category = null;
            Rating = 0;
            Price = 0;
        }
    }
}
