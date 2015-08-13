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
    public class ColorService : IColorService
    {
        protected IColorRepository ColorRepository { get; set; }

        public IEnumerable<Color> ReadColor()
        {
            return ColorRepository.ReadColor();
        }

        public GridResult<Color> ReadColor(GridSettings grid)
        {
            return ColorRepository.ReadColor(grid);
        }

        public Color ReadColorById(long id)
        {
            return ColorRepository.ReadColorById(id);
        }

        public void CreateColor(Color color)
        {
            ColorRepository.CreateColor(color);
        }

        public void UpdateColor(Color color)
        {
            ColorRepository.UpdateColor(color);
        }

        public void DeleteColor(Color color)
        {
            ColorRepository.DeleteColor(color);
        }
    }
}
