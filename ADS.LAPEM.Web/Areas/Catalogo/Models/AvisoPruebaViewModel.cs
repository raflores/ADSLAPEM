using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Catalogo.Models
{
    public class AvisoPruebaViewModel : BaseViewModel
    {
        public AvisoPrueba AvisoPrueba { get; set; }

        public AvisoPruebaViewModel(AvisoPrueba avisoPrueba)
        {
            AvisoPrueba = avisoPrueba;
        }


        //public Lote Lote { get; set; }
        //public IList<Lote> Lotes { get; set; }

        //public AvisoPruebaViewModel(Lote lote)
        //{
        //    Lote = lote;
        //}

    }
}