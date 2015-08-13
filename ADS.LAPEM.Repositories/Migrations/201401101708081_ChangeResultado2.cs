namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeResultado2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resultado", "ResultadoValor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Resultado", "NormaRev");
            DropColumn("dbo.Resultado", "PruebaLote");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resultado", "PruebaLote", c => c.Long(nullable: false));
            AddColumn("dbo.Resultado", "NormaRev", c => c.Long(nullable: false));
            AlterColumn("dbo.Resultado", "ResultadoValor", c => c.Long(nullable: false));
        }
    }
}
