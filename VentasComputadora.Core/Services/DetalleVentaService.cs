using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentasComputadora.Core.Entities;
using VentasComputadora.Core.Interface;

namespace VentasComputadora.Core.Services
{
    public class DetalleVentaService : IDetalleVentaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetalleVentaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task PostDetalleVenta(DetalleVenta o)
        {
            var oProducto = await this._unitOfWork.ProductoRepository.GetById(o.ProductoId);
            await this._unitOfWork.DetalleVentaRepository.Add(o);
            

            oProducto.Stock = oProducto.Stock - o.Cantidad;
            this._unitOfWork.ProductoRepository.Update(oProducto);
            await this._unitOfWork.SaveChangesAsync();


        }
    }
}
