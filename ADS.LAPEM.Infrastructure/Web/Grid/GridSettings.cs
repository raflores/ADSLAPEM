using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ADS.LAPEM.Infrastructure.Web.Grid
{
    [ModelBinder(typeof(GridModelBinder))]
    public class GridSettings
    {
        public bool IsSearch { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        //Simple Search
        public string SearchOper { get; set; }
        public string SearchField { get; set; }
        public string SearchString { get; set; }

        //Multiple Search
        public GridFilter Where { get; set; }
    }
}
