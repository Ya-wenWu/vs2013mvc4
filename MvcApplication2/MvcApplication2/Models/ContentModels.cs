using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    //加入content資料表處理模組
    public class ContentModels : smoothdbEntities
    {
        public string Message_name { get; set; }

        public string Message_content { get; set; }
    }
}