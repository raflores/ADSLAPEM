using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using Bsd.Common.Infrastructure.Repository;
using Bsd.Common.Infrastructure.Repository.Impl;

namespace ADS.LAPEM.Repositories.Catalogo.Impl
{
    public class MedidaDiametroRepository : GenericRepository<MedidaDiametro>, IMedidaDiametroRepository
    {
        public MedidaDiametroRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<MedidaDiametro> ReadMedidaDiametro()
        {
            return Get();
        }

        public GridResult<MedidaDiametro> ReadMedidaDiametro(GridSettings grid)
        {
            return Get(grid);
        }

        public MedidaDiametro ReadMedidaDiametroById(long id)
        {
            return GetById(id);
        }
    }
}
