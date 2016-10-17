using System.Web;
using System.Web.Mvc;

namespace ContactManager
{
   public class FilterConfig
   {
      public static void RegisterGlobalFilters(GlobalFilterCollection filters)
      {
         filters.Add(new HandleErrorAttribute());

         // authorize filter prevents anon users from
         // accessing any methods in the application.
         filters.Add(new System.Web.Mvc.AuthorizeAttribute());

         // only work over https.
         filters.Add(new RequireHttpsAttribute());

         // we apply these filters globally so that we don't
         // have to remember to add the filters in any future
         // controllers we create.
      }
   }
}
