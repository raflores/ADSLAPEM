namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEquipo4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Equipo", "CodigoActivoFijo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipo", "CodigoActivoFijo", c => c.Int(nullable: false));
        }
    }
}
