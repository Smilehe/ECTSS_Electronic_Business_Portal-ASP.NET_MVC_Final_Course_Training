using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Webdiyer.WebControls.Mvc;
namespace Shop.Controllers
{
    public class StatisticsController : Controller
    {
        ECTSSMOD mod = new ECTSSMOD();
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserList(int? id)
        {
            id = id ?? 1;
            int pageSize = 2;
            IQueryable<AUser> temp = mod.AUsers.Where(c => c.Category == 1).OrderBy(c => c.ID);
            PagedList<AUser> pageList = temp.AsQueryable<AUser>().ToPagedList<AUser>(id.Value, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_UserList", pageList);
            }
            return View(pageList);
        }
    }
}