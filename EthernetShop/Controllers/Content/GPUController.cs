using EthernetShop.BLL.DTO.Content;
using EthernetShop.BLL.Interfaces;
using EthernetShop.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EU = EthernetShop.Util;

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

        [HttpPost]
        public ActionResult AddGPU(GPUViewModel gpuViewModel)
        {
            SaveImages(gpuViewModel);
            GPU_DTO gpu_DTO = EU.AutoMapper.Mapper.Map<GPUViewModel, GPU_DTO>(gpuViewModel);
            GPUService.Add(gpu_DTO);
            return RedirectToAction("AddItem", "Content");
        } 
        
        public ActionResult ShowGPUs()
        {
            return View(EU.AutoMapper.Mapper.Map<IEnumerable<GPU_DTO>, IEnumerable<GPUViewModel>>(GPUService.GetList()));
        }
        public ActionResult Index()
        {
            return View(GPUService.GetList());
        }
        public void Delete(int id)
        {
            if (id != 0)
                GPUService.Delete(id);
        }
    }
}