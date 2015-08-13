using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.LAPEM.Infrastructure.Web.Grid
{
    public class GridResult<T> where T : class
    {
        public IEnumerable<T> Rows { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }
}
