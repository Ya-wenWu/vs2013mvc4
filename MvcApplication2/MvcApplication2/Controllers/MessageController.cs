using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Service;

namespace MvcApplication2.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/

        //實作service object
        messageDBService data = new messageDBService();

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
        public ActionResult Create(String Table_TITLE, string CONTENT) 
        { 
            //呼叫Service 中DBCreate method
            data.DBCreate(Table_TITLE,CONTENT);

            //導向至指定的Action:Index
            return RedirectToAction("Index");
        }
    }
}
