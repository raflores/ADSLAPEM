using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using System.Linq.Expressions;

namespace ADS.LAPEM.Repositories.Seguridad
{
    public interface IUsuarioRepository
    {
        IQueryable<Usuario> ReadUsuario();
        IQueryable<Usuario> ReadUsuario(Expression<Func<Usuario, bool>> exp);
        GridResult<Usuario> ReadUsuario(GridSettings grid);
        Usuario ReadUsuarioById(long id);
        void CreateUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(Usuario usuario);
    }
}
