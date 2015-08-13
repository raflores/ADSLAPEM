namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeResultado5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resultado", "NormaEnsayoId", "dbo.NormaEnsayo");
            DropIndex("dbo.Resultado", new[] { "NormaEnsayoId" });
            AddColumn("dbo.Resultado", "NormaID", c => c.Long(nullable: false));
            AddForeignKey("dbo.Resultado", "NormaID", "dbo.Norma", "Id", cascadeDelete: true);
            CreateIndex("dbo.Resultado", "NormaID");
            DropColumn("dbo.Resultado", "NormaEnsayoId");
            DropColumn("dbo.ResultadoDetalle", "NormaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ResultadoDetalle", "NormaId", c => c.Long(nullable: false));
            AddColumn("dbo.Resultado", "NormaEnsayoId", c => c.Long(nullable: false));
            DropIndex("dbo.Resultado", new[] { "NormaID" });
            DropForeignKey("dbo.Resultado", "NormaID", "dbo.Norma");
            DropColumn("dbo.Resultado", "NormaID");
            CreateIndex("dbo.Resultado", "NormaEnsayoId");
            AddForeignKey("dbo.Resultado", "NormaEnsayoId", "dbo.NormaEnsayo", "Id", cascadeDelete: true);
        }
    }
}
