using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;
using Bsd.Common.Infrastructure.Repository;
using Bsd.Common.Infrastructure.Repository.Impl;

namespace ADS.LAPEM.Repositories.Catalogo.Impl
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Color> ReadColor()
        {
            return Get();
        }

        public GridResult<Color> ReadColor(GridSettings grid)
        {
            return Get(grid);
        }

        public Color ReadColorById(long id)
        {
            return GetById(id);
        }

        public void CreateColor(Color color)
        {
            Add(color);
        }

        public void UpdateColor(Color color)
        {
            Edit(color);
        }

        public void DeleteColor(Color color)
        {
            Remove(color);
        }

    }
}
