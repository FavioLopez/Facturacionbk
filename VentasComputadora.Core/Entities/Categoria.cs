using System;
using System.Collections.Generic;

namespace VentasComputadora.Core.Entities
{
    public partial class Categoria : BaseEntity
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
