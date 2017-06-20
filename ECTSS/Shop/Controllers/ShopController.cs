using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using Shop.Models;
namespace Shop.Controllers
{
    public class ShopController : Controller
    {
        ECTSSMOD mod = new ECTSSMOD();
        static int cateIId;
        static int xgid;
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }   
        public ActionResult ListOfGoods(int? id, string whname = null)
        {
            id = id ?? 1;
            int pageSize = 2;
            ViewData["whname"] = whname;
            IQueryable<Shops> temp = mod.Shops.OrderBy(c => c.ID);
            temp = temp.Where(c => string.IsNullOrEmpty(whname) || c.Name.Contains(whname));
            PagedList<Shops> pageList = temp.AsQueryable<Shops>().ToPagedList<Shops>(id.Value, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ShopList", pageList);
            }
            return View(pageList);
        }

        public ActionResult See(int id)
        {
            var shop = mod.Shops.Find(id);
            return View(shop);
        }

        public ActionResult Creat()
        {
            List<CategoryI> cateIList = mod.CategoryIs.ToList();
            ViewBag.cateIList = cateIList;
            return View();
        }
        public ActionResult CreateCxcateI(int id)
        {
            cateIId = id;
            List<CategoryII> cateIIList = mod.CategoryIIs.Where(p => p.CategorylID == id).ToList();
            return Json(cateIIList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateCxSupp(int id)
        {
            List<Supplier> cateIIList = mod.Suppliers.Where(p => p.CommodityI == cateIId).ToList();
            cateIIList = cateIIList.Where(p => p.CommodityII == id).ToList();
            return Json(cateIIList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreatAdd()
        {
            if (Request["Name"] == "" || Request["PurPrice"] == "" || Request["Price"] == "")
            {
                return Content("*请把商品信息填写完整");
            }
            if (Request["CategoryI"] == "0" || Request["CategoryII"] == "0" || Request["Supplier"] == "0")
            {
                return Content("*商品详情信息");
            }
            Shops shop = new Shops();
            string name = Request["Name"];

            var shopcz = mod.Shops.Where(p => p.Name == name).ToList();
            
            if(shopcz.Count==1)
            {
                return Content("*该商品已存在");
            }
            var shoplist = mod.Shops.ToList();
            shop.Number = (shoplist.Count + 1).ToString();
            shop.Name = Request["Name"];
            shop.PurPrice = float.Parse(Request["PurPrice"]);
            shop.Price = float.Parse(Request["Price"]);
            shop.SalesVolumes = 0;
            shop.CategoryI = int.Parse(Request["CategoryI"]);
            shop.CategoryII = int.Parse(Request["CategoryII"]);
            shop.Supplier = int.Parse(Request["Supplier"]);
            shop.KeyAttribute = "";
            Shops sh = mod.Shops.Add(shop);
            mod.Configuration.ValidateOnSaveEnabled = false;
            int temp = mod.SaveChanges();
            mod.Configuration.ValidateOnSaveEnabled = true;
            return Content("*商品添加成功");
        }
        public ActionResult Updatte(int id)
        {
            xgid = id;
            List<CategoryI> cateIList = mod.CategoryIs.ToList();
            ViewBag.cateIList = cateIList;
            var shop = mod.Shops.Find(id);
            return View(shop);
        }
        public ActionResult Updatteed()
        {
            if(Request["CategoryI"] =="0" || Request["CategoryII"] == "0")
            {
                return Content("*请选择类别");
            }
            if(Request["CategoryI"] == "0")
            {
                return Content("*请选择供应商");
            }
            var shop = mod.Shops.Find(xgid);
            shop.Name = Request["Name"];
            shop.PurPrice = float.Parse(Request["PurPrice"]);
            shop.Price= float.Parse(Request["Price"]);
            shop.CategoryI= int.Parse(Request["CategoryI"]);
            shop.CategoryII= int.Parse(Request["CategoryII"]);
            shop.Supplier= int.Parse(Request["Supplier"]);
            int temp = mod.SaveChanges();
            if(temp>0)
            {
                return Content("<script>alert('更新成功!'); location='/Shop/ListOfGoods'</script>");
            }
            return Content("*更新失败");
        }
        public ActionResult Delete(int id)
        {
            Shops shop = mod.Shops.Find(id);
            mod.Shops.Remove(shop);
            int temp = mod.SaveChanges();
            if (temp > 0)
            {
                return Content("<script>alert('删除成功!'); location='/Shop/ListOfGoods'</script>");
            }
            return View();
        }
    }
}