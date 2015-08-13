namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "Action", c => c.String());
            AddColumn("dbo.Menu", "Controller", c => c.String());
            AddColumn("dbo.Menu", "Area", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menu", "Area");
            DropColumn("dbo.Menu", "Controller");
            DropColumn("dbo.Menu", "Action");
        }
    }
}
