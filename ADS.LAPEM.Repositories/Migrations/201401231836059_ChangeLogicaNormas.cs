namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLogicaNormas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NormaEnsayo", "TipoEnsayoId", "dbo.TipoEnsayo");
            DropForeignKey("dbo.NormaEnsayo", "NormaId", "dbo.Norma");
            DropIndex("dbo.NormaEnsayo", new[] { "TipoEnsayoId" });
            DropIndex("dbo.NormaEnsayo", new[] { "NormaId" });
            CreateTable(
                "dbo.Especificacion",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NormaId = c.Long(nullable: false),
                        NormaEnsayoId = c.Long(nullable: false),
                        TipoEnsayoId = c.Long(nullable: false),
                        Minimo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Maximo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Objetivo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Muestra = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Norma", t => t.NormaId, cascadeDelete: true)
                .ForeignKey("dbo.NormaEnsayo", t => t.NormaEnsayoId, cascadeDelete: true)
                .ForeignKey("dbo.TipoEnsayo", t => t.TipoEnsayoId, cascadeDelete: true)
                .Index(t => t.NormaId)
                .Index(t => t.NormaEnsayoId)
                .Index(t => t.TipoEnsayoId);
            
            DropColumn("dbo.NormaEnsayo", "TipoEnsayoId");
            DropColumn("dbo.NormaEnsayo", "NormaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NormaEnsayo", "NormaId", c => c.Long(nullable: false));
            AddColumn("dbo.NormaEnsayo", "TipoEnsayoId", c => c.Long(nullable: false));
            DropIndex("dbo.Especificacion", new[] { "TipoEnsayoId" });
            DropIndex("dbo.Especificacion", new[] { "NormaEnsayoId" });
            DropIndex("dbo.Especificacion", new[] { "NormaId" });
            DropForeignKey("dbo.Especificacion", "TipoEnsayoId", "dbo.TipoEnsayo");
            DropForeignKey("dbo.Especificacion", "NormaEnsayoId", "dbo.NormaEnsayo");
            DropForeignKey("dbo.Especificacion", "NormaId", "dbo.Norma");
            DropTable("dbo.Especificacion");
            CreateIndex("dbo.NormaEnsayo", "NormaId");
            CreateIndex("dbo.NormaEnsayo", "TipoEnsayoId");
            AddForeignKey("dbo.NormaEnsayo", "NormaId", "dbo.Norma", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NormaEnsayo", "TipoEnsayoId", "dbo.TipoEnsayo", "Id", cascadeDelete: true);
        }
    }
}
