using System.Web.Http.Filters;
using System.Web.Mvc;
using Bekk.dontnetintro.WebApi.Blog.Filters;

namespace Bekk.dontnetintro.WebApi.Blog.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, HttpFilterCollection httpFilterCollection)
        {
            filters.Add(new HandleErrorAttribute());
            httpFilterCollection.Add(new ValidationActionFilter());
        }
    }
}