namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeResultadoDetalle2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResultadoDetalle",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ResultadoId = c.Long(nullable: false),
                        FechaPrueba = c.DateTime(nullable: false),
                        EquipoId = c.Long(nullable: false),
                        MuestraNum = c.Long(nullable: false),
                        NormaId = c.Long(nullable: false),
                        NormaUM = c.String(),
                        NormaVMax = c.Long(nullable: false),
                        NormaVMin = c.Long(nullable: false),
                        ResultadoDetalleValor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UsuarioId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResultadoDetalle");
        }
    }
}
