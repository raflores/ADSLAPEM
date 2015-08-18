using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.LAPEM.Entities
{
    public class Resultado
    {
        public long Id { get; set; }
        public int Aprobado { get; set; }
        public long LoteId { get; set; }
        public DateTime FechaPrueba { get; set; }
        public long EquipoId { get; set; }
        //public long MuestraNum { get; set; }
        public long NormaID { get; set; }
        public long NormaEnsayoId { get; set; }
        public long UnidadMedidaId { get; set; }
        public long EnsayoId { get; set; }
        //public long EspecificacionId { get; set; }
        //public long NormaMnxm { get; set; }
        public string NormaUM { get; set; }
        public decimal NormaVMax { get; set; }
        public decimal NormaVMin { get; set; }
        public decimal NormaObjetivo { get; set; }
        //public long PruebaId { get; set; }
        //public string PruebaDesc { get; set; }
        public long ProductoId { get; set; }
        public decimal ResultadoValor { get; set; }
        public long UsuarioId { get; set; }
        public bool EnviadoLapem { get; set; }
        public string Observaciones { get; set; }

        public virtual Ensayo Ensayo { get; set; }
        public virtual Norma Norma { get; set; }
        public virtual Lote Lote { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }
        public virtual NormaEnsayo NormaEnsayo { get; set; }        
    }
}