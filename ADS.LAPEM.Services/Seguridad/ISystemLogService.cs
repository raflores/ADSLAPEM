using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Seguridad
{
    public interface ISystemLogService
    {
        IEnumerable<SystemLog> ReadLog();
        GridResult<SystemLog> ReadLog(GridSettings grid);
        SystemLog ReadLogById(long id);
        void CreateLog(SystemLog log);
        void UpdateLog(SystemLog log);
        void DeleteLog(SystemLog log);        
    }    
}


