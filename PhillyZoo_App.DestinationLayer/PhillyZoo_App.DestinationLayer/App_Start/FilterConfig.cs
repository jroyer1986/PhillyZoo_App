using System.Web;
using System.Web.Mvc;

namespace PhillyZoo_App.DestinationLayer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}