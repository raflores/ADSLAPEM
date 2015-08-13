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
    public class NormaEnsayoValorMm : IEntity
    {
        [Key]
        public long Id { get; set; }

        public long MedidaDiametroId { get; set; }

        public double Maximo { get; set; }

        public double Minimo { get; set; }

        public double Objetivo { get; set; }

        public long Muestra { get; set; }

        [NotMapped]
        public bool Seleccionado { get; set; }

        public long NormaEnsayoId { get; set; }

        public long UnidadMedidaId { get; set; }

        public virtual NormaEnsayo NormaEnsayo { get; set; }
        public virtual MedidaDiametro MedidaDiametro { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }
    }
}
