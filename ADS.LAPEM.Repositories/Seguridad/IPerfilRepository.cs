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
    public interface IPerfilRepository 
    {
        IQueryable<Perfil> ReadPerfil();
        IQueryable<Perfil> ReadPerfil(Expression<Func<Perfil, bool>> predicate);
        GridResult<Perfil> ReadPerfil(GridSettings grid);        
        Perfil ReadPerfilById(long id);
        void CreatePerfil(Perfil perfil);
        void UpdatePerfil(Perfil perfil);
        void DeletePerfil(Perfil perfil);

    }
}
