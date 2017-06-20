using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Webdiyer.WebControls.Mvc;

namespace Shop.Controllers
{    
    public class OrderManagementController : Controller
    {
        ECTSSMOD mod = new ECTSSMOD();
        static int cateIId = 0;
        // GET: OrderManagement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderList(int? id)
        {
            id = id ?? 1;
            int pageSize = 7;
            IQueryable<Order> temp = mod.Orders.OrderBy(c => c.ID);            
            PagedList<Order> pageList = temp.AsQueryable<Order>().ToPagedList<Order>(id.Value, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_OrderList", pageList);
            }
            return View(pageList);                        
        }     //订单显示列表

        public ActionResult See(int id)
        {
            var order = mod.Orders.Find(id);
            return View(order);
        }


        //public ActionResult Create()
        //{
        //    List<CategoryI> cateIList = mod.CategoryIs.ToList();
        //    ViewBag.cateIList = cateIList;
        //    return View();
        //}
        //public ActionResult CreateCxcateI(int id)
        //{
        //    cateIId = id;
        //    List<CategoryII> cateIIList = mod.CategoryIIs.Where(p => p.CategorylID == id).ToList();
        //    return Json(cateIIList, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult CreateCxSupp(int id)
        //{
        //    List<Supplier> cateIIList = mod.Suppliers.Where(p => p.CommodityI == cateIId).ToList();
        //    cateIIList = cateIIList.Where(p => p.CommodityII == id).ToList();
        //    return Json(cateIIList, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult CreateCxShop(int id)
        //{
        //    List<Shops> cateIIList = mod.Shops.Where(p => p.Supplier == id).ToList();            
        //    return Json(cateIIList, JsonRequestBehavior.AllowGet);
        //}
        //[HttpPost]
        //public ActionResult CreatteAdd()
        //{
        //    //ID ID编号
        //    //Number 订单编号
        //    //SoNumber 商品编号
        //    //SoNum 商品数量
        //    //CategoryI 类别I
        //    //CategoryII 类别II
        //    //SuNumber 供应商编号
        //    //Total 总额
        //    //Payment 是否付款(0否，1是)
        //    //DelGoods 是否发货(0否，1是)
        //    //Time 订单时间
        //    Order order = new Order();
        //    string reu = "";
        //    string ccate = Request["CategoryI"];
        //    if (Request["CategoryI"] =="0" || Request["CategoryII"] == "0" || Request["Supplier"] == "0" || Request["Shops"] == "0")
        //    {
        //        reu = "*请详细填写订单";
        //        return Content(reu);
        //    }
        //    if(Request["Sum"] =="")
        //    {
        //        reu = "*请输入订购数量";
        //        return Content(reu);
        //    }
        //    string Number = System.DateTime.Now.ToString("yyyyMMdd").Remove(0, 2);   //Number 订单编号

        //    double PurPrice = 0;
        //    string SoNumber = Request["Shops"];  //SoNumber 商品编号
        //    var shoplist = mod.Shops.Where(p => p.Number == SoNumber).ToList();
        //    foreach(var item in shoplist)
        //    {                
        //        PurPrice = item.PurPrice;
        //    }

        //    int Sum = int.Parse(Request["Sum"]);   //SoNum 商品数量
                        
        //    string CategoryI = Request["CategoryI"];

        //    string CategoryII = Request["CategoryII"];

        //    string SuNumber = Request["Supplier"];
        //    if(Request["Fm"]=="货到付款")
        //    {
        //        order.Payment = 0;
        //    }
        //    else
        //    {

        //    }
        //    order.Number = (Number + SoNumber + CategoryI + CategoryII + SuNumber);
        //    order.SoNumber = SoNumber;
        //    order.SoNum = Sum;
        //    order.CategoryI = CategoryI;
        //    order.CategoryII = CategoryII;
        //    order.SuNumber = SuNumber;
        //    order.Total = int.Parse((PurPrice * Sum).ToString());
        //    order.DelGoods = 0;
        //    order.Time = System.DateTime.Now.ToString();
                        
        //    Order or = mod.Orders.Add(order);
        //    mod.Configuration.ValidateOnSaveEnabled = false;
        //    int temp = mod.SaveChanges();
        //    mod.Configuration.ValidateOnSaveEnabled = true;
        //    if (temp>0)
        //    {
        //        reu = "*已生成订单";
        //    }
        //    return Content(reu);
        //}
        public ActionResult Delete(int id)
        {
            Order order = mod.Orders.Find(id);
            mod.Orders.Remove(order);
            int temp = mod.SaveChanges();
            if (temp > 0)
            {
                return Content("<script>alert('删除成功!'); location='/OrderManagement/OrderList'</script>");
            }
            return View();
        }
    }
}