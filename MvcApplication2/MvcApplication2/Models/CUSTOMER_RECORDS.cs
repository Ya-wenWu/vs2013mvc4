//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUSTOMER_RECORDS
    {
        public int NO { get; set; }
        public int MEMBER_ID { get; set; }
        public int DATE_Y { get; set; }
        public int DATE_M { get; set; }
        public int DATE_D { get; set; }
        public int COST { get; set; }
        public int KEYWORD { get; set; }
        public int RECEIPT_NUM { get; set; }
        public System.DateTime MODIFY_DATE { get; set; }
        public string MODIFY_USER { get; set; }
        public string CONTENT { get; set; }
    
        public virtual MEMBER_INFO MEMBER_INFO { get; set; }
    }
}