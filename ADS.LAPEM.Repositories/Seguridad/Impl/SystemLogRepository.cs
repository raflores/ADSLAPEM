using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using Bsd.Common.Infrastructure.Repository;
using Bsd.Common.Infrastructure.Repository.Impl;
using System.Linq.Expressions;

namespace ADS.LAPEM.Repositories.Seguridad.Impl
{
    public class SystemLogRepository : GenericRepository<SystemLog>, ISystemLogRepository
    {
        public SystemLogRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<SystemLog> ReadLog()
        {
            return Get();
        }

        public GridResult<SystemLog> ReadLog(GridSettings grid)
        {
            return Get(grid);
        }

        public SystemLog ReadLogById(long id)
        {
            return GetById(id);
        }

        public void CreateLog(SystemLog log)
        {
            Add(log);
        }

        public void UpdateLog(SystemLog log)
        {
            Edit(log);
        }

        public void DeleteLog(SystemLog log)
        {
            Remove(log);
        }
    }
}
