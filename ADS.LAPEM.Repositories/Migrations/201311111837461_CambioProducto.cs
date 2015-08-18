namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioProducto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producto", "Codigo", c => c.String(nullable: false));
            AddColumn("dbo.Producto", "MedidaDiametroId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Producto", "MedidaDiametroId", "dbo.MedidaDiametro", "Id", cascadeDelete: true);
            CreateIndex("dbo.Producto", "MedidaDiametroId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Producto", new[] { "MedidaDiametroId" });
            DropForeignKey("dbo.Producto", "MedidaDiametroId", "dbo.MedidaDiametro");
            DropColumn("dbo.Producto", "MedidaDiametroId");
            DropColumn("dbo.Producto", "Codigo");
        }
    }
}
