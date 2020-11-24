using System;
using System.Collections.Generic;
using System.Text;

namespace VentasComputadora.Core.DTO
{
    public class VentaDto
    {
        public int ClienteId { get; set; }
        public DateTime FechaVenta { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public IEnumerable<DetalleVentaDto> DetalleVentas { get; set; }
    }
}
