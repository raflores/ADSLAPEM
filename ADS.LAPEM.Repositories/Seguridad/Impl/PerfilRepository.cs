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
    public class PerfilRepository : GenericRepository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Perfil> ReadPerfil()
        {
            return Get();
        }

        public IQueryable<Perfil> ReadPerfil(Expression<Func<Perfil, bool>> predicate)
        {
            return Get(predicate);
        }

        public GridResult<Perfil> ReadPerfil(GridSettings grid)
        {
            return Get(grid);
        }

        public Perfil ReadPerfilById(long id)
        {
            return GetById(id);
        }

        public void CreatePerfil(Perfil perfil)
        {
            Add(perfil);
        }

        public void UpdatePerfil(Perfil perfil)
        {
            Edit(perfil);
        }

        public void DeletePerfil(Perfil perfil)
        {
            Remove(perfil);
        }
    }
}
