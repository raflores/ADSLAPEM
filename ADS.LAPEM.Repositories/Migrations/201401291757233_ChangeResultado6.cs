namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeResultado6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resultado", "NormaEnsayoId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Resultado", "NormaEnsayoId", "dbo.NormaEnsayo", "Id", cascadeDelete: true);
            CreateIndex("dbo.Resultado", "NormaEnsayoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Resultado", new[] { "NormaEnsayoId" });
            DropForeignKey("dbo.Resultado", "NormaEnsayoId", "dbo.NormaEnsayo");
            DropColumn("dbo.Resultado", "NormaEnsayoId");
        }
    }
}
