using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using MvcApplication2.Models;

namespace MvcApplication2.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        /// <summary>
        /// 初始化資料庫實體
        /// </summary>
        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                //建立初始化 SetUnitializer 資料型態為UserContext:DBContent 的泛型類別
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    //新建一個新的UsersContext物件來啟動跟初始化DefaultConnection資料庫連結
                    using (var context = new UsersContext())
                    {
                        //確認資料庫是否活著
                        if (!context.Database.Exists())
                        {
                            //如果不存在就建立一個不使用entity framework的資料庫連線，此處建立System.Data.Objects.
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }
                    //以安全性跟授權特徵方式(WebSercurtiy)啟動資料庫連結-DefaultConnection(資料庫名稱,Table名稱,欄位名稱1,欄位名稱2,bool 自動生成資料表)
                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}
