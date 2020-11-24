using System;
using System.Collections.Generic;

namespace VentasComputadora.Core.Entities
{
    public partial class DetalleVenta : BaseEntity
    {
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
