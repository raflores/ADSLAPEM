namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionNorma : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductoNorma",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ProductoId = c.Long(nullable: false),
                        Prueba = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NormaProducto", t => t.Id)
                .ForeignKey("dbo.Producto", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.ProductoId);
            
            DropTable("dbo.Norma");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Norma",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NumNorma = c.String(nullable: false),
                        Ensayo = c.String(nullable: false),
                        DiametroTubo = c.String(nullable: false),
                        Descripcion = c.String(),
                        Minimo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Maximo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.ProductoNorma", new[] { "ProductoId" });
            DropIndex("dbo.ProductoNorma", new[] { "Id" });
            DropForeignKey("dbo.ProductoNorma", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.ProductoNorma", "Id", "dbo.NormaProducto");
            DropTable("dbo.ProductoNorma");
        }
    }
}
