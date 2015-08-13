namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNormaEnsayo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NormaEnsayoValorIn", "Muestra", c => c.Long(nullable: false));
            AddColumn("dbo.NormaEnsayoValorMm", "Muestra", c => c.Long(nullable: false));
            DropColumn("dbo.NormaProducto", "CantidadMuestra");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NormaProducto", "CantidadMuestra", c => c.Int(nullable: false));
            DropColumn("dbo.NormaEnsayoValorMm", "Muestra");
            DropColumn("dbo.NormaEnsayoValorIn", "Muestra");
        }
    }
}
