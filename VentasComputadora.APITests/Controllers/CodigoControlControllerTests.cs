using Microsoft.VisualStudio.TestTools.UnitTesting;
using VentasComputadora.API.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using VentasComputadora.Core.DTO;
using VentasComputadora.Core.Helpers;

namespace VentasComputadora.API.Controllers.Tests
{
    [TestClass()]
    public class CodigoControlControllerTests
    {
        CodigoControlDto codigoControlDto = new CodigoControlDto();
        CodigoControlController codigo = new CodigoControlController();
        [TestMethod()]
        public void GetCodigoControlTest()
        {
            string valorEsperado = "";
            string valorRespuesta = "";

        }
    }
}