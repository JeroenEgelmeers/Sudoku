using System.Web;
using System.Web.Mvc;

namespace SA_Week5_Sudoku
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
