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
    public class SmoothdbController : Controller
    {
        SmoothDBService data = new SmoothDBService();//實作service object

        public ActionResult Smooth_Index()
        {
            return View(data.GetSmoothData()); 
        }

        public ActionResult Smooth_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Smooth_Create(string _keyword)
        {
            //呼叫Service 中DBCreate method
            data.SmoothDBCreate(_keyword);

            //導向至指定的Action:Index
            return RedirectToAction("Smooth_Index");
        }
        public ActionResult Smooth_Create(int _cost, string _keyword)
        {
            //呼叫Service 中DBCreate method
            data.SmoothDBCreate( _cost, _keyword);

            //導向至指定的Action:Index
            return RedirectToAction("Smooth_Index");
        }
    }
}
