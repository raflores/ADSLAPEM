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
    public class EspecificacionService : IEspecificacionService
    {
        protected IEspecificacionRepository EspecificacionRepository { get; set; }

        public IEnumerable<Especificacion> ReadEspecificacion()
        {
            return EspecificacionRepository.ReadEspecificacion();
        }

        public GridResult<Especificacion> ReadEspecificacion(GridSettings grid)
        {
            return EspecificacionRepository.ReadEspecificacion(grid);
        }

        public Especificacion ReadEspecificacionById(long id)
        {
            return EspecificacionRepository.ReadEspecificacionById(id);
        }

        public void CreateEspecificacion(Especificacion especificacion)
        {
            EspecificacionRepository.CreateEspecificacion(especificacion);
        }

        public void UpdateEspecificacion(Especificacion especificacion)
        {
            EspecificacionRepository.UpdateEspecificacion(especificacion);
        }

        public void DeleteEspecificacion(Especificacion especificacion)
        {
            EspecificacionRepository.DeleteEspecificacion(especificacion);
        }

    }
}
