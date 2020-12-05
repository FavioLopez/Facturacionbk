using System;
using System.Collections.Generic;
using System.Text;
using VentasComputadora.Core.Interface;

namespace VentasComputadora.Core.Helpers
{
    public class LeerArchivo
    {
        private readonly IUnitOfWork unit;
        public List<string> leerLineas()
        {
            var codigoControl = new CodigoControl(unit);
            int cont = 0;
            string linea;
            List<string> lista = new List<string>();
            //poner la direccion del archivo ejemplo C:\Users\Usuario\source\repos\Facturacion-en-linea\FacturacionEnLinea\FacturacionEnLinea\Casos de prueba\5000CasosPruebaCCVer7.txt
            string direccion = "D:/FINALRICARDO/Facturacionbk/VentasComputadora.Core/Helpers/5000CasosPruebaCCVer7.txt";
            System.IO.StreamReader archivo = new System.IO.StreamReader(direccion);
            while ((linea = archivo.ReadLine()) != null)
            {
                if (cont != 0)
                {
                    String[] result = linea.Split('|');
                    String[] fecha = result[3].Split('/');
                    string fechaConcadenada = fecha[0] + fecha[1] + fecha[2];
                    lista.Add(codigoControl.GenerarCodigoControl(result[0], result[1], result[2], fechaConcadenada, result[4].Replace(",", "."), result[5]));
                }
                cont++;
            }
            archivo.Close();
            return lista;
        }
    }
}
