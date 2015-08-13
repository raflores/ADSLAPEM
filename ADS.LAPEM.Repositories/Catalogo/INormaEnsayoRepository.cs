using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface INormaEnsayoRepository
    {
        IQueryable<NormaEnsayo> ReadNormaEnsayo();
        IQueryable<NormaEnsayo> ReadNormaEnsayo(string properties);
        GridResult<NormaEnsayo> ReadNormaEnsayo(GridSettings grid);
        NormaEnsayo ReadNormaEnsayoById(long id);
        void CreateNormaEnsayo(NormaEnsayo normaEnsayo);
        void UpdateNormaEnsayo(NormaEnsayo normaEnsayo);
        void DeleteNormaEnsayo(NormaEnsayo normaEnsayo);
    }
}
