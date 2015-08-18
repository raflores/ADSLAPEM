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
    public class CalibracionService : ICalibracionService
    {
        protected ICalibracionRepository CalibracionRepository { get; set; }

        public IEnumerable<Calibracion> ReadCalibracion()
        {
            return CalibracionRepository.ReadCalibracion();
        }

        public GridResult<Calibracion> ReadCalibracion(GridSettings grid)
        {
            return CalibracionRepository.ReadCalibracion(grid);
        }

        public Calibracion ReadCalibracionById(long id)
        {
            return CalibracionRepository.ReadCalibracionById(id);
        }

        public void CreateCalibracion(Calibracion calibracion)
        {
            CalibracionRepository.CreateCalibracion(calibracion);
        }

        public void UpdateCalibracion(Calibracion calibracion)
        {
            CalibracionRepository.UpdateCalibracion(calibracion);
        }

        public void DeleteCalibracion(Calibracion calibracion)
        {
            CalibracionRepository.DeleteCalibracion(calibracion);
        }
    }
}
