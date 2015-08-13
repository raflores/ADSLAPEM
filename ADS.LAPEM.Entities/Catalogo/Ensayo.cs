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
    public class Ensayo
    {
        [Key]
        public long Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [NotMapped]
        public bool Activo { get; set; }

    }
}
