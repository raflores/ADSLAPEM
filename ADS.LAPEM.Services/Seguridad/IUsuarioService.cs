using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Seguridad
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> ReadUsuario();
        IEnumerable<Usuario> ReadUsuarioByUsername(string username);
        GridResult<Usuario> ReadUsuario(GridSettings grid);
        Usuario ReadUsuarioById(long id);
        void CreateUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(Usuario usuario);
    }
}
