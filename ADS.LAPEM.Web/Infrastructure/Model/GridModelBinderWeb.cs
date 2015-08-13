using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Web.Infrastructure.Grid;

namespace ADS.LAPEM.Web.Infrastructure.Model
{
    public class GridModelBinderWeb : GridModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            GridSettings settings = (GridSettings)base.BindModel(controllerContext, bindingContext);
            ObtenerFiltros(settings, controllerContext);
            return new GridSettingsWeb
            {
                IsSearch = settings.IsSearch,
                PageIndex = settings.PageIndex,
                PageSize = settings.PageSize,
                SortColumn = settings.SortColumn,
                SortOrder = settings.SortOrder,
                Where = settings.Where
            };
        }

        protected void ObtenerFiltros(GridSettings settings, ControllerContext controllerContext)
        {
            if (settings.Where == null)
            {
                settings.Where = new GridFilter();
                List<GridRule> rules = new List<GridRule>();
                settings.Where.rules = rules.ToArray();
            }
        }
    }
}