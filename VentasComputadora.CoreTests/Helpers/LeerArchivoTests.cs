using Microsoft.VisualStudio.TestTools.UnitTesting;
using VentasComputadora.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace VentasComputadora.Core.Helpers.Tests
{
    [TestClass()]
    public class LeerArchivoTests
    {
        [TestMethod()]
        public void leerLineasTest() 
        {
            int cont = 0;
            string linea;
            List<string> valorEsperado = new List<string>();
            string direccion = "D:/FINALRICARDO/Facturacionbk/VentasComputadora.Core/Helpers/5000CasosPruebaCCVer7.txt";
            System.IO.StreamReader archivo = new System.IO.StreamReader(direccion);
            while ((linea = archivo.ReadLine()) != null)
            {
                if (cont!=0)
                {
                    String[] result = linea.Split('|');
                    valorEsperado.Add(result[result.Length - 2]);
                }
                cont++;
            }
            archivo.Close();
            var lector = new LeerArchivo();
            List<string> valorResultado = lector.leerLineas();
            CollectionAssert.AreEqual(valorEsperado,valorResultado);
        }
    }
}