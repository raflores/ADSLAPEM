using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities.Common;
using ADS.LAPEM.Resources.Catalogo;
using System.ComponentModel.DataAnnotations;
using Bsd.Common.Infrastructure.Entity;

namespace ADS.LAPEM.Entities
{
    public class AvisoPrueba : IEntity
    {
        [Key]
        public long Id { get; set; }

        public int NoProveedor { get; set; }

        public string FamiliaId { get; set; }

        public string UnidadId { get; set; }

        public string Pedido { get; set; }

        public int Partida { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Costo { get; set; }

        public string Moneda { get; set; }

        public decimal Iva { get; set; }

        public string Destino { get; set; }

        public string Observaciones { get; set; }

        public long ProductoId { get; set; }

        public string DescProducto { get; set; }

        public string TipoAviso { get; set; }

        public long PruebaId { get; set; }

        public long LoteId { get; set; }

        public long NumAviso { get; set; }

        public string XmlAviso { get; set; }

        public string XmlSerie { get; set; }

        public virtual Lote Lote { get; set; }

    }
}
