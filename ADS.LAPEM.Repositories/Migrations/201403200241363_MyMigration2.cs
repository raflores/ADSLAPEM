namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Color", "Codigo", c => c.String(nullable: false, maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Color", "Codigo", c => c.String(maxLength: 3));
        }
    }
}
