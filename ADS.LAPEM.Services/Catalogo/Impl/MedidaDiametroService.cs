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
    public class MedidaDiametroService : IMedidaDiametroService
    {
        protected IMedidaDiametroRepository MedidaDiametroRepository { get; set; }

        public IEnumerable<MedidaDiametro> ReadMedidaDiametro()
        {
            return MedidaDiametroRepository.ReadMedidaDiametro();
        }

        public GridResult<MedidaDiametro> ReadMedidaDiametro(GridSettings grid)
        {
            return MedidaDiametroRepository.ReadMedidaDiametro(grid);
        }

        public MedidaDiametro ReadMedidaDiametroById(long id)
        {
            return MedidaDiametroRepository.ReadMedidaDiametroById(id);
        }
    }
}
