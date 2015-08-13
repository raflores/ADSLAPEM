namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Color", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Color", "Activo");
        }
    }
}
