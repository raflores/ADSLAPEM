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
    public class Prueba : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "Nombre_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Prueba))]
        public string Nombre { get; set; }

        [Required(ErrorMessageResourceName = "CodFormato_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Prueba))]
        public string CodigoFormato { get; set; }

        [Required(ErrorMessageResourceName = "DatosEnsayo_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Prueba))]
        public string DatosEnsayo { get; set; }

        public long TipoPruebaId { get; set; }

        public virtual TipoPrueba TipoPrueba { get; set; }
    }
}
