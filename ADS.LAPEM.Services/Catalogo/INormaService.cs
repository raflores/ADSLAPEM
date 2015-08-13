using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface INormaService
    {
        IEnumerable<Norma> ReadNorma(); 
        //IEnumerable<Norma> ReadNormaByProductoId(long id);
        GridResult<Norma> ReadNorma(GridSettings grid);
        Norma ReadNormaById(long id);        
        void CreateNorma(Norma norma);
        void UpdateNorma(Norma norma);
        void DeleteNorma(Norma norma);
    }
}
