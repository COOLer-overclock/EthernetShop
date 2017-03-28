using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.DAL.Interfaces
{
    public interface IRepository<T>
    {
        ICollection<T> GetList();
        ICollection<T> GetList(Func<T, bool> where);
        T Get(int id);
        T Get(Func<T, bool> where);
        void Add(T model);
        void Add(ICollection<T> models);
        void Update(T model);
        void Delete(int id);
        void Delete(ICollection<int> ids);
        void Delete(ICollection<T> models);
    }
}
