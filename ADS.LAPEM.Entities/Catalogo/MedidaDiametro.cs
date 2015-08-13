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
    public class MedidaDiametro : IEntity
    {
        [Key]
        public long Id { get; set; }

        public int ValorIn { get; set; }

        public int ValorMm { get; set; }
    }
}
