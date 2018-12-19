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
            //var result = studentBaseService.getStudentList();
            return View(data.GetSmoothData()); 
        }

        //[HttpGet]
        public ActionResult Smooth_Create()
        {
            //StudentViewModel data = new StudentViewModel();
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_cost"></param>
        /// <param name="_keyword"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Smooth_Create(int _cost, string _keyword)
        {
            data.SmoothDBCreate( _cost, _keyword);
            return RedirectToAction("Smooth_Index");
        }
    }
}
