namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUnidadMedida : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnidadMedida", "SimboloUM", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UnidadMedida", "SimboloUM");
        }
    }
}
