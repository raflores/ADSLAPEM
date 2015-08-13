namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeResultadoDetalle4 : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.ResultadoDetalle", "ResultadoId", "dbo.Resultado", "Id", cascadeDelete: true);
            CreateIndex("dbo.ResultadoDetalle", "ResultadoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ResultadoDetalle", new[] { "ResultadoId" });
            DropForeignKey("dbo.ResultadoDetalle", "ResultadoId", "dbo.Resultado");
        }
    }
}
