using System;
using System.Collections.Generic;
using System.Text;

namespace VentasComputadora.Core.Interface
{
    public interface ICodigoControl
    {
        string CifrarMensajeRC4(string mensaje,string llave,Boolean guion);
        string ObtenerBase64(int valor);
        int ObtenerVerhoeff(string cibra);
        string GenerarCodigoControl(string NumAutorizacion, string NumFactura, string NitCi,
            string FechaTran, string MontoTran, string LlaveDosi);

    }
}
