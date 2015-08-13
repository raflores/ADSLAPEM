namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeResultado3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resultado", "NormaId", "dbo.Norma");
            DropIndex("dbo.Resultado", new[] { "NormaId" });
            AddColumn("dbo.Resultado", "NormaEnsayoId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Resultado", "NormaEnsayoId", "dbo.NormaEnsayo", "Id", cascadeDelete: true);
            CreateIndex("dbo.Resultado", "NormaEnsayoId");
            DropColumn("dbo.Resultado", "MuestraNum");
            DropColumn("dbo.Resultado", "NormaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resultado", "NormaId", c => c.Long(nullable: false));
            AddColumn("dbo.Resultado", "MuestraNum", c => c.Long(nullable: false));
            DropIndex("dbo.Resultado", new[] { "NormaEnsayoId" });
            DropForeignKey("dbo.Resultado", "NormaEnsayoId", "dbo.NormaEnsayo");
            DropColumn("dbo.Resultado", "NormaEnsayoId");
            CreateIndex("dbo.Resultado", "NormaId");
            AddForeignKey("dbo.Resultado", "NormaId", "dbo.Norma", "Id", cascadeDelete: true);
        }
    }
}
