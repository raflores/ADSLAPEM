namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAtributo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AtributoDetalle", "Valor", c => c.String());
            DropColumn("dbo.Atributo", "TipoDato");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Atributo", "TipoDato", c => c.String());
            AlterColumn("dbo.AtributoDetalle", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
