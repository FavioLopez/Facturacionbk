using System;
using System.Collections.Generic;
using System.Text;

namespace VentasComputadora.Core.DTO
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Ci { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
