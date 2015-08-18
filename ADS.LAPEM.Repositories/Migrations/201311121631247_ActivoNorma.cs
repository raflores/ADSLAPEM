namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivoNorma : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Norma", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Norma", "Activo");
        }
    }
}
