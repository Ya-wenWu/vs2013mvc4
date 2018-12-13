using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Service;

namespace MvcApplication2.Controllers
{
    /// <summary>
    /// 石沐汗坊
    /// </summary>
    public class SmoothController : Controller
    {
        SmoothDBService data = new SmoothDBService();

        public ActionResult Smooth_Index()
        {
            return View(data.GetSmoothData()); 
        }
        public ActionResult Smooth_Create()
        {
            return View();
        }

        [HttpPost]
        //public ActionResult Smooth_Create(string _keyword)//不可以使用Override會出現異常(還不知道原因)
        //{
        //    data.SmoothDBCreate(_keyword);
        //    return RedirectToAction("Smooth_Index");
        //}
        public ActionResult Smooth_Create(int _cost, string _keyword)
        {
            data.SmoothDBCreate( _cost, _keyword);
            return RedirectToAction("Smooth_Index");
        }
    }
}
