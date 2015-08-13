namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reajuste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lote",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Identificador = c.String(),
                        ProductoId = c.Long(nullable: false),
                        PlantaId = c.Long(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producto", t => t.ProductoId, cascadeDelete: true)
                .ForeignKey("dbo.Planta", t => t.PlantaId, cascadeDelete: true)
                .Index(t => t.ProductoId)
                .Index(t => t.PlantaId);
            
            CreateTable(
                "dbo.Resultado",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Aprobado = c.Int(nullable: false),
                        LoteId = c.Long(nullable: false),
                        FechaPrueba = c.DateTime(nullable: false),
                        EquipoId = c.Int(nullable: false),
                        MuestraNum = c.Long(nullable: false),
                        NormaId = c.Long(nullable: false),
                        NormaMnxm = c.Long(nullable: false),
                        NormaRev = c.Long(nullable: false),
                        NormaUM = c.String(),
                        NormaVMax = c.Long(nullable: false),
                        NormaVMin = c.Long(nullable: false),
                        PruebaId = c.Long(nullable: false),
                        PruebaDesc = c.String(),
                        ProductoId = c.Long(nullable: false),
                        ProductoDesc = c.String(),
                        ResultadoValor = c.Long(nullable: false),
                        UsuarioId = c.Long(nullable: false),
                        PruebaLote = c.Long(nullable: false),
                        EnviadoLapem = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lote", t => t.LoteId, cascadeDelete: true)
                .Index(t => t.LoteId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Resultado", new[] { "LoteId" });
            DropIndex("dbo.Lote", new[] { "PlantaId" });
            DropIndex("dbo.Lote", new[] { "ProductoId" });
            DropForeignKey("dbo.Resultado", "LoteId", "dbo.Lote");
            DropForeignKey("dbo.Lote", "PlantaId", "dbo.Planta");
            DropForeignKey("dbo.Lote", "ProductoId", "dbo.Producto");
            DropTable("dbo.Resultado");
            DropTable("dbo.Lote");
        }
    }
}
