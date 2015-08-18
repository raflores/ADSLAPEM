using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface ILoteService
    {
        IEnumerable<Lote> ReadLote();
        GridResult<Lote> ReadLote(GridSettings grid);
        IEnumerable<Lote> ReadLoteByIdentificador(string identificador);
        Lote ReadLoteById(long id);
        void CreateLote(Lote lote);
        void UpdateLote(Lote lote);
        void DeleteLote(Lote lote);
    }
}
