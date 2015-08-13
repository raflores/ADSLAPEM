using ADS.LAPEM.Entities.Common;
using ADS.LAPEM.Resources.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bsd.Common.Infrastructure.Entity;

namespace ADS.LAPEM.Entities
{
    public class Linea : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "Nombre_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Linea))]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessageResourceName = "Planta_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Linea))]
        public long PlantaId { get; set; }

        public bool Activo { get; set; }

        public virtual Planta Planta { get; set; }
    }
}
