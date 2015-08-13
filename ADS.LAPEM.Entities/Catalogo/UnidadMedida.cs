using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities.Common;
using ADS.LAPEM.Resources.Catalogo;
using System.ComponentModel.DataAnnotations;


namespace ADS.LAPEM.Entities
{
    public class UnidadMedida
    {
        [Key]
        public long Id { get; set; }

        public string Nombre { get; set; }

        public string SimboloUM { get; set; }
    }
}
