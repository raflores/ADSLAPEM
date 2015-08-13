using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Seguridad
{
    public interface IPerfilService
    {
        IEnumerable<Perfil> ReadPerfil();
        GridResult<Perfil> ReadPerfil(GridSettings grid);
        Perfil ReadPerfilByName(string name);
        Perfil ReadPerfilById(long id);
        void CreatePerfil(Perfil perfil);
        void UpdatePerfil(Perfil perfil);
        void DeletePerfil(Perfil perfil);        
    }
}
