using EthernetShop.BLL.DTO.Content;
using EthernetShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetShop.BLL.Interfaces
{
    public interface IContentService<TModel_DTO> where TModel_DTO : ContentDTOBase
    {
        void Add(TModel_DTO model);
        void Add(ICollection<TModel_DTO> models);
        TModel_DTO Get(int id);
        ICollection<TModel_DTO> GetList();
        void Update(TModel_DTO model);
        void Delete(int id);
    }
}
