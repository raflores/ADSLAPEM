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
    public class EnsayoEquipo : IEntity
    {
        [Key]
        public long Id { get; set; }

        public long EnsayoId { get; set; }

        public long EquipoId { get; set; }

        public bool Activo { get; set; }

        public virtual Ensayo Ensayo { get; set; }

        public virtual Equipo Equipo { get; set; }

    }
}
