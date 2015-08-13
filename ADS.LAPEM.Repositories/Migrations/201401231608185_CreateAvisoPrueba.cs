namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAvisoPrueba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvisoPrueba",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NoProveedor = c.Int(nullable: false),
                        FamiliaId = c.String(),
                        UnidadId = c.String(),
                        Pedido = c.String(),
                        Partida = c.Int(nullable: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Costo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Moneda = c.String(),
                        Iva = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Destino = c.String(),
                        Observaciones = c.String(),
                        ProductoId = c.Long(nullable: false),
                        DescProducto = c.String(),
                        TipoAviso = c.String(),
                        PruebaId = c.Long(nullable: false),
                        LoteId = c.Long(nullable: false),
                        NumAviso = c.Long(nullable: false),
                        XmlAviso = c.String(),
                        XmlSerie = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AvisoPrueba");
        }
    }
}
