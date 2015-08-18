using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface IEnsayoService
    {
        IEnumerable<Ensayo> ReadEnsayo();
        GridResult<Ensayo> ReadEnsayo(GridSettings grid);
        Ensayo ReadEnsayoById(long id);
        void CreateEnsayo(Ensayo ensayo);
        void UpdateEnsayo(Ensayo ensayo);
        void DeleteEnsayo(Ensayo ensayo);
    }
}
