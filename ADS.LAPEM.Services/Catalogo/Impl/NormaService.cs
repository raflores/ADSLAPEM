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
    public class NormaService : INormaService
    {
        protected INormaRepository NormaRepository { get; set; }
        protected IProductoRepository ProductoRepository { get; set; }

        public IEnumerable<Norma> ReadNorma()
        {
            return NormaRepository.ReadNorma();
        }

        //public IEnumerable<Norma> ReadNormaByProductoId(long id)
        //{
        //    return NormaRepository.ReadNorma(x => x.ProductoId == id);
        //}

        public GridResult<Norma> ReadNorma(GridSettings grid)
        {
            return NormaRepository.ReadNorma(grid);
        }

        public Norma ReadNormaById(long id)
        {
            return NormaRepository.ReadNormaById(id);
        }

        public void CreateNorma(Norma norma)
        {
            NormaRepository.CreateNorma(norma);
        }

        public void UpdateNorma(Norma norma)
        {
            NormaRepository.UpdateNorma(norma);         
        }

        public void DeleteNorma(Norma norma)
        {
            NormaRepository.DeleteNorma(norma);
        }
    }
}
