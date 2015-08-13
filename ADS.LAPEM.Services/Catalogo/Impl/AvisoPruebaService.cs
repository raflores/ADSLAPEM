using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Repositories.Catalogo;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo.Impl
{
    public class AvisoPruebaService : IAvisoPruebaService
    {
        protected IAvisoPruebaRepository AvisoPruebaRepository { get; set; }

        public IEnumerable<AvisoPrueba> ReadAvisoPrueba()
        {
            return AvisoPruebaRepository.ReadAvisoPrueba();
        }

        public GridResult<AvisoPrueba> ReadAvisoPrueba(GridSettings grid)
        {
            return AvisoPruebaRepository.ReadAvisoPrueba(grid);
        }

        public AvisoPrueba ReadAvisoPruebaById(long id)
        {
            return AvisoPruebaRepository.ReadAvisoPruebaById(id);
        }

        public void CreateAvisoPrueba(AvisoPrueba aviso)
        {
            AvisoPruebaRepository.CreateAvisoPrueba(aviso);
        }
    }
}
