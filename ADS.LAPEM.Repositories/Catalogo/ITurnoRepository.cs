﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Repositories.Catalogo
{
    public interface ITurnoRepository
    {
        IQueryable<Turno> ReadTurno();
        GridResult<Turno> ReadTurno(GridSettings grid);
        Turno ReadTurnoById(long id);
        void CreateTurno(Turno turno);
        void UpdateTurno(Turno turno);
        void DeleteTurno(Turno turno);
    }
}
