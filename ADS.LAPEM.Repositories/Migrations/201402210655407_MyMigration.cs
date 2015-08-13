namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resultado", "Observaciones", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resultado", "Observaciones");
        }
    }
}
