using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;//引入db模組
using MvcApplication2.Service;

namespace MvcApplication2.Controllers
{
    /// <summary>
    /// 石沐汗坊
    /// </summary>
    public class SmoothController : Controller
    {
        SmoothDBService data = new SmoothDBService();//bd物件藉由實體資料模型所宣告

        public ActionResult Smooth_Index()
        {
            return View(data.GetSmoothData());
        }

        //[HttpGet]
        /// <summary>
        /// 顯示加入會員來訪紀錄頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Smooth_Create()
        {
            return View();
        }

        /// <summary>
        /// 新增一筆交易資料
        /// </summary>
        /// <param name="_cost"></param>
        /// <param name="_keyword"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Smooth_Create(int _cost, string _keyword)
        {
            data.SmoothDBCreate(_cost, _keyword);

            //todo:收到controller回傳的結果在進行結果跳轉與顯示
           return RedirectToAction("Smooth_Index");
        }

    }
}
