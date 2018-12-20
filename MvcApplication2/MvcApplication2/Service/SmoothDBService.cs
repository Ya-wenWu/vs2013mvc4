using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication2.Models;//include model namespace
using MvcApplication2.Controllers;

namespace MvcApplication2.Service
{
    /// <summary>
    /// 1. 實作資料庫模型
    /// 2. 兩種公開方法的宣告：
    /// 　GetData()  - 回傳資料庫中Article資料表的資料
    /// 　DBCreate() - 將接收的資料存進資料模型中
    /// </summary>
    public class SmoothDBService
    {
         smoothdbEntities db = new smoothdbEntities();

        #region  取得資料庫中，CISTOMER_RECORDS資料表的資料並回傳
        public List<CUSTOMER_RECORDS> GetSmoothData()
        {
          try
          {
              return (db.CUSTOMER_RECORDS.ToList());
          }
          catch (Exception ex)
          {
              #region 回傳預設資料
              List<CUSTOMER_RECORDS>  tmp_res = new List<CUSTOMER_RECORDS>();
              tmp_res.Add(new CUSTOMER_RECORDS { NO=00000000000 });
              tmp_res.Add(new CUSTOMER_RECORDS { MEMBER_ID = 00000000 });
              tmp_res.Add(new CUSTOMER_RECORDS { DATE_Y = 00000000 });
              tmp_res.Add(new CUSTOMER_RECORDS { DATE_M = 00000000 });
              tmp_res.Add(new CUSTOMER_RECORDS { DATE_D = 00000000 });
              tmp_res.Add(new CUSTOMER_RECORDS { COST = 00000000 });
              tmp_res.Add(new CUSTOMER_RECORDS { KEYWORD = "00000000" });
              tmp_res.Add(new CUSTOMER_RECORDS { RECEIPT_NUM = 00000000 });
              tmp_res.Add(new CUSTOMER_RECORDS { MODIFY_DATE = DateTime.Now });
              tmp_res.Add(new CUSTOMER_RECORDS { MODIFY_USER = "exception error" });
              //tmp_res.Add(new CUSTOMER_RECORDS { CONTENT = "exception recore"+ex.Message.ToString() });
              #endregion
              return tmp_res;
          } 
        }
        #endregion

        /// <summary>
        /// 加入會員到訪紀錄
        /// </summary>
        /// <param name="_cost">消費金額</param>
        /// <param name="_keyword">手機號碼</param>
        #region 將使用者輸入內容存放到資料庫中(消費金額+關鍵字)
        public void SmoothDBCreate(int _cost ,string _keyword) 
        {
            CUSTOMER_RECORDS NewData = new CUSTOMER_RECORDS();
            DateTime tmp_dt = DateTime.Now;

            int number;
            bool success = Int32.TryParse(_keyword, out number);
            if (success)
                number = Convert.ToInt32(_keyword);

            //判斷_keyword是否為小於10碼,若否就顯示手機號碼需小於十碼
            if (Math.Floor(Math.Log10(number) + 1) > 10)
            {
                //todo:顯示輸入手機號碼錯誤訊息
            }
            else
            {
                //todo:存入會員編號時的資料型態會出現問題
                //NewData.MEMBER_ID = int.Parse(string.Format("{0:yyyyMMdd},{1:###########}", DateTime.Now, _keyword));     //yyyymmdd+手機號碼(keyword:09xxxxxxxx)共18碼
                NewData.MEMBER_ID = number;

                NewData.DATE_Y = int.Parse(tmp_dt.Year.ToString());                   //年
                NewData.DATE_M = int.Parse(tmp_dt.Month.ToString());                  //月
                NewData.DATE_D = int.Parse(tmp_dt.Day.ToString());                    //日

                NewData.COST = _cost;                 //消費金額
                NewData.KEYWORD = _keyword;//會員固定認證號碼
                                           //todo:存入RECEIPT_NUM時的資料型態會出現問題
                                           //NewData.RECEIPT_NUM = int.Parse(string.Format("{0:yyyyMMddHHmmssfffff},{1:#####}", tmp_dt,"99999"));
                NewData.RECEIPT_NUM = NewData.DATE_Y + NewData.DATE_M + NewData.DATE_D + 567897 + int.Parse(tmp_dt.Hour.ToString()) + int.Parse(tmp_dt.Second.ToString()) + int.Parse(tmp_dt.Minute.ToString());
                NewData.MODIFY_DATE = DateTime.Now;
                NewData.MODIFY_USER = "SYS".ToString();
                NewData.NOTE = "NONE".ToString();

                //新增一筆資料
                db.CUSTOMER_RECORDS.Add(NewData);

                //儲存資料庫變更
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        #endregion

        #region 存放資料庫(關鍵字)
        public void SmoothDBCreate(string _keyword)
        {
            CUSTOMER_RECORDS NewData = new CUSTOMER_RECORDS();
            DateTime tmp_dt = DateTime.Now;
            //NewData.NO = ;//流水號
            NewData.MEMBER_ID = int.Parse(string.Format("{0:yyyyMMdd},{1:##########}", tmp_dt, _keyword));     //yyyymmdd+手機號碼(keyword:09xxxxxxxx)共18碼

            NewData.DATE_Y = int.Parse(tmp_dt.Year.ToString());                   //年
            NewData.DATE_M = int.Parse(tmp_dt.Month.ToString());                  //月
            NewData.DATE_D = int.Parse(tmp_dt.Day.ToString());                    //日

            NewData.COST = 0;                 //消費金額
            NewData.KEYWORD = _keyword;//會員固定認證號碼
            NewData.RECEIPT_NUM = int.Parse(string.Format("{0:yyyyMMddHHmmssfffff},{1:#####}", tmp_dt, "99999"));
            NewData.MODIFY_DATE = DateTime.Now;
            NewData.MODIFY_USER = "SYS".ToString();

            db.CUSTOMER_RECORDS.Add(NewData);//新增一筆資料
            db.SaveChanges();//儲存資料庫變更
        }
        #endregion

        /// <summary>
        /// 加入留言內容(Smoothdb的CONTENT table)
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_content"></param>
        public void Create_Conent(string _name, string _content)
        {
            CONTENT adddata = new CONTENT();

            //資料繫結
            adddata.name = _name;
            adddata.content1 = _content;

            //將資料加入content資料表中
            //db.ContentModels.Add(adddata);
            db.CONTENTs.Add(adddata);
            db.SaveChanges();
        }
        /// <summary>
        /// 新增資料表CONTENT，採用CONTENTs模組
        /// </summary>
        /// <param name="_Newdata"></param>
        public void Create(CONTENT _Newdata)
        {
            //將資料加入資料表
            db.CONTENTs.Add(_Newdata);
            //儲存資料庫變更
            db.SaveChanges();
        }
    }
}