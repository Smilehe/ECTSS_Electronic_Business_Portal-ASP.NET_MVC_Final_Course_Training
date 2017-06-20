using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Webdiyer.WebControls.Mvc;
namespace Shop.Controllers
{
    public class SupplierController : Controller 
    {
        ECTSSMOD mod = new ECTSSMOD();
        static int xgid = 0;
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SupplierList(int? id, string whname = null)
        {
            id = id ?? 1;
            int pageSize = 2;
            ViewData["whname"] = whname;
            IQueryable<Supplier> temp = mod.Suppliers.OrderBy(c => c.ID);
            temp = temp.Where(c => string.IsNullOrEmpty(whname) || c.Name.Contains(whname));
            PagedList<Supplier> pageList = temp.AsQueryable<Supplier>().ToPagedList<Supplier>(id.Value, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_SupplierList", pageList);
            }
            return View(pageList);           
        }

        public ActionResult See(int id)
        {
            var supp = mod.Suppliers.Find(id);
            return View(supp);
        }

        public ActionResult  Create()
        {
            List<CategoryI> cateIList = mod.CategoryIs.ToList();
            ViewBag.cateIList = cateIList;
            return View();
        }
        public ActionResult CreateCxcateI(int id)
        {            
            List<CategoryII> cateIIList = mod.CategoryIIs.Where(p => p.CategorylID == id).ToList();
            return Json(cateIIList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateAdd()
        {
            string reu = "";
            if(Request["Name"]=="" || Request["Address"] == "" || Request["Postcode"] == "" || Request["ContNumber"] == "" || Request["Contacts"] == "" || Request["BankAccount"] == "")
            {
                return Content("*请把信息填写完整");
            }
            if (Request["CategoryI"] == "0" || Request["CategoryII"] == "0")
            {
                return Content("*请选择类别信息");
            }
            Supplier supp = new Supplier();
            var list = mod.Suppliers.ToList();
            supp.Number = (list.Count + 1);
            supp.Name = Request["Name"];
            supp.Address = Request["Address"];
            supp.Postcode = Request["Postcode"];
            supp.ContNumber = Request["ContNumber"];
            supp.Contacts = Request["Contacts"];
            supp.BankAccount = Request["BankAccount"];
            supp.CommodityI = int.Parse(Request["CategoryI"]);
            supp.CommodityII = int.Parse(Request["CategoryII"]);
            supp.Keyword = "XX/XX";
            Supplier su = mod.Suppliers.Add(supp);
            int temp = mod.SaveChanges();
            if(temp>0)
            {
                reu = "*添加成功";
            }
            else
            {
                reu = "*添加失败";
            }
            return Content(reu);
        }
        public ActionResult Updatte(int id)
        {
            xgid = id;
            List<CategoryI> cateIList = mod.CategoryIs.ToList();
            ViewBag.cateIList = cateIList; 
            var supp = mod.Suppliers.Find(id);
            return View(supp);
        }
        public ActionResult Updatteed()
        {
            Supplier supp = mod.Suppliers.Find(xgid);
            supp.Name = Request["Name"];
            supp.Address = Request["Address"];
            supp.Postcode = Request["Postcode"];
            supp.ContNumber = Request["ContNumber"];
            supp.Contacts = Request["Contacts"];
            if(Request["CategoryI"]=="0" || Request["CategoryII"]=="0")
            {
                return Content("*请选择类别");
            }
            supp.CommodityI = int.Parse(Request["CategoryI"]);
            supp.CommodityII = int.Parse(Request["CategoryII"]);
            mod.Configuration.ValidateOnSaveEnabled = false;
            int temp = mod.SaveChanges();
            mod.Configuration.ValidateOnSaveEnabled = false;
            if(temp>0)
            {
                return Content("<script>alert('更新成功!'); location='/Supplier/SupplierList'</script>");
            }
            return Content("*更新失败");
        }
        public ActionResult Delete(int id)
        {
            Supplier supp = mod.Suppliers.Find(id);
            mod.Suppliers.Remove(supp);
            int temp = mod.SaveChanges();
            if (temp > 0)
            {
                return Content("<script>alert('删除成功!'); location='/Supplier/SupplierList'</script>");
            }
            return View();
        }
    }
}