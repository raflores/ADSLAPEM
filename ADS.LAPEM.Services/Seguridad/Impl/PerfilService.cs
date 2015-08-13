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
    public class PerfilService : IPerfilService
    {
        protected IPerfilRepository PerfilRepository { get; set; }

        public IEnumerable<Perfil> ReadPerfil()
        {
            return PerfilRepository.ReadPerfil();
        }

        public GridResult<Perfil> ReadPerfil(GridSettings grid)
        {
            return PerfilRepository.ReadPerfil(grid);
        }

        public Perfil ReadPerfilByName(string name)
        {
            return PerfilRepository.ReadPerfil(x => x.Nombre.Equals(name)).FirstOrDefault();
        }

        public Perfil ReadPerfilById(long id)
        {
            return PerfilRepository.ReadPerfilById(id);
        }

        public void CreatePerfil(Perfil perfil)
        {
            PerfilRepository.CreatePerfil(perfil);
        }

        public void UpdatePerfil(Perfil perfil)
        {
            PerfilRepository.UpdatePerfil(perfil);
        }

        public void DeletePerfil(Perfil perfil)
        {
            PerfilRepository.DeletePerfil(perfil);
        }
    }
}
