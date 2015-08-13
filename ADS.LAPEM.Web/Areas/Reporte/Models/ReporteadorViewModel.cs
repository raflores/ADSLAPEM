using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Reporte.Models
{

    public class ReporteadorViewModel
    {
        public List<columnas> columnas { get; set; }
        public string Identificador {get; set;}
        public bool FiltraFecha { get; set; }
        public DateTime? FechaProduccion { get; set; }


        public long? ProductoId { get; set; }
        public IEnumerable<Producto> Productos { get; set; }
        public IEnumerable<SelectListItem> lstProducto
        {
            get
            {
                return Productos.Select(x => new SelectListItem { Text = x.Codigo, Value = x.Id.ToString() });
            }
        }


        public long? NormaEnsayoId { get; set; }
        public IEnumerable<NormaEnsayo> Normas { get; set; }
        public IEnumerable<SelectListItem> lstNormas
        {
            get
            {
                return Normas.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }
    }

    public class columnas
    {
        public string grupo { get; set; }
        public string col { get; set; }
        public bool selected { get; set; }
    }

    public class excelDetalle
    {
        public long MuestraNum { get; set; }
        public string NombreAtributo { get; set; }
        public string Valor { get; set; }
        public bool Aprobado { get; set; }
    }
}