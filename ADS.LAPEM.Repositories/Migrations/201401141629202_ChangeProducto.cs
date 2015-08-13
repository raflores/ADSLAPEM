namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProducto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producto", "Longitud", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Producto", "ColorId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Producto", "ColorId", "dbo.Color", "Id", cascadeDelete: true);
            CreateIndex("dbo.Producto", "ColorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Producto", new[] { "ColorId" });
            DropForeignKey("dbo.Producto", "ColorId", "dbo.Color");
            DropColumn("dbo.Producto", "ColorId");
            DropColumn("dbo.Producto", "Longitud");
        }
    }
}
