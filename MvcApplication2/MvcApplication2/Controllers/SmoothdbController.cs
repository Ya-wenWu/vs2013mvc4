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
        // GET: /Message/

        //實作service object
        SmoothDBService data = new SmoothDBService();

        public ActionResult Index()
        {
            //將資料回傳view
            return View(data.GetData());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string _member_id, string _keyword)
        {
            //呼叫Service 中DBCreate method
            data.DBCreate(_member_id, _keyword);

            //導向至指定的Action:Index
            return RedirectToAction("Index");
        }
        public ActionResult Create(string _member_id, int _cost, string _keyword)
        {
            //呼叫Service 中DBCreate method
            data.DBCreate(_member_id, _cost, _keyword);

            //導向至指定的Action:Index
            return RedirectToAction("Index");
        }
    }
}
