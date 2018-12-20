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
    public class messageDBService
    {
      //實作資料庫模型
      public MvcApplication2.Models.messageEntities db = new Models.messageEntities();

      //取得資料庫中，Article資料表的資料並回傳
      public List<Table> GetData()
      { 
          return (db.Table.ToList());
      }

      public void DBCreate(string Table_TITLE, string CONTENT) 
      { 
          //實作資料表
          Table NewData = new Table();
          NewData.TITLE = Table_TITLE;//文章標題
          NewData.CONTENT = CONTENT;//內容標題
          NewData.TIME = DateTime.Now;//文章發表時間

          //新增一筆資料
          db.Table.Add(NewData);//待修正

          //儲存資料庫變更
          db.SaveChanges();
      }

    }
}