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
    public class Proveedor : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "Nombre_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Proveedor))]
        public string Nombre { get; set; }

        public string Giro { get; set; }

        [Required(ErrorMessageResourceName = "RFC_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Proveedor))]
        [StringLength(15, MinimumLength = 13)]
        public string RFC { get; set; }

        [Required(ErrorMessageResourceName = "Direccion_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Proveedor))]
        public string Direccion { get; set; }

        [Required(ErrorMessageResourceName = "Ciudad_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Proveedor))]
        public string Ciudad { get; set; }

        [Required(ErrorMessageResourceName = "Estado_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Proveedor))]
        public string Estado { get; set; }
        public string CorreoContacto { get; set; }
        public string NombreContacto { get; set; }
        public string TelContacto { get; set; }
        public bool Activo { get; set; }
    }
}
