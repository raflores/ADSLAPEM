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
    public class ResultadoDetalle : IEntity
    {
        [Key]
        public long Id { get; set; }

        public long ResultadoId { get; set; }
        public DateTime FechaPrueba { get; set; }
        public long EquipoId { get; set; }
        public long MuestraNum { get; set; }
        public string NormaUM { get; set; }
        public decimal NormaVMax { get; set; }
        public decimal NormaVMin { get; set; }
        public decimal NormaObjetivo { get; set; }
        public decimal ResultadoDetalleValor { get; set; }
        public long UsuarioId { get; set; }

        public virtual Resultado Resultado { get; set; }        

    }
}
