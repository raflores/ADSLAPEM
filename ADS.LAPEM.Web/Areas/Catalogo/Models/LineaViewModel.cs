﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Catalogo.Models
{
    public class LineaViewModel : BaseViewModel
    {
        public Linea Linea { get; set; }
        private IEnumerable<Planta> _plantas;

        public LineaViewModel(Linea linea)
        {
            Linea = linea;
        }

        public LineaViewModel(Linea linea, IEnumerable<Planta> plantas)
        {
            Linea = linea;
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