namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEnsayoEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ensayo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Especificacion", "EnsayoId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Especificacion", "EnsayoId", "dbo.Ensayo", "Id", cascadeDelete: true);
            CreateIndex("dbo.Especificacion", "EnsayoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Especificacion", new[] { "EnsayoId" });
            DropForeignKey("dbo.Especificacion", "EnsayoId", "dbo.Ensayo");
            DropColumn("dbo.Especificacion", "EnsayoId");
            DropTable("dbo.Ensayo");
        }
    }
}
