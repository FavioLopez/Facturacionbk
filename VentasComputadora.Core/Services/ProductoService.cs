using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VentasComputadora.Core.Entities;
using VentasComputadora.Core.Interface;

namespace VentasComputadora.Core.Services
{
    public class ProductoService : IProductoService
    {
        //private readonly IRepository<Producto> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }       
        public IEnumerable<Producto> GetNombreProductos(string nombre)
        {
            return this._unitOfWork.ProductoRepository.GetByName(nombre);
        }

        public async Task<Producto> GetProducto(int id)
        {
            return await _unitOfWork.ProductoRepository.GetById(id);
        }

        public IEnumerable<Producto> GetProductos()
        {
            return this._unitOfWork.ProductoRepository.GetAll();
        }

        public async Task PostProducto(Producto o)
        {
            await this._unitOfWork.ProductoRepository.Add(o);
        }

        public async Task<bool> PutProducto(Producto o)
        {
            _unitOfWork.ProductoRepository.Update(o);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteProducto(int id)
        {
            await _unitOfWork.ProductoRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;

        }      
       
    }
}
