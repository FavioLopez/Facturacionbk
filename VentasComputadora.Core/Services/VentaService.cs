using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentasComputadora.Core.Entities;
using VentasComputadora.Core.Interface;

namespace VentasComputadora.Core.Services
{
    public class VentaService : IVentaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VentaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task PostVenta(Venta o)
        {
            await this._unitOfWork.VentaRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }
    }
}
