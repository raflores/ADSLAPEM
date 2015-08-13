using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Web.Infrastructure.Model;

namespace ADS.LAPEM.Web.Infrastructure.Grid
{
    [ModelBinder(typeof(GridModelBinderWeb))]
    public class GridSettingsWeb : GridSettings
    {
    }
}