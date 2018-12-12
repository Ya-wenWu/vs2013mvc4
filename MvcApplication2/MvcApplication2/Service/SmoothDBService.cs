using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication2.Models;//include model namespace

namespace MvcApplication2.Service
{
    /// <summary>
    /// response for database I/O
    /// 1. 實作資料庫模型
    /// 2. 兩種公開方法的宣告：
    /// 　GetData() - 回傳資料庫中Article資料表的資料
    /// 　DBCreate() - 將接收的資料存進資料模型中
    /// </summary>
    public class SmoothDBService
    {
      //實作資料庫模型
      public MvcApplication2.Models.smoothdbEntities db = new Models.smoothdbEntities();

      //取得資料庫中，Article資料表的資料並回傳
      public List<CUSTOMER_RECORDS> GetData()
      { 
          return (db.CUSTOMER_RECORDS.ToList());
      }

      public void DBCreate(string _member_id, int _cost ,string _keyword) 
      {
            CUSTOMER_RECORDS NewData = new CUSTOMER_RECORDS();
            DateTime tmp_dt = DateTime.Now;
            //NewData.NO = ;//流水號
            NewData.MEMBER_ID = int.Parse(string.Format("{0:yyyyMMdd},{1:##########}",tmp_dt,_keyword));     //yyyymmdd+手機號碼(keyword:09xxxxxxxx)共18碼

            NewData.DATE_Y = int.Parse(tmp_dt.Year.ToString());                   //年
            NewData.DATE_M = int.Parse(tmp_dt.Month.ToString());                  //月
            NewData.DATE_D = int.Parse(tmp_dt.Day.ToString());                    //日

            NewData.COST = _cost;                 //消費金額
            NewData.KEYWORD = int.Parse(_keyword);//會員固定認證號碼
            NewData.RECEIPT_NUM = int.Parse(string.Format("{0:yyyyMMddHHmmssfffff},{1:#####}", tmp_dt,"99999"));
            NewData.MODIFY_DATE = DateTime.Now;
            NewData.MODIFY_USER = "SYS".ToString();
           
            //新增一筆資料
            db.CUSTOMER_RECORDS.Add(NewData);

            //儲存資料庫變更
            db.SaveChanges();
      }
        public void DBCreate(string _member_id, string _keyword)
        {
            CUSTOMER_RECORDS NewData = new CUSTOMER_RECORDS();
            DateTime tmp_dt = DateTime.Now;
            //NewData.NO = ;//流水號
            NewData.MEMBER_ID = int.Parse(string.Format("{0:yyyyMMdd},{1:##########}", tmp_dt, _keyword));     //yyyymmdd+手機號碼(keyword:09xxxxxxxx)共18碼

            NewData.DATE_Y = int.Parse(tmp_dt.Year.ToString());                   //年
            NewData.DATE_M = int.Parse(tmp_dt.Month.ToString());                  //月
            NewData.DATE_D = int.Parse(tmp_dt.Day.ToString());                    //日

            NewData.COST = 0;                 //消費金額
            NewData.KEYWORD = int.Parse(_keyword);//會員固定認證號碼
            NewData.RECEIPT_NUM = int.Parse(string.Format("{0:yyyyMMddHHmmssfffff},{1:#####}", tmp_dt, "99999"));
            NewData.MODIFY_DATE = DateTime.Now;
            NewData.MODIFY_USER = "SYS".ToString();

            //新增一筆資料
            db.CUSTOMER_RECORDS.Add(NewData);

            //儲存資料庫變更
            db.SaveChanges();
        }

    }
}