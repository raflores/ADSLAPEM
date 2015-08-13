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
    public class Color : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "Color_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Color))]
        public string Nombre { get; set; }

        public string Tipo { get; set; }

        [StringLength(3, MinimumLength = 3)]
        [Required(ErrorMessageResourceName = "Codigo_Length", ErrorMessageResourceType = typeof(LAPEM_Entities_Color))]
        public string Codigo { get; set; }

        public bool Activo { get; set; }
    }
}
