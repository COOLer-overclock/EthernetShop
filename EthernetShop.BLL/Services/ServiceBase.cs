using EthernetShop.BLL.Infrastructure;
using EthernetShop.BLL.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI = EthernetShop.DAL.Interfaces;

namespace EthernetShop.BLL.Services
{
   /* public abstract class ServiceBase<DAL, BLL> : IService<BLL> where BLL : IEntity
    {
       protected Automapper<DAL, BLL> mapper;
        [Inject]
        public DI.IRepository<DAL> repository { get; set; }
        public ServiceBase()
        {
            mapper = new Automapper<DAL, BLL>();
        }
        public virtual IEnumerable<BLL> Get(int offset, int limit)
        {
            return mapper.GetIEnumerableBBL(repository.GetList().Skip(offset).Take(limit));
        }

        public virtual BLL Add(BLL model)
        {
            var result = mapper.GetBBL( (repository.Add(mapper.GetDAL(model))));
            return result;
        }

        public virtual void Delete(int id)
        {
            repository.Delete(id);
        }

        public virtual void Edit(BLL model)
        {
            repository.Update(mapper.GetDAL(model));
        }

        public virtual BLL GetById(int id)
        {
            return mapper.GetBBL(repository.Get(id));
        }

        public virtual IEnumerable<BLL> GetIEnumerable()
        {
            var result = mapper.GetIEnumerableBBL(repository.GetList().ToList());
            return result;
        }

        public virtual void Clear()
        {
            //repository.Clear();
        }
    }*/
}
