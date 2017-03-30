using EthernetShop.Attributes;
using EthernetShop.BLL.DTO.Content;
using EthernetShop.BLL.Interfaces;
using EthernetShop.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static EthernetShop.Util.AutoMapper;

namespace EthernetShop.Controllers.Content
{
    public class GPUController : BaseContentController
    {
        [Inject]
        public IContentService<GPU_DTO> GPUService { get; set; }

        [HttpGet]
        public PartialViewResult AddGPU()
        {
            return PartialView(new GPUViewModel());
        }

        [Authorized(Roles = "Developer, Admin, Moderator")]
        [HttpPost]
        public ActionResult AddGPU(GPUViewModel gpuViewModel)
        {
            SaveImages(gpuViewModel);
            GPU_DTO gpu_DTO = Mapper.Map<GPUViewModel, GPU_DTO>(gpuViewModel);
            GPUService.Add(gpu_DTO);
            return RedirectToAction("AddItem", "Content");
        } 
        
        public ActionResult ShowGPUs()
        {
            return View(Mapper.Map<IEnumerable<GPU_DTO>, IEnumerable<GPUViewModel>>(GPUService.GetList()));
        }
        public ActionResult ShowGPU(int id)
        {
            return View(Mapper.Map<GPU_DTO, GPUViewModel>(GPUService.Get(id)));
        }
        public ActionResult Index()
        {
            return View(GPUService.GetList());
        }
        [Authorized(Roles = "Developer, Admin, Moderator")]
        public void Delete(int id)
        {
            if (id != 0)
                GPUService.Delete(id);
        }
    }
}