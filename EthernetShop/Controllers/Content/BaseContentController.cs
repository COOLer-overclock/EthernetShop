using EthernetShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EthernetShop.Controllers.Content
{
    public abstract class BaseContentController : BaseController
    {
        public void SaveImages(BaseContentViewModel model)
        {
            if ((Request.Files != null))
            {
                List<string> imagesDir = new List<string>();
                //string filePath = HttpContext.Server.MapPath("~/Content/Images");
                string virtualPath = @"/Content/Images/";
                string filePath;
                string fileName;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fileName = model.Name + "-" + (i + 1) + Request.Files[i].FileName.Replace(' ', '-');
                    filePath = Path.Combine(Server.MapPath(virtualPath), fileName);
                    //filePath = Path.Combine(filePath, model.Name + "-" + Request.Files[i].FileName.Replace(' ', '-') + "-" + i);
                    //model.Images.Add(filePath);
                    model.Images.Add(fileName);
                    Request.Files[i].SaveAs(filePath);
                    //filePath = HttpContext.Server.MapPath("~/Content/Images");
                }
            }
        }
    }
}