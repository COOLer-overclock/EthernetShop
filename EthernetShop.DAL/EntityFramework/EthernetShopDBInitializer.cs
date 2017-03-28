using System;
using System.Data.Entity;

namespace EthernetShop.DAL.EntityFramework
{
    public class EthernetShopDBInitializer : DropCreateDatabaseIfModelChanges<EthernetShopContext>
    {
        protected override void Seed(EthernetShopContext context)
        {
//            context.Categories.Add(new Entities.Category() { CategoryName = "CPU" });
//            context.Categories.Add(new Entities.Category() { CategoryName = "GPU" });
//            base.Seed(context);
        }
    }
}
