using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Webdiyer.WebControls.Mvc;
using System.Text;

namespace Shop.Controllers
{
    public class UserManagementController : Controller
    {
        ECTSSMOD mod = new ECTSSMOD();
        static int xgid;        
        // GET: UserManagement
        public ActionResult Index()
        {
            return View();
        }
        //管理员管理   ↓
        //             
        public ActionResult Administrator(int? id,string whname = null)
        {
            id = id ?? 1;
            int pageSize = 2;
            ViewData["whname"] = whname;
            IQueryable<AUser> temp = mod.AUsers.Where(c => c.Category != 1).OrderBy(c => c.ID);
            temp = temp.Where(c => string.IsNullOrEmpty(whname) || c.Name.Contains(whname));
            PagedList<AUser> pageList = temp.AsQueryable<AUser>().ToPagedList<AUser>(id.Value, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_AuserList", pageList);
            }
            return View(pageList);
        }     //管理员展示

        public ActionResult See(int id)
        {
            var user = mod.AUsers.Find(id);
            return View(user);
        }
        public ActionResult Create()
        {
            return View();
        }       //管理员添加
        [HttpPost]
        public ActionResult CreateAdd()
        {
            string reu = "";
            if (Request["Name"] == "" || Request["Name"].Length==0)
            {
                reu = "*姓名不能为空";
            }
            else if(Request["Password"]=="" || Request["Password"].Length==0)
            {
                reu = "*密码不能为空";
            }
            else if(Request["QPassword"]=="" || Request["Password"]!=Request["QPassword"])
            {
                reu = "*密码不一致";
            }
            else if (Request["Category"]=="所有选项")
            {
                reu = "*请选择管理员类别";
            }
            else
            {
                AUser user = new AUser();
                string time = System.DateTime.Now.ToString("yyyyMMdd");
                var list = mod.AUsers.ToList();
                string accnumber = ("01" + time.Remove(0, 2) + list.Count.ToString());
                ViewData["AccNumber"] = accnumber;
                user.AccNumber = accnumber;
                user.Password = Request["Password"];
                user.Name = Request["Name"];
                if (Request["Category"] == "普通管理员")
                {
                    user.Category = 2;
                    user.Jurisdiction = 2;
                }
                else if (Request["Category"] == "超级管理员")
                {
                    user.Category = 3;
                    user.Jurisdiction = 3;
                }
                user.AccessRecord = 0;
                AUser auser = mod.AUsers.Add(user);
                mod.Configuration.ValidateOnSaveEnabled = false;
                int temp = mod.SaveChanges();
                mod.Configuration.ValidateOnSaveEnabled = true;
                if (temp > 0)
                {
                    reu = "添加成功！";
                }
            }
            return Content(reu);
        }    //管理员添加
        [HttpGet]  
        public ActionResult Updatte(int id)
        {
            xgid = id;
            var user = mod.AUsers.Find(id);              
            return View(user);
        }     //管理员修改
        [HttpPost]    
        public ActionResult Updatteed()
        {
            var user = mod.AUsers.Find(xgid);
            user.Password = Request["Password"];
            user.Name = Request["Name"];
            user.Nickname = Request["Nickname"];
            if(Request["Category"]=="2")
            {
                user.Category = 2;
            }
            else
            {
                user.Category = 3;
            }            
            mod.Configuration.ValidateOnSaveEnabled = false;
            int temp = mod.SaveChanges();
            mod.Configuration.ValidateOnSaveEnabled = true;
            if (temp>0)
            {
                return Content("<script>alert('更新成功!'); location='/UserManagement/Administrator'</script>");
            }
            return View();
        }      //管理员修改
        public ActionResult Delete(int id)
        {
            AUser user = mod.AUsers.Find(id);
            mod.AUsers.Remove(user);
            int temp = mod.SaveChanges();
            if(temp>0)
            {
                return Content("<script>alert('删除成功!'); location='/UserManagement/Administrator'</script>");
            }
            return View();
        }       //管理员删除
        //
        //管理员管理  ↑






        //用户管理     ↓
        //
        public ActionResult Users(int? id, string whname=null)
        {            
            id = id ?? 1;
            int pageSize = 2;
            ViewData["whname"] = whname;
            IQueryable<AUser> temp = mod.AUsers.Where(c => c.Category == 1).OrderBy(c => c.ID);
            temp = temp.Where(c => string.IsNullOrEmpty(whname) || c.Name.Contains(whname));
            PagedList<AUser> pageList = temp.AsQueryable<AUser>().ToPagedList<AUser>(id.Value, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_UsersList", pageList);
            }
            return View(pageList);
        }     //用户展示

        public ActionResult UserSee(int id)
        {
            var user = mod.AUsers.Find(id);
            return View(user);
        }


        public ActionResult CreateUser()
        {
            return View();
        }       //用户添加
        [HttpPost]
        public ActionResult CreateUserAdd()
        {
            string reu = "";
            if (Request["Name"] == "" || Request["Name"].Length == 0)
            {
                reu = "*姓名不能为空";
            }
            else if (Request["Password"] == "" || Request["Password"].Length == 0)
            {
                reu = "*密码不能为空";
            }
            else if (Request["QPassword"] == "" || Request["Password"] != Request["QPassword"])
            {
                reu = "*密码不一致";
            }
            else
            {
                AUser user = new AUser();
                string time = System.DateTime.Now.ToString("yyyyMMdd");
                var list = mod.AUsers.ToList();
                string accnumber = (time.Remove(0, 2) + list.Count.ToString());
                ViewData["AccNumber"] = accnumber;
                user.AccNumber = accnumber;
                user.Name = Request["Name"];
                user.Password = Request["Password"];
                user.Nickname = Request["Nickname"];
                user.Category = 1;
                user.Jurisdiction = 1;
                user.AccessRecord = 0;
                AUser auser = mod.AUsers.Add(user);
                mod.Configuration.ValidateOnSaveEnabled = false;
                int temp = mod.SaveChanges();
                mod.Configuration.ValidateOnSaveEnabled = true;
                if (temp > 0)
                {
                    reu = "添加成功！";
                }   
            }                     
            return Content(reu);
        }     //用户添加
        [HttpGet]
        public ActionResult UpdatteUser(int id)
        {
            xgid = id;
            var user = mod.AUsers.Find(id);
            return View(user);
        }      //用户修改
        [HttpPost]
        public ActionResult UpdatteUsered()
        {
            var user = mod.AUsers.Find(xgid);
            user.Password = Request["Password"];
            user.Name = Request["Name"];
            user.Nickname = Request["Nickname"];
            mod.Configuration.ValidateOnSaveEnabled = false;
            int temp = mod.SaveChanges();
            mod.Configuration.ValidateOnSaveEnabled = true;
            if (temp > 0)
            {
                return Content("<script>alert('更新成功!'); location='/UserManagement/Users'</script>");
            }
            return View();
        }    //用户修改
        public ActionResult DeleteUser(int id)
        {
            AUser user = mod.AUsers.Find(id);
            mod.AUsers.Remove(user);
            int temp = mod.SaveChanges();
            if (temp > 0)
            {
                return Content("<script>alert('删除成功!'); location='/UserManagement/Users'</script>");
            }
            return View();
        }      //用户删除
        //
        //用户管理     ↑
    }
}