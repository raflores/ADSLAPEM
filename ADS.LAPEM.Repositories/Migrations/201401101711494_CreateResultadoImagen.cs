namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateResultadoDetalle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResultadoDetalle",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ResultadoId = c.Long(nullable: false),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResultadoDetalle");
        }
    }
}
