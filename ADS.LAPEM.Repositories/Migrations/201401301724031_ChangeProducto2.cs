namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProducto2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producto", "Diametro", c => c.String());
            AddColumn("dbo.Producto", "MasaProyectil", c => c.String());
            AddColumn("dbo.Producto", "Acondicionamiento", c => c.String());
            AddColumn("dbo.Producto", "EnergiaRequerida", c => c.String());
            AddColumn("dbo.Producto", "TipoProyectil", c => c.String());
            AddColumn("dbo.Producto", "TemperaturaProm", c => c.String());
            AddColumn("dbo.Producto", "AlturaProyectil", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Producto", "AlturaProyectil");
            DropColumn("dbo.Producto", "TemperaturaProm");
            DropColumn("dbo.Producto", "TipoProyectil");
            DropColumn("dbo.Producto", "EnergiaRequerida");
            DropColumn("dbo.Producto", "Acondicionamiento");
            DropColumn("dbo.Producto", "MasaProyectil");
            DropColumn("dbo.Producto", "Diametro");
        }
    }
}
