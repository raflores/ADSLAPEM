using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using Bsd.Common.Infrastructure.Repository;
using Bsd.Common.Infrastructure.Repository.Impl;

namespace ADS.LAPEM.Repositories.Seguridad.Impl
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Usuario> ReadUsuario()
        {
            return Get();
        }

        public IQueryable<Usuario> ReadUsuario(Expression<Func<Usuario, bool>> exp)
        {
            return Get(exp);
        }

        public GridResult<Usuario> ReadUsuario(GridSettings grid)
        {
            return Get(grid);
        }

        public Usuario ReadUsuarioById(long id)
        {
            return GetById(id);
        }

        public void CreateUsuario(Usuario usuario)
        {
            Add(usuario);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            Edit(usuario);
        }

        public void DeleteUsuario(Usuario usuario)
        {
            Remove(usuario);
        }        
    }
}
