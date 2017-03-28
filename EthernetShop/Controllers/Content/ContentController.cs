using EthernetShop.Attributes;
using EthernetShop.Controllers.Content;
using EthernetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EthernetShop.Controllers
{
    public class ContentController : BaseController
    {
    //    [Authorized (Roles = "Developer, Admin, Moderator")]
        public ActionResult AddItem()
        {
            return View();
        }

    //    [Authorized(Roles = "Developer, Admin, Moderator")]
        public ActionResult ChooseContentForm(string categoryName)
        {
            switch (categoryName.ToUpper())
            {
                case "CPU":
                    return PartialView("AddCPU", new CPUViewModel());
                    break;
                case "GPU":
                    return PartialView("AddGPU", new GPUViewModel());
                    break;
                default:
                    return PartialView("AddCPU", new CPUViewModel());
                    break;
            }
        }

        public ActionResult ShowCategories()
        {
            return View();
        }
    }
}