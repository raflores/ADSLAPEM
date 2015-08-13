using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ADS.LAPEM.Infrastructure.Web.Grid
{
    public class GridModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                var request = controllerContext.HttpContext.Request;
                return new GridSettings
                {
                    IsSearch = bool.Parse(request["_search"] ?? "false"),
                    PageIndex = int.Parse(request["page"] ?? "1"),
                    PageSize = int.Parse(request["rows"] ?? "10"),
                    SortColumn = request["sidx"] ?? "",
                    SortOrder = request["sord"] ?? "asc",
                    SearchField = request["searchField"] ?? "",
                    SearchOper = request["searchOper"] ?? "",
                    SearchString = request["searchString"] ?? "",
                    Where = GridFilter.Create(request["filters"] ?? "")

                };
            }
            catch
            {
                return null;
            }
        }
    }
}
