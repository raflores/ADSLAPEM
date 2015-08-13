namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAtributoDetalle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AtributoDetalle",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ResultadoDetalleId = c.Long(nullable: false),
                        AtributoId = c.Long(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Atributo", t => t.AtributoId, cascadeDelete: true)
                .ForeignKey("dbo.ResultadoDetalle", t => t.ResultadoDetalleId, cascadeDelete: true)
                .Index(t => t.AtributoId)
                .Index(t => t.ResultadoDetalleId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AtributoDetalle", new[] { "ResultadoDetalleId" });
            DropIndex("dbo.AtributoDetalle", new[] { "AtributoId" });
            DropForeignKey("dbo.AtributoDetalle", "ResultadoDetalleId", "dbo.ResultadoDetalle");
            DropForeignKey("dbo.AtributoDetalle", "AtributoId", "dbo.Atributo");
            DropTable("dbo.AtributoDetalle");
        }
    }
}
