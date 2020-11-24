using System;
using System.Collections.Generic;
using System.Text;

namespace VentasComputadora.Core.DTO
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaCreado { get; set; }
        //public byte[] Imagen { get; set; }
    }
}
