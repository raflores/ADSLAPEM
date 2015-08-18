namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Person",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Firstname = c.String(nullable: false, maxLength: 50),
            //            Lastname = c.String(nullable: false, maxLength: 50),
            //            Email = c.String(nullable: false, maxLength: 50),
            //            CreatedDate = c.DateTime(nullable: false),
            //            Telephone = c.String(maxLength: 10),
            //        })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.Calibracion",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            EquipoId = c.Long(nullable: false),
            //            FechaCalibracion = c.DateTime(nullable: false),
            //            FechaVencimiento = c.DateTime(nullable: false),
            //            NoInformeCalib = c.Int(nullable: false),
            //            PDFInforme = c.String(nullable: false),
            //            Comentarios = c.String(),
            //            ProveedorId = c.Long(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Equipo", t => t.EquipoId, cascadeDelete: true)
            //    .ForeignKey("dbo.Proveedor", t => t.ProveedorId, cascadeDelete: true)
            //    .Index(t => t.EquipoId)
            //    .Index(t => t.ProveedorId);

            //CreateTable(
            //    "dbo.Equipo",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            CodigoActivoFijo = c.Int(nullable: false),
            //            Serie = c.String(nullable: false),
            //            Marca = c.String(nullable: false),
            //            Modelo = c.String(nullable: false),
            //            Descripcion = c.String(),
            //            FechaCompra = c.DateTime(nullable: false),
            //            Activo = c.Boolean(nullable: false),
            //            RazonBorrado = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.Proveedor",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false),
            //            Giro = c.String(),
            //            RFC = c.String(nullable: false, maxLength: 15),
            //            Direccion = c.String(nullable: false),
            //            Ciudad = c.String(nullable: false),
            //            Estado = c.String(nullable: false),
            //            CorreoContacto = c.String(),
            //            NombreContacto = c.String(),
            //            TelContacto = c.String(),
            //            Activo = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.Linea",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false),
            //            Descripcion = c.String(),
            //            PlantaId = c.Long(nullable: false),
            //            Activo = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Planta", t => t.PlantaId, cascadeDelete: true)
            //    .Index(t => t.PlantaId);

            //CreateTable(
            //    "dbo.Planta",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            IdPlantaInterno = c.Long(nullable: false),
            //            NombrePlanta = c.String(nullable: false, maxLength: 50),
            //            RFC = c.String(nullable: false, maxLength: 15),
            //            Direccion = c.String(nullable: false),
            //            Ciudad = c.String(nullable: false),
            //            Estado = c.String(nullable: false),
            //            Telefono = c.String(),
            //            Activo = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.Norma",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            NormaProductoId = c.Long(nullable: false),
            //            ProductoId = c.Long(),
            //            Activo = c.Boolean(nullable: false),
            //            Prueba = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Producto", t => t.ProductoId)
            //    .ForeignKey("dbo.NormaProducto", t => t.NormaProductoId, cascadeDelete: true)
            //    .Index(t => t.ProductoId)
            //    .Index(t => t.NormaProductoId);

            //CreateTable(
            //    "dbo.Producto",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Codigo = c.String(nullable: false),
            //            Nombre = c.String(nullable: false),
            //            Descripcion = c.String(),
            //            MedidaDiametroId = c.Long(nullable: false),
            //            TipoProductoId = c.Long(nullable: false),
            //            ProveedorId = c.Long(nullable: false),
            //            Activo = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.MedidaDiametro", t => t.MedidaDiametroId, cascadeDelete: true)
            //    .ForeignKey("dbo.TipoProducto", t => t.TipoProductoId, cascadeDelete: true)
            //    .ForeignKey("dbo.Proveedor", t => t.ProveedorId, cascadeDelete: true)
            //    .Index(t => t.MedidaDiametroId)
            //    .Index(t => t.TipoProductoId)
            //    .Index(t => t.ProveedorId);

            //CreateTable(
            //    "dbo.MedidaDiametro",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            ValorIn = c.Int(nullable: false),
            //            ValorMm = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.TipoProducto",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false),
            //            Descripcion = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.NormaProducto",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false),
            //            CantidadMuestra = c.Int(nullable: false),
            //            Activo = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.NormaEnsayo",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false),
            //            Descripcion = c.String(),
            //            TipoEnsayoId = c.Long(nullable: false),
            //            NormaProductoId = c.Long(nullable: false),
            //            UnidadMedidaId = c.Long(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.TipoEnsayo", t => t.TipoEnsayoId, cascadeDelete: true)
            //    .ForeignKey("dbo.NormaProducto", t => t.NormaProductoId, cascadeDelete: true)
            //    .ForeignKey("dbo.UnidadMedida", t => t.UnidadMedidaId, cascadeDelete: true)
            //    .Index(t => t.TipoEnsayoId)
            //    .Index(t => t.NormaProductoId)
            //    .Index(t => t.UnidadMedidaId);

            //CreateTable(
            //    "dbo.TipoEnsayo",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nombre = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.UnidadMedida",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nombre = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.NormaEnsayoValorIn",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            MedidaDiametroId = c.Long(nullable: false),
            //            Maximo = c.Double(nullable: false),
            //            Minimo = c.Double(nullable: false),
            //            Objetivo = c.Double(nullable: false),
            //            NormaEnsayoId = c.Long(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.MedidaDiametro", t => t.MedidaDiametroId, cascadeDelete: true)
            //    .ForeignKey("dbo.NormaEnsayo", t => t.NormaEnsayoId, cascadeDelete: true)
            //    .Index(t => t.MedidaDiametroId)
            //    .Index(t => t.NormaEnsayoId);

            //CreateTable(
            //    "dbo.NormaEnsayoValorMm",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            MedidaDiametroId = c.Long(nullable: false),
            //            Maximo = c.Double(nullable: false),
            //            Minimo = c.Double(nullable: false),
            //            Objetivo = c.Double(nullable: false),
            //            NormaEnsayoId = c.Long(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.NormaEnsayo", t => t.NormaEnsayoId, cascadeDelete: true)
            //    .ForeignKey("dbo.MedidaDiametro", t => t.MedidaDiametroId, cascadeDelete: true)
            //    .Index(t => t.NormaEnsayoId)
            //    .Index(t => t.MedidaDiametroId);

            //CreateTable(
            //    "dbo.Prueba",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false),
            //            CodigoFormato = c.String(nullable: false),
            //            DatosEnsayo = c.String(nullable: false),
            //            TipoPruebaId = c.Long(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.TipoPrueba", t => t.TipoPruebaId, cascadeDelete: true)
            //    .Index(t => t.TipoPruebaId);

            //CreateTable(
            //    "dbo.TipoPrueba",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false),
            //            Descripcion = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.Silo",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            NumSilo = c.String(nullable: false),
            //            Descripcion = c.String(),
            //            PlantaId = c.Long(nullable: false),
            //            Activo = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Planta", t => t.PlantaId, cascadeDelete: true)
            //    .Index(t => t.PlantaId);

            //CreateTable(
            //    "dbo.Menu",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false),
            //            Descripcion = c.String(),
            //            Padre = c.Int(nullable: false),
            //            Action = c.String(),
            //            Controller = c.String(),
            //            Area = c.String(),
            //            Activo = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.Perfil",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 50),
            //            Descripcion = c.String(),
            //            Activo = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.PerfilMenu",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            PerfilId = c.Long(nullable: false),
            //            MenuId = c.Long(nullable: false),
            //            Activo = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Perfil", t => t.PerfilId, cascadeDelete: true)
            //    .ForeignKey("dbo.Menu", t => t.MenuId, cascadeDelete: true)
            //    .Index(t => t.PerfilId)
            //    .Index(t => t.MenuId);

            //CreateTable(
            //    "dbo.Permiso",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            PerfilId = c.Long(nullable: false),
            //            MenuId = c.Long(nullable: false),
            //            Activo = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Perfil", t => t.PerfilId, cascadeDelete: true)
            //    .ForeignKey("dbo.Menu", t => t.MenuId, cascadeDelete: true)
            //    .Index(t => t.PerfilId)
            //    .Index(t => t.MenuId);

            //CreateTable(
            //    "dbo.Usuario",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Nombre = c.String(nullable: false, maxLength: 50),
            //            Username = c.String(nullable: false, maxLength: 20),
            //            PlantaId = c.Long(nullable: false),
            //            Puesto = c.String(),
            //            Email = c.String(),
            //            PerfilId = c.Long(nullable: false),
            //            Activo = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Planta", t => t.PlantaId, cascadeDelete: true)
            //    .ForeignKey("dbo.Perfil", t => t.PerfilId, cascadeDelete: true)
            //    .Index(t => t.PlantaId)
            //    .Index(t => t.PerfilId);

        }

        public override void Down()
        {
            //DropIndex("dbo.Usuario", new[] { "PerfilId" });
            //DropIndex("dbo.Usuario", new[] { "PlantaId" });
            //DropIndex("dbo.Permiso", new[] { "MenuId" });
            //DropIndex("dbo.Permiso", new[] { "PerfilId" });
            //DropIndex("dbo.PerfilMenu", new[] { "MenuId" });
            //DropIndex("dbo.PerfilMenu", new[] { "PerfilId" });
            //DropIndex("dbo.Silo", new[] { "PlantaId" });
            //DropIndex("dbo.Prueba", new[] { "TipoPruebaId" });
            //DropIndex("dbo.NormaEnsayoValorMm", new[] { "MedidaDiametroId" });
            //DropIndex("dbo.NormaEnsayoValorMm", new[] { "NormaEnsayoId" });
            //DropIndex("dbo.NormaEnsayoValorIn", new[] { "NormaEnsayoId" });
            //DropIndex("dbo.NormaEnsayoValorIn", new[] { "MedidaDiametroId" });
            //DropIndex("dbo.NormaEnsayo", new[] { "UnidadMedidaId" });
            //DropIndex("dbo.NormaEnsayo", new[] { "NormaProductoId" });
            //DropIndex("dbo.NormaEnsayo", new[] { "TipoEnsayoId" });
            //DropIndex("dbo.Producto", new[] { "ProveedorId" });
            //DropIndex("dbo.Producto", new[] { "TipoProductoId" });
            //DropIndex("dbo.Producto", new[] { "MedidaDiametroId" });
            //DropIndex("dbo.Norma", new[] { "NormaProductoId" });
            //DropIndex("dbo.Norma", new[] { "ProductoId" });
            //DropIndex("dbo.Linea", new[] { "PlantaId" });
            //DropIndex("dbo.Calibracion", new[] { "ProveedorId" });
            //DropIndex("dbo.Calibracion", new[] { "EquipoId" });
            //DropForeignKey("dbo.Usuario", "PerfilId", "dbo.Perfil");
            //DropForeignKey("dbo.Usuario", "PlantaId", "dbo.Planta");
            //DropForeignKey("dbo.Permiso", "MenuId", "dbo.Menu");
            //DropForeignKey("dbo.Permiso", "PerfilId", "dbo.Perfil");
            //DropForeignKey("dbo.PerfilMenu", "MenuId", "dbo.Menu");
            //DropForeignKey("dbo.PerfilMenu", "PerfilId", "dbo.Perfil");
            //DropForeignKey("dbo.Silo", "PlantaId", "dbo.Planta");
            //DropForeignKey("dbo.Prueba", "TipoPruebaId", "dbo.TipoPrueba");
            //DropForeignKey("dbo.NormaEnsayoValorMm", "MedidaDiametroId", "dbo.MedidaDiametro");
            //DropForeignKey("dbo.NormaEnsayoValorMm", "NormaEnsayoId", "dbo.NormaEnsayo");
            //DropForeignKey("dbo.NormaEnsayoValorIn", "NormaEnsayoId", "dbo.NormaEnsayo");
            //DropForeignKey("dbo.NormaEnsayoValorIn", "MedidaDiametroId", "dbo.MedidaDiametro");
            //DropForeignKey("dbo.NormaEnsayo", "UnidadMedidaId", "dbo.UnidadMedida");
            //DropForeignKey("dbo.NormaEnsayo", "NormaProductoId", "dbo.NormaProducto");
            //DropForeignKey("dbo.NormaEnsayo", "TipoEnsayoId", "dbo.TipoEnsayo");
            //DropForeignKey("dbo.Producto", "ProveedorId", "dbo.Proveedor");
            //DropForeignKey("dbo.Producto", "TipoProductoId", "dbo.TipoProducto");
            //DropForeignKey("dbo.Producto", "MedidaDiametroId", "dbo.MedidaDiametro");
            //DropForeignKey("dbo.Norma", "NormaProductoId", "dbo.NormaProducto");
            //DropForeignKey("dbo.Norma", "ProductoId", "dbo.Producto");
            //DropForeignKey("dbo.Linea", "PlantaId", "dbo.Planta");
            //DropForeignKey("dbo.Calibracion", "ProveedorId", "dbo.Proveedor");
            //DropForeignKey("dbo.Calibracion", "EquipoId", "dbo.Equipo");
            //DropTable("dbo.Usuario");
            //DropTable("dbo.Permiso");
            //DropTable("dbo.PerfilMenu");
            //DropTable("dbo.Perfil");
            //DropTable("dbo.Menu");
            //DropTable("dbo.Silo");
            //DropTable("dbo.TipoPrueba");
            //DropTable("dbo.Prueba");
            //DropTable("dbo.NormaEnsayoValorMm");
            //DropTable("dbo.NormaEnsayoValorIn");
            //DropTable("dbo.UnidadMedida");
            //DropTable("dbo.TipoEnsayo");
            //DropTable("dbo.NormaEnsayo");
            //DropTable("dbo.NormaProducto");
            //DropTable("dbo.TipoProducto");
            //DropTable("dbo.MedidaDiametro");
            //DropTable("dbo.Producto");
            //DropTable("dbo.Norma");
            //DropTable("dbo.Planta");
            //DropTable("dbo.Linea");
            //DropTable("dbo.Proveedor");
            //DropTable("dbo.Equipo");
            //DropTable("dbo.Calibracion");
            //DropTable("dbo.Person");
        }
    }
}
