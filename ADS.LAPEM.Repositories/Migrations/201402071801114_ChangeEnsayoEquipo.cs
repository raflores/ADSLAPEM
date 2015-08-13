namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEnsayoEquipo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnsayoEquipo", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EnsayoEquipo", "Activo");
        }
    }
}
