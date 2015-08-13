namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEspecificacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Especificacion", "ProductoId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Especificacion", "ProductoId", "dbo.Producto", "Id", cascadeDelete: true);
            CreateIndex("dbo.Especificacion", "ProductoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Especificacion", new[] { "ProductoId" });
            DropForeignKey("dbo.Especificacion", "ProductoId", "dbo.Producto");
            DropColumn("dbo.Especificacion", "ProductoId");
        }
    }
}
