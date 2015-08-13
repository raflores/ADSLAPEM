using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.LAPEM.Services.Infrastructure.Exception
{
    public class BaseException : System.Exception
    {
        public BaseException(string message) : base(message) { }
    }
}
