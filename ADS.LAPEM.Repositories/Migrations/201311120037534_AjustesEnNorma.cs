namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustesEnNorma : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductoNorma", "Id", "dbo.NormaProducto");
            DropForeignKey("dbo.ProductoNorma", "ProductoId", "dbo.Producto");
            DropIndex("dbo.ProductoNorma", new[] { "Id" });
            DropIndex("dbo.ProductoNorma", new[] { "ProductoId" });
            CreateTable(
                "dbo.Norma",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NormaProductoId = c.Long(nullable: false),
                        ProductoId = c.Long(nullable: false),
                        Prueba = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producto", t => t.ProductoId, cascadeDelete: true)
                .ForeignKey("dbo.NormaProducto", t => t.NormaProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId)
                .Index(t => t.NormaProductoId);
            
            DropTable("dbo.ProductoNorma");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductoNorma",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ProductoId = c.Long(nullable: false),
                        Prueba = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.Norma", new[] { "NormaProductoId" });
            DropIndex("dbo.Norma", new[] { "ProductoId" });
            DropForeignKey("dbo.Norma", "NormaProductoId", "dbo.NormaProducto");
            DropForeignKey("dbo.Norma", "ProductoId", "dbo.Producto");
            DropTable("dbo.Norma");
            CreateIndex("dbo.ProductoNorma", "ProductoId");
            CreateIndex("dbo.ProductoNorma", "Id");
            AddForeignKey("dbo.ProductoNorma", "ProductoId", "dbo.Producto", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductoNorma", "Id", "dbo.NormaProducto", "Id");
        }
    }
}
