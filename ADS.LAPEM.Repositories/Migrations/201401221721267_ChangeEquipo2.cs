namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEquipo2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Planta", "Equipo_Id", "dbo.Equipo");
            DropIndex("dbo.Planta", new[] { "Equipo_Id" });
            DropColumn("dbo.Equipo", "PlantaId");
            DropColumn("dbo.Planta", "Equipo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Planta", "Equipo_Id", c => c.Long());
            AddColumn("dbo.Equipo", "PlantaId", c => c.Long(nullable: false));
            CreateIndex("dbo.Planta", "Equipo_Id");
            AddForeignKey("dbo.Planta", "Equipo_Id", "dbo.Equipo", "Id");
        }
    }
}
