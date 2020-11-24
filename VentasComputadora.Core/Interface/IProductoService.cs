using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentasComputadora.Core.Entities;

namespace VentasComputadora.Core.Interface
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetProductos();

        Task<Producto> GetProducto(int id);

        IEnumerable<Producto> GetNombreProductos(string nombre);

        Task PostProducto(Producto o);

        Task<bool> PutProducto(Producto o);

        Task<bool> DeleteProducto(int id);
    }
}
