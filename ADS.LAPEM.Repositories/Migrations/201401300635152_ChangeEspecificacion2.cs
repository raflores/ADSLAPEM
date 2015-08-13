namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEspecificacion2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Especificacion", "UnidadMedidaId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Especificacion", "UnidadMedidaId", "dbo.UnidadMedida", "Id", cascadeDelete: true);
            CreateIndex("dbo.Especificacion", "UnidadMedidaId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Especificacion", new[] { "UnidadMedidaId" });
            DropForeignKey("dbo.Especificacion", "UnidadMedidaId", "dbo.UnidadMedida");
            DropColumn("dbo.Especificacion", "UnidadMedidaId");
        }
    }
}
