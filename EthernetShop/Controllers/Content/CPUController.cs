using EthernetShop.BLL.DTO.Content;
using EthernetShop.BLL.Interfaces;
using EthernetShop.Controllers.Content;
using EthernetShop.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EU = EthernetShop.Util;

namespace EthernetShop.Controllers
{
    public class CPUController : BaseContentController
    {
        [Inject]
        public IContentService<CPU_DTO> CPUService { get; set; }

        [HttpGet]
        public PartialViewResult AddCPU()
        {
            return PartialView(new CPUViewModel());
        }

        [HttpPost]
        public ActionResult AddCPU(CPUViewModel cpuViewModel)
        {
            SaveImages(cpuViewModel);
            CPU_DTO cpu_DTO = EU.AutoMapper.Mapper.Map<CPUViewModel, CPU_DTO>(cpuViewModel);
            CPUService.Add(cpu_DTO);
            return RedirectToAction("AddItem", "Content");
        }

        public ActionResult ShowCPUs()
        {
            return View(EU.AutoMapper.Mapper.Map<IEnumerable<CPU_DTO>, IEnumerable<CPUViewModel>>(CPUService.GetList()));
        }

        public ActionResult Index()
        {
            return View(CPUService.GetList());
        }
        public void Delete(int id)
        {
            if (id != 0)
                CPUService.Delete(id);
        }
    }
}