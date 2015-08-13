namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNorma : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Norma", "Producto_Id", "dbo.Producto");
            DropIndex("dbo.Norma", new[] { "Producto_Id" });
            DropColumn("dbo.Norma", "Producto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Norma", "Producto_Id", c => c.Long());
            CreateIndex("dbo.Norma", "Producto_Id");
            AddForeignKey("dbo.Norma", "Producto_Id", "dbo.Producto", "Id");
        }
    }
}
