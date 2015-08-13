using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Repositories.Seguridad;

namespace ADS.LAPEM.Services.Seguridad.Impl
{
    public class SystemLogService : ISystemLogService
    {
        protected ISystemLogRepository SystemLogRepository { get; set; }

        public IEnumerable<SystemLog> ReadLog()
        {
            return SystemLogRepository.ReadLog();
        }

        public GridResult<SystemLog> ReadLog(GridSettings grid)
        {
            return SystemLogRepository.ReadLog(grid);
        }

        public SystemLog ReadLogById(long id)
        {
            return SystemLogRepository.ReadLogById(id);
        }

        public void CreateLog(SystemLog log)
        {
            SystemLogRepository.CreateLog(log);
        }

        public void UpdateLog(SystemLog log)
        {
            SystemLogRepository.UpdateLog(log);
        }

        public void DeleteLog(SystemLog log)
        {
            SystemLogRepository.DeleteLog(log);
        }
    }
}
