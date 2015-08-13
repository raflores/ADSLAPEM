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
    public class Norma : IEntity
    {   
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessageResourceName = "Norma_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Norma))]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool Prueba { get; set; }

        public bool Activo { get; set; }
    }
}
