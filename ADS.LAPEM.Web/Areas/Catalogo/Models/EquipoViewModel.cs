using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Catalogo.Models
{
    public class EquipoViewModel : BaseViewModel
    {
        public Equipo Equipo { get; set; }
        private IEnumerable<Planta> _plantas { get; set; }

        public EquipoViewModel(Equipo equipo)
        {
            Equipo = equipo;
        }

        public EquipoViewModel(Equipo equipo, IEnumerable<Planta> plantas)
        {
            Equipo = equipo;
            _plantas = plantas;
        }

        public IEnumerable<SelectListItem> Plantas
        {
            get
            {
                return _plantas.Select(x => new SelectListItem { Text = x.NombrePlanta, Value = x.Id.ToString() });
            }
        }
    }
}