namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileContentCalibracion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calibracion", "FileContent", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calibracion", "FileContent");
        }
    }
}
