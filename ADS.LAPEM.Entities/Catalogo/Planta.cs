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
    public class Planta : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "IdPlantaInterno_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Planta))] 
        [Range(0, 99, ErrorMessage="El valor deberá ser de solo 2 dígitos")]
        public long IdPlantaInterno { get; set; }

        [Required(ErrorMessageResourceName = "NombrePlanta_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Planta))]
        [StringLength(50, MinimumLength = 5)]
        public string NombrePlanta { get; set; }

        [Required(ErrorMessageResourceName = "RFC_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Planta))]
        [StringLength(15, MinimumLength = 13)]
        public string RFC { get; set; }

        [Required(ErrorMessageResourceName = "Direccion_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Planta))]
        public string Direccion { get; set; }

        [Required(ErrorMessageResourceName = "Ciudad_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Planta))]
        public string Ciudad { get; set; }
        [Required(ErrorMessageResourceName = "Estado_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Planta))]
        public string Estado { get; set; }

        public string Telefono { get; set; }

        public bool Activo { get; set; }

        public virtual ICollection<Linea> Lineas { get; set; }

    }
}
