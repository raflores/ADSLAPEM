namespace ADS.LAPEM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNormasEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Norma", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.Norma", "NormaProductoId", "dbo.NormaProducto");
            DropForeignKey("dbo.NormaEnsayo", "NormaProductoId", "dbo.NormaProducto");
            DropForeignKey("dbo.NormaEnsayo", "UnidadMedidaId", "dbo.UnidadMedida");
            DropIndex("dbo.Norma", new[] { "ProductoId" });
            DropIndex("dbo.Norma", new[] { "NormaProductoId" });
            DropIndex("dbo.NormaEnsayo", new[] { "NormaProductoId" });
            DropIndex("dbo.NormaEnsayo", new[] { "UnidadMedidaId" });
            AddColumn("dbo.Norma", "Nombre", c => c.String());
            AddColumn("dbo.Norma", "Descripcion", c => c.String());
            AddColumn("dbo.Norma", "Producto_Id", c => c.Long());
            AddColumn("dbo.NormaProducto", "NormaEnsayoId", c => c.Long(nullable: false));
            AddColumn("dbo.NormaProducto", "ProductoId", c => c.Long(nullable: false));
            AddColumn("dbo.NormaEnsayo", "NormaId", c => c.Long(nullable: false));
            AddForeignKey("dbo.Norma", "Producto_Id", "dbo.Producto", "Id");
            AddForeignKey("dbo.NormaEnsayo", "NormaId", "dbo.Norma", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NormaProducto", "NormaEnsayoId", "dbo.NormaEnsayo", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NormaProducto", "ProductoId", "dbo.Producto", "Id", cascadeDelete: true);
            CreateIndex("dbo.Norma", "Producto_Id");
            CreateIndex("dbo.NormaEnsayo", "NormaId");
            CreateIndex("dbo.NormaProducto", "NormaEnsayoId");
            CreateIndex("dbo.NormaProducto", "ProductoId");
            DropColumn("dbo.Norma", "NormaProductoId");
            DropColumn("dbo.Norma", "ProductoId");
            DropColumn("dbo.NormaEnsayo", "NormaProductoId");
            DropColumn("dbo.NormaEnsayo", "UnidadMedidaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NormaEnsayo", "UnidadMedidaId", c => c.Long(nullable: false));
            AddColumn("dbo.NormaEnsayo", "NormaProductoId", c => c.Long(nullable: false));
            AddColumn("dbo.Norma", "ProductoId", c => c.Long());
            AddColumn("dbo.Norma", "NormaProductoId", c => c.Long(nullable: false));
            DropIndex("dbo.NormaProducto", new[] { "ProductoId" });
            DropIndex("dbo.NormaProducto", new[] { "NormaEnsayoId" });
            DropIndex("dbo.NormaEnsayo", new[] { "NormaId" });
            DropIndex("dbo.Norma", new[] { "Producto_Id" });
            DropForeignKey("dbo.NormaProducto", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.NormaProducto", "NormaEnsayoId", "dbo.NormaEnsayo");
            DropForeignKey("dbo.NormaEnsayo", "NormaId", "dbo.Norma");
            DropForeignKey("dbo.Norma", "Producto_Id", "dbo.Producto");
            DropColumn("dbo.NormaEnsayo", "NormaId");
            DropColumn("dbo.NormaProducto", "ProductoId");
            DropColumn("dbo.NormaProducto", "NormaEnsayoId");
            DropColumn("dbo.Norma", "Producto_Id");
            DropColumn("dbo.Norma", "Descripcion");
            DropColumn("dbo.Norma", "Nombre");
            CreateIndex("dbo.NormaEnsayo", "UnidadMedidaId");
            CreateIndex("dbo.NormaEnsayo", "NormaProductoId");
            CreateIndex("dbo.Norma", "NormaProductoId");
            CreateIndex("dbo.Norma", "ProductoId");
            AddForeignKey("dbo.NormaEnsayo", "UnidadMedidaId", "dbo.UnidadMedida", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NormaEnsayo", "NormaProductoId", "dbo.NormaProducto", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Norma", "NormaProductoId", "dbo.NormaProducto", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Norma", "ProductoId", "dbo.Producto", "Id");
        }
    }
}
