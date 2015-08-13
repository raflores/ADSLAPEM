namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeResultado4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Resultado", "ProductoDesc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resultado", "ProductoDesc", c => c.String());
        }
    }
}
