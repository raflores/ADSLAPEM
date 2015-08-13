namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProducto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Producto", "Diametro");
            DropColumn("dbo.Producto", "MasaProyectil");
            DropColumn("dbo.Producto", "Acondicionamiento");
            DropColumn("dbo.Producto", "EnergiaRequerida");
            DropColumn("dbo.Producto", "TipoProyectil");
            DropColumn("dbo.Producto", "TemperaturaProm");
            DropColumn("dbo.Producto", "AlturaProyectil");
            DropColumn("dbo.Producto", "PresionRequerida");
            DropColumn("dbo.Producto", "VacioRequerido");
            DropColumn("dbo.Producto", "DistanciaApoyo");
            DropColumn("dbo.Producto", "Deflexion");
            DropColumn("dbo.Producto", "Tiempo");
            DropColumn("dbo.Producto", "Desalineamiento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producto", "Desalineamiento", c => c.String());
            AddColumn("dbo.Producto", "Tiempo", c => c.String());
            AddColumn("dbo.Producto", "Deflexion", c => c.String());
            AddColumn("dbo.Producto", "DistanciaApoyo", c => c.String());
            AddColumn("dbo.Producto", "VacioRequerido", c => c.String());
            AddColumn("dbo.Producto", "PresionRequerida", c => c.String());
            AddColumn("dbo.Producto", "AlturaProyectil", c => c.String());
            AddColumn("dbo.Producto", "TemperaturaProm", c => c.String());
            AddColumn("dbo.Producto", "TipoProyectil", c => c.String());
            AddColumn("dbo.Producto", "EnergiaRequerida", c => c.String());
            AddColumn("dbo.Producto", "Acondicionamiento", c => c.String());
            AddColumn("dbo.Producto", "MasaProyectil", c => c.String());
            AddColumn("dbo.Producto", "Diametro", c => c.String());
        }
    }
}
