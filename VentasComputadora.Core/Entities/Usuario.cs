using System;
using System.Collections.Generic;

namespace VentasComputadora.Core.Entities
{
    public partial class Usuario : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Ci { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Usuario1 { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }
    }
}
