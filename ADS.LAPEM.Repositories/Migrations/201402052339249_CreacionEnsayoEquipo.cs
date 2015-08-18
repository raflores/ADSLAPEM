namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionEnsayoEquipo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnsayoEquipo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EnsayoId = c.Long(nullable: false),
                        EquipoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ensayo", t => t.EnsayoId, cascadeDelete: true)
                .ForeignKey("dbo.Equipo", t => t.EquipoId, cascadeDelete: true)
                .Index(t => t.EnsayoId)
                .Index(t => t.EquipoId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.EnsayoEquipo", new[] { "EquipoId" });
            DropIndex("dbo.EnsayoEquipo", new[] { "EnsayoId" });
            DropForeignKey("dbo.EnsayoEquipo", "EquipoId", "dbo.Equipo");
            DropForeignKey("dbo.EnsayoEquipo", "EnsayoId", "dbo.Ensayo");
            DropTable("dbo.EnsayoEquipo");
        }
    }
}
