using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;


namespace ADS.LAPEM.Web.Areas.Catalogo.Models
{
    public class SiloViewModel : BaseViewModel
    {
        public Silo Silo { get; set; }
        private IEnumerable<Planta> _plantas;

        public SiloViewModel(Silo silo)
        {
            Silo = silo;
        }

        public SiloViewModel(Silo silo, IEnumerable<Planta> plantas)
        {
            Silo = silo;
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