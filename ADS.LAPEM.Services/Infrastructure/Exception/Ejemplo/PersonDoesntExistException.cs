using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.LAPEM.Services.Infrastructure.Exception.Ejemplo
{
    public class PersonDoesntExistException : BaseException
    {
        public PersonDoesntExistException(string message) : base(message) { }
    }
}
