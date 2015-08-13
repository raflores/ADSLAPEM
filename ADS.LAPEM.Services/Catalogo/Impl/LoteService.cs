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
    public class LoteService : ILoteService
    {
        protected ILoteRepository LoteRepository { get; set; }
        protected IResultadoRepository ResultadoRepository { get; set; }

        public IEnumerable<Lote> ReadLote()
        {
            return LoteRepository.ReadLote();
        }

        public GridResult<Lote> ReadLote(GridSettings grid)
        {
            return LoteRepository.ReadLote(grid);
        }

        public IEnumerable<Lote> ReadLoteByIdentificador(string identificador)
        {
            return LoteRepository.ReadLote(x => x.Identificador == identificador);
        }

        public Lote ReadLoteById(long id)
        {
            return LoteRepository.ReadLoteById(id);
        }

        public void CreateLote(Lote lote)
        {
            LoteRepository.CreateLote(lote);
        }

        public void UpdateLote(Lote lote)
        {
            LoteRepository.UpdateLote(lote);
        }

        public void DeleteLote(Lote lote)
        {
            LoteRepository.DeleteLote(lote);
        }

    }
}
