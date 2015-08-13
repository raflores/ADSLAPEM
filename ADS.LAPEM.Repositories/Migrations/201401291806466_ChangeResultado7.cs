namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeResultado7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resultado", "UnidadMedidaId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Resultado", "UnidadMedidaId", "dbo.UnidadMedida", "Id", cascadeDelete: true);
            CreateIndex("dbo.Resultado", "UnidadMedidaId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Resultado", new[] { "UnidadMedidaId" });
            DropForeignKey("dbo.Resultado", "UnidadMedidaId", "dbo.UnidadMedida");
            DropColumn("dbo.Resultado", "UnidadMedidaId");
        }
    }
}
