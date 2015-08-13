namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lote", "FechaProduccion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lote", "CantidadProducida", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Lote", "SaldoLaboratorio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Lote", "Fecha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lote", "Fecha", c => c.DateTime(nullable: false));
            DropColumn("dbo.Lote", "SaldoLaboratorio");
            DropColumn("dbo.Lote", "CantidadProducida");
            DropColumn("dbo.Lote", "FechaProduccion");
        }
    }
}
