namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEquipo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipo", "PlantaId", c => c.Long(nullable: false));
            AddColumn("dbo.Planta", "Equipo_Id", c => c.Long());
            AddForeignKey("dbo.Planta", "Equipo_Id", "dbo.Equipo", "Id");
            CreateIndex("dbo.Planta", "Equipo_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Planta", new[] { "Equipo_Id" });
            DropForeignKey("dbo.Planta", "Equipo_Id", "dbo.Equipo");
            DropColumn("dbo.Planta", "Equipo_Id");
            DropColumn("dbo.Equipo", "PlantaId");
        }
    }
}
