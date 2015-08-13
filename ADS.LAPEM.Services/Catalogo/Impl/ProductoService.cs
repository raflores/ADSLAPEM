using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Repositories.Catalogo;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Catalogo.Impl
{
    public class ProductoService : IProductoService
    {
        protected IProductoRepository ProductoRepository { get; set; }
        protected INormaRepository NormaRepository { get; set; }

        public IEnumerable<Producto> ReadProducto()
        {
            return ProductoRepository.ReadProducto();
        }

        public GridResult<Producto> ReadProducto(GridSettings grid)
        {
            return ProductoRepository.ReadProducto(grid);
        }

        public Producto ReadProductoById(long id)
        {
            return ProductoRepository.ReadProductoById(id);
        }

        public void CreateProducto(Producto producto)
        {            
            ProductoRepository.CreateProducto(producto);
        }

        public void UpdateProducto(Producto producto)
        {            
            Producto db = ProductoRepository.ReadProductoById(producto.Id);
            db.Codigo = producto.Codigo;
            db.Descripcion = producto.Descripcion;
            db.MedidaDiametroId = producto.MedidaDiametroId;
            db.Nombre = producto.Nombre;
            db.ProveedorId = producto.ProveedorId;
            db.TipoProductoId = producto.TipoProductoId;            

            //db.Norma.ToList().ForEach(x =>  {
            //    producto.Norma.ToList().ForEach(y =>
            //    {
            //        if (x.Id == y.Id)
            //            x.Prueba = y.Prueba;
            //    });                
            //});            

            ProductoRepository.UpdateProducto(db);
        }

        public void DeleteProducto(Producto producto)
        {
            ProductoRepository.DeleteProducto(producto);
        }
    }
}
