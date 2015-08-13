namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeResultado : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resultado", "EquipoId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Resultado", "NormaId", "dbo.Norma", "Id", cascadeDelete: true);
            CreateIndex("dbo.Resultado", "NormaId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Resultado", new[] { "NormaId" });
            DropForeignKey("dbo.Resultado", "NormaId", "dbo.Norma");
            AlterColumn("dbo.Resultado", "EquipoId", c => c.Int(nullable: false));
        }
    }
}
