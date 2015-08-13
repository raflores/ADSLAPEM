using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;

namespace ADS.LAPEM.Services.Infrastructure
{
    public interface IMailService
    {
        bool EnviarCorreo(Calibracion calibracion, List<string> correos);
    }
}
