namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionValidacionesEntities : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Turno", "NombreTurno", c => c.String(nullable: false));
            AlterColumn("dbo.Silo", "Descripcion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Silo", "Descripcion", c => c.String());
            AlterColumn("dbo.Turno", "NombreTurno", c => c.String());
        }
    }
}
