using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using Shop.Models;
namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        ECTSSMOD mod = new ECTSSMOD();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var cateI = mod.CategoryIs.ToList();
            return View(cateI);
        }
        [HttpPost]
        public ActionResult CreateAdd()
        {
            string reu = "";
            if (Request["CategoryI"] == "" || Request["CategoryI"].Length==0)
            {
                reu = "*类别不能为空";
            }
            else
            {
                string cayI=Request["CategoryI"];
                CategoryI cateI = new CategoryI();
                var cateIlist = mod.CategoryIs.Where(p => p.Category == cayI).ToList();
                var cateIsum = mod.CategoryIs.ToList();
                if (cateIlist.Count != 0)
                {
                    reu = "*该类别I已存在";
                    return Content(reu);
                }
                else
                {
                    cateI.Number = (cateIsum.Count + 1);
                    cateI.Category = Request["CategoryI"];
                    CategoryI category = mod.CategoryIs.Add(cateI);
                    int item = mod.SaveChanges();
                    if(item>0)
                    {
                        return Content("*类别I添加成功");
                    }
                }
            }

            if (Request["CategoryII"] == "" || Request["CategoryII"].Length == 0)
            {
                reu = "*类别不能为空";
            }
            else
            {
                string xzcateI = Request["XZCategoryI"];
                string catII = Request["CategoryII"];
                CategoryII cateII = new CategoryII();
                var cateIIlist = mod.CategoryIIs.Where(p => p.Categoryl == catII).ToList();
                var cateIIsum = mod.CategoryIIs.ToList();
                var xzcatelist = mod.CategoryIs.Where(p => p.Category == xzcateI).ToList();     
                if(cateIIlist.Count!=0)
                {
                    reu = "*该类别II已存在";
                    return Content(reu);
                }
                else
                {
                    foreach(var item in xzcatelist)
                    {
                        cateII.CategorylID = item.Number;
                    }
                    cateII.Number = (cateIIsum.Count + 1);
                    cateII.Categoryl = Request["CategoryII"];
                    CategoryII category = mod.CategoryIIs.Add(cateII);
                    int temp = mod.SaveChanges();
                    if(temp>0)
                    {
                        return Content("*类别II添加成功");
                    }
                }

            }
            return Content(reu);
        }
    }
}