using EthernetShop.Attributes;
using EthernetShop.Models;
using System;
using System.Web.Mvc;

namespace EthernetShop.Controllers
{
    public class ContentController : BaseController
    {
        [Authorized (Roles = "Developer, Admin, Moderator")]
        public ActionResult AddItem()
        {
            return View();
        }
        [Authorized(Roles = "Developer, Admin, Moderator")]
        public ActionResult ChooseContentForm(string categoryName)
        {
            switch (categoryName.ToUpper())
            {
                case "CPU":
                    return PartialView("AddCPU", new CPUViewModel());
                case "GPU":
                    return PartialView("AddGPU", new GPUViewModel());
                default:
                    return PartialView("AddCPU", new CPUViewModel());
            }
        }
        public ActionResult ShowItem(string categoryName, int itemId)
        {
            switch (categoryName.ToUpper())
            {
                case "CPU":
                    return RedirectToAction("ShowCPU", "CPU", new { id = itemId });
                case "GPU":
                    return RedirectToAction("ShowGPU", "GPU", new { id = itemId });
            }
            return Content("Opssssss....Something went wrong :)");
        }
        public ActionResult ShowCategories()
        {
            return View();
        }
    }
}