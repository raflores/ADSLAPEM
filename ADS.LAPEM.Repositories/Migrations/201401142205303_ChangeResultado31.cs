namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeResultado31 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Resultado", "NormaMnxm");
            DropColumn("dbo.Resultado", "PruebaId");
            DropColumn("dbo.Resultado", "PruebaDesc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resultado", "PruebaDesc", c => c.String());
            AddColumn("dbo.Resultado", "PruebaId", c => c.Long(nullable: false));
            AddColumn("dbo.Resultado", "NormaMnxm", c => c.Long(nullable: false));
        }
    }
}
