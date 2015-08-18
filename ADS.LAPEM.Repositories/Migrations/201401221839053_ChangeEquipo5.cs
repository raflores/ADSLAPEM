namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEquipo5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipo", "CodigoActivoFijo", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipo", "CodigoActivoFijo");
        }
    }
}
