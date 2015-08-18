using ADS.LAPEM.Entities.Example;
using ADS.LAPEM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.LAPEM.Repositories.Data
{
    public class LapemContext : DbContext
    {
        public LapemContext(string connectionString)
            : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Person> Person { get; set; }
        //Catalogos
        public DbSet<Atributo> Atributos { get; set; }
        public DbSet<AtributoDetalle> AtributosDetalle { get; set; }
        public DbSet<AtributoLote> AtributosLote { get; set; }
        public DbSet<AvisoPrueba> Avisos { get; set; }
        public DbSet<Calibracion> Calibraciones { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<EnsayoEquipo> EnsayosEquipo { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Especificacion> Especificaciones { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Norma> Normas { get; set; }
        public DbSet<NormaEnsayo> NormasEnsayo { get; set; }
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Prueba> Pruebas { get; set; }
        public DbSet<Silo> Silos { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<ResultadoDetalle> ResultadosDetalle { get; set; }
        public DbSet<ResultadoImagen> ResultadosImagen { get; set; }
        public DbSet<TipoEnsayo> TiposEnsayo { get; set; }
        public DbSet<TipoProducto> TiposProducto { get; set; }
        public DbSet<TipoPrueba> TiposPrueba { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<UnidadMedida> UnidadesMedida { get; set; }
        //Normas
        public DbSet<MedidaDiametro> MedidasDiametro { get; set; }
        public DbSet<NormaEnsayoValorIn> NormasValorIn { get; set; }
        public DbSet<NormaEnsayoValorMm> NormasValorMm { get; set; }
        //Seguridad
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<PerfilMenu> PerfilesMenu { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<NormaProducto> NormasProductos { get; set; }
        //Infraestructura
        public DbSet<SystemLog> SystemLog { get; set; }
    }

    /// <summary>
    /// Clase agregada para actualizar la BD con las nuevas clases.
    /// </summary>
    public class MigrationsContextFactory : IDbContextFactory<LapemContext>
    {
        public LapemContext Create()
        {
            return new LapemContext("LAPEM");
        }
    } 
}