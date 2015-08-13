using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface IMedidaDiametroRepository
    {
        IQueryable<MedidaDiametro> ReadMedidaDiametro();
        GridResult<MedidaDiametro> ReadMedidaDiametro(GridSettings grid);
        MedidaDiametro ReadMedidaDiametroById(long id);
    }
}
