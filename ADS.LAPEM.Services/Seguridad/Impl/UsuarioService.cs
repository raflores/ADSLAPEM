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
    public class UsuarioService : IUsuarioService
    {
        protected IUsuarioRepository UsuarioRepository { get; set; }

        public IEnumerable<Usuario> ReadUsuario()
        {
            return UsuarioRepository.ReadUsuario();
        }

        public IEnumerable<Usuario> ReadUsuarioByUsername(string username)
        {
            return UsuarioRepository.ReadUsuario(x => x.Username == username);
        }

        public GridResult<Usuario> ReadUsuario(GridSettings grid)
        {
            return UsuarioRepository.ReadUsuario(grid);
        }

        public Usuario ReadUsuarioById(long id)
        {
            return UsuarioRepository.ReadUsuarioById(id);
        }

        public void CreateUsuario(Usuario usuario)
        {
            UsuarioRepository.CreateUsuario(usuario);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            UsuarioRepository.UpdateUsuario(usuario);
        }

        public void DeleteUsuario(Usuario usuario)
        {
            UsuarioRepository.DeleteUsuario(usuario);
        }
    }
}
