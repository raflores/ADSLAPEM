namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEnsayo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resultado", "EnsayoId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Resultado", "EnsayoId", "dbo.Ensayo", "Id", cascadeDelete: true);
            CreateIndex("dbo.Resultado", "EnsayoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Resultado", new[] { "EnsayoId" });
            DropForeignKey("dbo.Resultado", "EnsayoId", "dbo.Ensayo");
            DropColumn("dbo.Resultado", "EnsayoId");
        }
    }
}
