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
using AM = EthernetShop.BLL.Util;

namespace EthernetShop.BLL.Services
{
    public class CPUContentService : ContentServiceBase<CPU, CPU_DTO>
    {
    }
/*    public class CPUContentService : IContentService<CPU_DTO>
    {
        [Inject]
        public IUnitOfWork DB { get; set; }
        public void Delete(int id)
        {
            DB.CPUs.Delete(id);
        }
        public CPU_DTO Get(int id)
        {
            CPU CPU = DB.CPUs.Get(id);
            if(CPU != null)
                return AM.AutoMapper.Mapper.Map<CPU, CPU_DTO>(CPU);
            return null;
        }
        public ICollection<CPU_DTO> GetList()
        {
            ICollection<CPU> CPUs = DB.CPUs.GetList(); 
            if (CPUs != null)
                return AM.AutoMapper.Mapper.Map<ICollection<CPU>, ICollection<CPU_DTO>>(CPUs);
            return null;
        }
        public void Update(CPU_DTO model)
        {
            DB.CPUs.Update(AM.AutoMapper.Mapper.Map<CPU_DTO, CPU>(model));
        }
        public void Add(CPU_DTO model)
        {
            var category = DB.Categories.Get(x => x.CategoryName.ToUpper() == model.CategoryName.ToUpper());
            if (category != null)
            {
                CPU cpu = AM.AutoMapper.Mapper.Map<CPU_DTO, CPU>(model);
                cpu.Category = category;
                foreach (var image in cpu.ImagesPath)
                    image.CategoryId = category.Id;
                DB.CPUs.Add(cpu);
            }
        }
        public void Add(ICollection<CPU_DTO> models)
        {
            if (models != null)
            {
                var category = DB.Categories.Get(x => x.CategoryName.ToUpper() == models.FirstOrDefault().CategoryName.ToUpper());
                if (category != null)
                    foreach (var i in models)
                    {
                        i.CategoryId = category.Id;
                        i.Rating = 0;
                    }
                DB.CPUs.Add(AM.AutoMapper.Mapper.Map<ICollection<CPU_DTO>, ICollection<CPU>>(models));
            }
        }
    }*/
}


