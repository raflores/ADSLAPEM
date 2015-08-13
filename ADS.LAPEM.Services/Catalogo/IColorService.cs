using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo
{
    public interface IColorService
    {
        IEnumerable<Color> ReadColor();
        GridResult<Color> ReadColor(GridSettings grid);
        Color ReadColorById(long id);
        void CreateColor(Color color);
        void UpdateColor(Color color);
        void DeleteColor(Color color);
    }
}
