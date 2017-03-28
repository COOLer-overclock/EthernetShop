using EthernetShop.BLL.DTO.Content;
using EthernetShop.BLL.Interfaces;
using EthernetShop.DAL.Entities;
using EthernetShop.DAL.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AM = EthernetShop.BLL.Util;
using static EthernetShop.BLL.Util.AutoMapper;

namespace EthernetShop.BLL.Services
{
    public abstract class ContentServiceBase<TModel, TModel_DTO> : IContentService<TModel_DTO> where TModel : ItemBase where TModel_DTO : ContentDTOBase
    {
        [Inject]
        public IUnitOfWork uof { get; set; }
        public virtual  void Add(TModel_DTO model)
        {
            var category = uof.Categories.Get(x => x.CategoryName.ToUpper() == model.CategoryName.ToUpper());
            if(category != null)
            {
                TModel item = Mapper.Map<TModel_DTO, TModel>(model);
                item.Category = category;
                foreach (var image in item.ImagesPath)
                    image.CategoryId = category.Id;
                uof.Set<TModel>().Add(item);
            }
        }
        public virtual void Add(ICollection<TModel_DTO> models)
        {
            if((models != null)&&(models.Count > 0))
            {
                var category = uof.Set<Category>().Get(x => x.CategoryName.ToUpper() == models.First().CategoryName.ToUpper());
                if(category != null)
                {
                    foreach(var model in models)
                    {
                        model.CategoryId = category.Id;
                        model.Rating = 0;
                    }
                }
                uof.Set<TModel>().Add(Mapper.Map<ICollection<TModel_DTO>, ICollection<TModel>>(models));
            }
        }
        public virtual void Delete(int id)
        {
            uof.Set<TModel>().Delete(id);
        }
        public virtual TModel_DTO Get(int id)
        {
            TModel model = uof.Set<TModel>().Get(id);
            if (model != null)
                return Mapper.Map<TModel, TModel_DTO>(model);
            return null;
        }
        public virtual ICollection<TModel_DTO> GetList()
        {
            ICollection<TModel> models = uof.Set<TModel>().GetList();
            if (models != null)
                return Mapper.Map<ICollection<TModel>, ICollection<TModel_DTO>>(models);
            return null;
        }
        public virtual void Update(TModel_DTO model)
        {
            throw new NotImplementedException();
        }
    }
}
