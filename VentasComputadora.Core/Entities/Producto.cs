using System;
using System.Collections.Generic;

namespace VentasComputadora.Core.Entities
{
    public partial class Producto : BaseEntity
    {
        public Producto()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }     
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaCreado { get; set; }
        public byte[] Imagen { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
