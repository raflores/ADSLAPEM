namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLote3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lote", "PlantaId", "dbo.Planta");
            DropIndex("dbo.Lote", new[] { "PlantaId" });
            AddColumn("dbo.Lote", "LineaId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Lote", "LineaId", "dbo.Linea", "Id", cascadeDelete: true);
            CreateIndex("dbo.Lote", "LineaId");
            DropColumn("dbo.Lote", "PlantaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lote", "PlantaId", c => c.Long(nullable: false));
            DropIndex("dbo.Lote", new[] { "LineaId" });
            DropForeignKey("dbo.Lote", "LineaId", "dbo.Linea");
            DropColumn("dbo.Lote", "LineaId");
            CreateIndex("dbo.Lote", "PlantaId");
            AddForeignKey("dbo.Lote", "PlantaId", "dbo.Planta", "Id", cascadeDelete: true);
        }
    }
}
