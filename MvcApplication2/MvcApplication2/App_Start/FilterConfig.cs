using System.Web;
using System.Web.Mvc;

namespace MvcApplication2
{
    /// <summary>
    /// global filter
    /// </summary>
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}