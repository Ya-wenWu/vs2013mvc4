using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    /// <summary>
    /// Home Controller's Actions
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "修改這個樣板 to jump-start 你的ASP.NET MVC 應用程式.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "你的應用程式敘述頁面.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "你的聯絡資料頁面.";

            return View();
        }
    }
}
