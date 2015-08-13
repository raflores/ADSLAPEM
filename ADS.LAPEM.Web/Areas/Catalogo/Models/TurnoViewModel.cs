using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Catalogo.Models
{
    public class TurnoViewModel : BaseViewModel
    {

        public Turno Turno { get; set; }

        public TurnoViewModel(Turno turno)
        {
            Turno = turno;
        }
    }
}