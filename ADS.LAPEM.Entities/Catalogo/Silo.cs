using ADS.LAPEM.Entities.Common;
using ADS.LAPEM.Resources.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Bsd.Common.Infrastructure.Entity;

namespace ADS.LAPEM.Entities
{
    public class Silo : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "NumSilo_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Silo))]
        public string NumSilo { get; set; }

        [Required(ErrorMessageResourceName = "Planta_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Silo))]
        public string Descripcion { get; set; }

        public long PlantaId { get; set; }

        public bool Activo { get; set; }

        public virtual Planta Planta { get; set; }
    }
}
