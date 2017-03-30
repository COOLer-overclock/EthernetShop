using EthernetShop.BLL.DTO.Content;
using EthernetShop.BLL.Interfaces;
using EthernetShop.Controllers.Content;
using EthernetShop.Models;
using EthernetShop.Attributes;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static EthernetShop.Util.AutoMapper;

namespace EthernetShop.Controllers
{
    public class CPUController : BaseContentController
    {
        [Inject]
        public IContentService<CPU_DTO> CPUService { get; set; }

        [Authorized(Roles = "Developer, Admin, Moderator")]
        [HttpGet]
        public PartialViewResult AddCPU()
        {
            return PartialView(new CPUViewModel());
        }
        [Authorized(Roles = "Developer, Admin, Moderator")]
        [HttpPost]
        public ActionResult AddCPU(CPUViewModel cpuViewModel)
        {
            SaveImages(cpuViewModel);
            CPU_DTO cpu_DTO = Mapper.Map<CPUViewModel, CPU_DTO>(cpuViewModel);
            CPUService.Add(cpu_DTO);
            return RedirectToAction("AddItem", "Content");
        }
        public ActionResult ShowCPUs()
        {
            return View(Mapper.Map<IEnumerable<CPU_DTO>, IEnumerable<CPUViewModel>>(CPUService.GetList()));
        }
        public ActionResult ShowCPU(int id)
        {
            return View(Mapper.Map<CPU_DTO, CPUViewModel>(CPUService.Get(id)));
        }
        public ActionResult Index()
        {
            return View(CPUService.GetList());
        }

        [Authorized(Roles = "Developer, Admin, Moderator")]
        public void Delete(int id)
        {
            if (id != 0)
                CPUService.Delete(id);
        }
    }
}