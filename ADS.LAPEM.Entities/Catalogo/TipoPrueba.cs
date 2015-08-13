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
    public class TipoPrueba : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "Nombre_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_TipoPrueba))]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
