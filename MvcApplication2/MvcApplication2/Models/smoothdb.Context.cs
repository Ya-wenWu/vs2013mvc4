﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class smoothdbEntities : DbContext
    {
        public smoothdbEntities()
            : base("name=smoothdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<MEMBER_INFO> MEMBER_INFO { get; set; }
        public DbSet<MEMBER_INFO2> MEMBER_INFO2 { get; set; }
        public DbSet<Table2> Table2 { get; set; }
        public DbSet<CONTENT> CONTENTs { get; set; }
        public DbSet<CUSTOMER_RECORDS> CUSTOMER_RECORDS { get; set; }
    }
}
