namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosRogelio2Dic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calibracion", "ProveedorId", c => c.Long(nullable: false));
            AddColumn("dbo.Equipo", "CodigoActivoFijo", c => c.Int(nullable: false));
            AddColumn("dbo.Planta", "IdPlantaInterno", c => c.Long(nullable: false));
            AddColumn("dbo.Proveedor", "NombreContacto", c => c.String());
            AddColumn("dbo.Proveedor", "TelContacto", c => c.String());
            AddForeignKey("dbo.Calibracion", "ProveedorId", "dbo.Proveedor", "Id", cascadeDelete: true);
            CreateIndex("dbo.Calibracion", "ProveedorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Calibracion", new[] { "ProveedorId" });
            DropForeignKey("dbo.Calibracion", "ProveedorId", "dbo.Proveedor");
            DropColumn("dbo.Proveedor", "TelContacto");
            DropColumn("dbo.Proveedor", "NombreContacto");
            DropColumn("dbo.Planta", "IdPlantaInterno");
            DropColumn("dbo.Equipo", "CodigoActivoFijo");
            DropColumn("dbo.Calibracion", "ProveedorId");
        }
    }
}
