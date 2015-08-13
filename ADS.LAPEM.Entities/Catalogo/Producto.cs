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
    public class Producto : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "Codigo_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Producto))]
        public string Codigo { get; set; }

        [Required(ErrorMessageResourceName = "Nombre_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Producto))]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessageResourceName = "Diametro_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Producto))]
        public long MedidaDiametroId { get; set; }

        public decimal Longitud { get; set; }

        [Required(ErrorMessageResourceName = "TipoProd_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Producto))]
        public long TipoProductoId { get; set; }

        [Required(ErrorMessageResourceName = "Proveedor_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Producto))]
        public long ProveedorId { get; set; }
        public IList<NormaProducto> Norma { get; set; }

        [Required(ErrorMessageResourceName = "Color_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Producto))]
        public long ColorId { get; set; }

        public bool Activo { get; set; }

        //public string Diametro { get; set; }

        //public string MasaProyectil { get; set; }

        //public string Acondicionamiento { get; set; }

        //public string EnergiaRequerida { get; set; }

        //public string TipoProyectil { get; set; }

        //public string TemperaturaProm { get; set; }

        //public string AlturaProyectil { get; set; }

        //public string PresionRequerida { get; set; }

        //public string VacioRequerido { get; set; }

        //public string DistanciaApoyo { get; set; }

        //public string Deflexion { get; set; }

        //public string Tiempo { get; set; }

        //public string Desalineamiento { get; set; }

        public virtual MedidaDiametro MedidaDiametro { get; set; }
        public virtual TipoProducto TipoProducto { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual Color Color { get; set; }
    }
}
