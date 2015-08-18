namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeResultadoDetalle3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resultado", "NormaVMax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Resultado", "NormaVMin", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ResultadoDetalle", "NormaVMax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ResultadoDetalle", "NormaVMin", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ResultadoDetalle", "NormaVMin", c => c.Long(nullable: false));
            AlterColumn("dbo.ResultadoDetalle", "NormaVMax", c => c.Long(nullable: false));
            AlterColumn("dbo.Resultado", "NormaVMin", c => c.Long(nullable: false));
            AlterColumn("dbo.Resultado", "NormaVMax", c => c.Long(nullable: false));
        }
    }
}
