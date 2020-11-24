using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentasComputadora.Core.Entities;

namespace VentasComputadora.Core.Interface
{
    public interface IDetalleVentaService
    {
        Task PostDetalleVenta(DetalleVenta o);
    }
}
