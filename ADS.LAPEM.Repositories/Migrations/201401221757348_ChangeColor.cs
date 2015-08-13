namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Color", "Tipo", c => c.String());
            AddColumn("dbo.Color", "Codigo", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Color", "Codigo");
            DropColumn("dbo.Color", "Tipo");
        }
    }
}
