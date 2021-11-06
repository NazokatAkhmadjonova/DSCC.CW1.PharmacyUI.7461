using System.Web;
using System.Web.Mvc;

namespace DSCC.CW1.PharmacyUI._7461
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
