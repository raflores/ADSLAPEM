namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLote4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lote", "FechaIngreso", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lote", "FechaLiberacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lote", "FechaSalida", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lote", "Aprobado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lote", "Aprobado");
            DropColumn("dbo.Lote", "FechaSalida");
            DropColumn("dbo.Lote", "FechaLiberacion");
            DropColumn("dbo.Lote", "FechaIngreso");
        }
    }
}
