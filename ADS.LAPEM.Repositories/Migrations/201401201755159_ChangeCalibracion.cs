namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCalibracion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calibracion", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calibracion", "Activo");
        }
    }
}
