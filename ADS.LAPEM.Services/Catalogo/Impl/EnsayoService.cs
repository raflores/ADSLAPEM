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
    public class EnsayoService : IEnsayoService
    {
        protected IEnsayoRepository EnsayoRepository { get; set; }

        public IEnumerable<Ensayo> ReadEnsayo()
        {
            return EnsayoRepository.ReadEnsayo();
        }

        public GridResult<Ensayo> ReadEnsayo(GridSettings grid)
        {
            return EnsayoRepository.ReadEnsayo(grid);
        }

        public Ensayo ReadEnsayoById(long id)
        {
            return EnsayoRepository.ReadEnsayoById(id);
        }

        public void CreateEnsayo(Ensayo ensayo)
        {
            EnsayoRepository.CreateEnsayo(ensayo);
        }

        public void UpdateEnsayo(Ensayo ensayo)
        {
            EnsayoRepository.UpdateEnsayo(ensayo);
        }

        public void DeleteEnsayo(Ensayo ensayo)
        {
            EnsayoRepository.DeleteEnsayo(ensayo);
        }
    }
}
