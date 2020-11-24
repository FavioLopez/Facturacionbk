using System;
using System.Collections.Generic;
using System.Text;

namespace VentasComputadora.Core.DTO
{
    public class DetalleVentaDto
    {
        //public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }


    }
}
