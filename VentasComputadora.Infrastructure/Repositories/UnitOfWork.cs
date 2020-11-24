using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentasComputadora.Core.Entities;
using VentasComputadora.Core.Interface;
using VentasComputadora.Infrastructure.Data;

namespace VentasComputadora.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository<Producto> _productoRepository;
        private readonly IRepository<Categoria> _categoriaRepository;
        private readonly IRepository<Cliente> _clienteRepository;
        private readonly IRepository<Venta> _ventaRepository;
        private readonly IRepository<DetalleVenta> _detalleVentaRepository;
        private readonly IRepository<Usuario> _usuarioRepository;

        private readonly VentaComputadorasContext _context;

        public UnitOfWork(VentaComputadorasContext context)
        {
            this._context = context;    
        }

        public IRepository<Producto> ProductoRepository => _productoRepository ?? new BaseRepository<Producto>(_context);

        public IRepository<Categoria> CategoriaRepository => _categoriaRepository ?? new BaseRepository<Categoria>(_context);

        public IRepository<Cliente> ClienteRepository => _clienteRepository ?? new BaseRepository<Cliente>(_context);

        public IRepository<Venta> VentaRepository => _ventaRepository ?? new BaseRepository<Venta>(_context);

        public IRepository<DetalleVenta> DetalleVentaRepository => _detalleVentaRepository ?? new BaseRepository<DetalleVenta>(_context);

        public IRepository<Usuario> UsuarioRepository => _usuarioRepository ?? new BaseRepository<Usuario>(_context);

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
