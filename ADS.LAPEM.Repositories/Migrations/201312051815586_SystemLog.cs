namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemLog",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UsuarioId = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Modulo = c.String(),
                        Accion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SystemLog");
        }
    }
}
