namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lote", "ProductoId", "dbo.Producto");
            DropIndex("dbo.Lote", new[] { "ProductoId" });
            AlterColumn("dbo.Lote", "ProductoId", c => c.Long());
            AddForeignKey("dbo.Lote", "ProductoId", "dbo.Producto", "Id");
            CreateIndex("dbo.Lote", "ProductoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Lote", new[] { "ProductoId" });
            DropForeignKey("dbo.Lote", "ProductoId", "dbo.Producto");
            AlterColumn("dbo.Lote", "ProductoId", c => c.Long(nullable: false));
            CreateIndex("dbo.Lote", "ProductoId");
            AddForeignKey("dbo.Lote", "ProductoId", "dbo.Producto", "Id", cascadeDelete: true);
        }
    }
}
