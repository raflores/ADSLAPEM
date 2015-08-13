namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMenu2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "Padre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menu", "Padre");
        }
    }
}
