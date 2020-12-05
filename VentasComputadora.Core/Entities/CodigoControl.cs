using System;
using System.Collections.Generic;
using System.Text;

namespace VentasComputadora.Core.Entities
{
    public class CodigoControl : BaseEntity
    {
        public string NumAutorizacion { get; set; }
        public string NumFactura { get; set; }
        public string NitCi { get; set; }
        public string FechaTran { get; set; }
        public string MontoTran { get; set; }
        public string LlaveDosi { get; set; }
    }
}
