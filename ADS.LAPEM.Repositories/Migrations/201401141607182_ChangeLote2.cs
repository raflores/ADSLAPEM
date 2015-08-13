namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLote2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lote", "TurnoId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Lote", "TurnoId", "dbo.Turno", "Id", cascadeDelete: true);
            CreateIndex("dbo.Lote", "TurnoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Lote", new[] { "TurnoId" });
            DropForeignKey("dbo.Lote", "TurnoId", "dbo.Turno");
            DropColumn("dbo.Lote", "TurnoId");
        }
    }
}
