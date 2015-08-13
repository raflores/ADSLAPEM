namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEquipo3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipo", "PlantaId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Equipo", "PlantaId", "dbo.Planta", "Id", cascadeDelete: true);
            CreateIndex("dbo.Equipo", "PlantaId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Equipo", new[] { "PlantaId" });
            DropForeignKey("dbo.Equipo", "PlantaId", "dbo.Planta");
            DropColumn("dbo.Equipo", "PlantaId");
        }
    }
}
