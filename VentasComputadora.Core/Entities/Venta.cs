using System;
using System.Collections.Generic;

namespace VentasComputadora.Core.Entities
{
    public partial class Venta : BaseEntity
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int ClienteId { get; set; }
        public DateTime FechaVenta { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
