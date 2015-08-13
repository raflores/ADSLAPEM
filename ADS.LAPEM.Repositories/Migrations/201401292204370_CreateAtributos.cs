namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAtributos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atributo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AtributoEval = c.String(),
                        NombreAtributo = c.String(),
                        TipoDato = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AtributoLote",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LoteId = c.Long(nullable: false),
                        AtributoId = c.Long(nullable: false),
                        Valor = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lote", t => t.LoteId, cascadeDelete: true)
                .ForeignKey("dbo.Atributo", t => t.AtributoId, cascadeDelete: true)
                .Index(t => t.LoteId)
                .Index(t => t.AtributoId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AtributoLote", new[] { "AtributoId" });
            DropIndex("dbo.AtributoLote", new[] { "LoteId" });
            DropForeignKey("dbo.AtributoLote", "AtributoId", "dbo.Atributo");
            DropForeignKey("dbo.AtributoLote", "LoteId", "dbo.Lote");
            DropTable("dbo.AtributoLote");
            DropTable("dbo.Atributo");
        }
    }
}
