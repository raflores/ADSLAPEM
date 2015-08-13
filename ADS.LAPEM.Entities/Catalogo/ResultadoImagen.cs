using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.LAPEM.Entities
{
    public class ResultadoImagen
    {
        public long Id { get; set; }
        public long ResultadoId { get; set; }
        public string Path { get; set; }
        public byte[] Imagen { get; set; }

        public virtual Resultado Resultado { get; set; }

        
    }
}
