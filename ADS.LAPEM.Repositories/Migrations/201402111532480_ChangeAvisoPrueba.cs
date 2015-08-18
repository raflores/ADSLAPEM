namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAvisoPrueba : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.AvisoPrueba", "LoteId", "dbo.Lote", "Id", cascadeDelete: true);
            CreateIndex("dbo.AvisoPrueba", "LoteId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AvisoPrueba", new[] { "LoteId" });
            DropForeignKey("dbo.AvisoPrueba", "LoteId", "dbo.Lote");
        }
    }
}
