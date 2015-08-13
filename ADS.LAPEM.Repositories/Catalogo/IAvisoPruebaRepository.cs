using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface IAvisoPruebaRepository
    {
        IQueryable<AvisoPrueba> ReadAvisoPrueba();
        GridResult<AvisoPrueba> ReadAvisoPrueba(GridSettings grid);
        AvisoPrueba ReadAvisoPruebaById(long id);
        void CreateAvisoPrueba(AvisoPrueba aviso);
    }
}
