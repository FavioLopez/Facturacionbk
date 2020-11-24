using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentasComputadora.Core.Entities;

namespace VentasComputadora.Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Producto> ProductoRepository { get; }
        IRepository<Categoria> CategoriaRepository { get; }
        IRepository<Cliente> ClienteRepository { get; }
        IRepository<Venta> VentaRepository { get; }
        IRepository<DetalleVenta> DetalleVentaRepository { get; }
        IRepository<Usuario> UsuarioRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
