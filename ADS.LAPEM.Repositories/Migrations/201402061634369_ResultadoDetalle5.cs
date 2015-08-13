namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResultadoDetalle5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ResultadoDetalle", "EquipoId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ResultadoDetalle", "EquipoId", c => c.Long(nullable: false));
        }
    }
}
