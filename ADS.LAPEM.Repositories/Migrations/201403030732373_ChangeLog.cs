namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLog : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.SystemLog", "UsuarioId", "dbo.Usuario", "Id", cascadeDelete: true);
            CreateIndex("dbo.SystemLog", "UsuarioId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SystemLog", new[] { "UsuarioId" });
            DropForeignKey("dbo.SystemLog", "UsuarioId", "dbo.Usuario");
        }
    }
}
