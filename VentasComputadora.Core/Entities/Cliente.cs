using System;
using System.Collections.Generic;

namespace VentasComputadora.Core.Entities
{
    public partial class Cliente : BaseEntity
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Ci { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
