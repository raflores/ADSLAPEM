using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.LAPEM.Infrastructure.Common
{
    public class Constants
    {
        public enum GridWhereOperation
        {
            [StringValue("eq")]
            Equal,
            [StringValue("ne")]
            NotEqual,
            [StringValue("lt")]
            LessThan,
            [StringValue("le")]
            LessThanOrEqual,
            [StringValue("gt")]
            GreaterThan,
            [StringValue("ge")]
            GreaterThanOrEqual,
            [StringValue("bw")]
            BeginsWith,
            [StringValue("bn")]
            NotBeginsWith,
            [StringValue("in")]
            In,
            [StringValue("ni")]
            NotIn,
            [StringValue("ew")]
            EndWith,
            [StringValue("en")]
            NotEndWith,
            [StringValue("cn")]
            Contains,
            [StringValue("nc")]
            NotContains,
            [StringValue("nu")]
            Null,
            [StringValue("nn")]
            NotNull
        }
    }
}
