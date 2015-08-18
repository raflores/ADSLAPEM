using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.LAPEM.Entities.Common
{
    public class RegExConstants
    {
        public const string ALPHANUMERIC = @"^[A-Za-z0-9]*$";
        public const string ALPHANUMERIC_TILDE = @"^[A-Za-z0-9ñáéíóúÑÁÉÍÓÚ\.\,\;\:\/\*\ \$\(\)\-]*$";
        public const string ALPHA = @"^[A-Za-z]*$";
        public const string NUMERIC = @"^[0-9]*$"; 
    }
}
