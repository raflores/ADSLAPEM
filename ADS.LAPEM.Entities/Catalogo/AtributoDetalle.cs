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
    public class AtributoDetalle : IEntity
    {
        [Key]
        public long Id { get; set; }

        public long ResultadoDetalleId { get; set; }

        public long AtributoId { get; set; }

        public string Valor { get; set; }

        public virtual Atributo Atributo { get; set; }
        public virtual ResultadoDetalle ResultadoDetalle { get; set; }
    }
}
