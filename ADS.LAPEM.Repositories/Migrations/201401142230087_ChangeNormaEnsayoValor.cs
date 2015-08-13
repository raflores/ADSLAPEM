namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNormaEnsayoValor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NormaEnsayoValorIn", "UnidadMedidaId", c => c.Long(nullable: false));
            AddColumn("dbo.NormaEnsayoValorMm", "UnidadMedidaId", c => c.Long(nullable: false));
            AddForeignKey("dbo.NormaEnsayoValorIn", "UnidadMedidaId", "dbo.UnidadMedida", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NormaEnsayoValorMm", "UnidadMedidaId", "dbo.UnidadMedida", "Id", cascadeDelete: true);
            CreateIndex("dbo.NormaEnsayoValorIn", "UnidadMedidaId");
            CreateIndex("dbo.NormaEnsayoValorMm", "UnidadMedidaId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.NormaEnsayoValorMm", new[] { "UnidadMedidaId" });
            DropIndex("dbo.NormaEnsayoValorIn", new[] { "UnidadMedidaId" });
            DropForeignKey("dbo.NormaEnsayoValorMm", "UnidadMedidaId", "dbo.UnidadMedida");
            DropForeignKey("dbo.NormaEnsayoValorIn", "UnidadMedidaId", "dbo.UnidadMedida");
            DropColumn("dbo.NormaEnsayoValorMm", "UnidadMedidaId");
            DropColumn("dbo.NormaEnsayoValorIn", "UnidadMedidaId");
        }
    }
}
