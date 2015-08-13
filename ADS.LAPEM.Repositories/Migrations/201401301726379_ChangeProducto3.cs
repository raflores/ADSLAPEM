namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProducto3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producto", "PresionRequerida", c => c.String());
            AddColumn("dbo.Producto", "VacioRequerido", c => c.String());
            AddColumn("dbo.Producto", "DistanciaApoyo", c => c.String());
            AddColumn("dbo.Producto", "Deflexion", c => c.String());
            AddColumn("dbo.Producto", "Tiempo", c => c.String());
            AddColumn("dbo.Producto", "Desalineamiento", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Producto", "Desalineamiento");
            DropColumn("dbo.Producto", "Tiempo");
            DropColumn("dbo.Producto", "Deflexion");
            DropColumn("dbo.Producto", "DistanciaApoyo");
            DropColumn("dbo.Producto", "VacioRequerido");
            DropColumn("dbo.Producto", "PresionRequerida");
        }
    }
}
