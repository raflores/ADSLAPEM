namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivoEntidades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proveedor", "Activo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Linea", "Activo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Planta", "Activo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Producto", "Activo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Silo", "Activo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Perfil", "Activo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuario", "Activo", c => c.Boolean(nullable: false));
            DropColumn("dbo.Planta", "Estatus");
            DropColumn("dbo.Usuario", "Estatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "Estatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Planta", "Estatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Usuario", "Activo");
            DropColumn("dbo.Perfil", "Activo");
            DropColumn("dbo.Silo", "Activo");
            DropColumn("dbo.Producto", "Activo");
            DropColumn("dbo.Planta", "Activo");
            DropColumn("dbo.Linea", "Activo");
            DropColumn("dbo.Proveedor", "Activo");
        }
    }
}
