using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shop.Models;
namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        ECTSSMOD mod = new ECTSSMOD();
        List<Models.AUser> list;
        static string user = "";
        public ActionResult Index()
        {
            if (user == "")
            {
                return RedirectToAction("Login");
            }
            return View();
        } 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Verification(FormCollection f)
        {  
            string retu = "";
            string accnumber = f["accnumber"];
            string psw = f["psw"];
            if (accnumber=="" || psw=="")
            {
                retu = "*用户名或密码不能为空";
            }
            else
            {
                var list = mod.AUsers.Where(p => p.AccNumber == accnumber).ToList();
                if(list.Count==0)
                {
                    retu = "*该用户不存在";
                }
                else
                {
                    foreach(var u in list)
                    {
                        if(u.Password== psw)
                        {
                            ViewData["user"] = f["accnumber"];
                            user = f["accnumber"];
                            return Content("<script>location='/Home/Index'</script>");
                        }
                        else
                        {
                            retu = "*密码错误，请重新输入";
                        }
                    }
                }
            }
            return Content(retu);
        }        
    }
}