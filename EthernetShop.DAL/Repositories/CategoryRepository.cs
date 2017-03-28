using EthernetShop.DAL.Entities;
using EthernetShop.DAL.EntityFramework;
using EthernetShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.DAL.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public override void Add(Category model)
        {
            var category = DB.Categories.Where(x => x.CategoryName == model.CategoryName).ToList();
            if (category == null)
                base.Add(model);
        }
    }
}
