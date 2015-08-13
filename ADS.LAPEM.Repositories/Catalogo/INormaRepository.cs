using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface INormaRepository
    {
        IQueryable<Norma> ReadNorma();
        IQueryable<Norma> ReadNorma(Expression<Func<Norma, bool>> exp);
        GridResult<Norma> ReadNorma(GridSettings grid);
        Norma ReadNormaById(long id);        
        void CreateNorma(Norma norma);
        void UpdateNorma(Norma norma);
        void DeleteNorma(Norma norma);
    }
}
