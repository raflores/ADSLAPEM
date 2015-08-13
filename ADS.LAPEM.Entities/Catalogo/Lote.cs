using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities.Common;
using ADS.LAPEM.Resources.Catalogo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bsd.Common.Infrastructure.Entity;

namespace ADS.LAPEM.Entities
{
    public class Lote : IEntity
    {
        [Key]
        public long Id { get; set; }

        public string Identificador { get; set; }

        public long? ProductoId { get; set; }

        public long LineaId { get; set; }
        
        public long TurnoId { get; set; }

        public DateTime FechaIngreso { get; set; }

        public DateTime FechaProduccion { get; set; }

        public DateTime FechaLiberacion { get; set; }

        public DateTime FechaSalida { get; set; }

        public decimal CantidadProducida { get; set; }

        public decimal SaldoLaboratorio { get; set; }

        public bool Aprobado { get; set; }

        public bool Activo { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Linea Linea { get; set; }
        public virtual Turno Turno { get; set; }
    }
}
