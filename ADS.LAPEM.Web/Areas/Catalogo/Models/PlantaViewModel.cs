using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Catalogo.Models
{
    public class PlantaViewModel  : BaseViewModel
    {
        public Planta Planta { get; set; }

        public PlantaViewModel(Planta planta)
        {
            Planta = planta;
        }
    }
}