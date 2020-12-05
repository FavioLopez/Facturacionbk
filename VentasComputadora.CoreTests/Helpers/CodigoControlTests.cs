using Microsoft.VisualStudio.TestTools.UnitTesting;
using VentasComputadora.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using VentasComputadora.Core.Interface;

namespace VentasComputadora.Core.Helpers.Tests
{
   
    [TestClass()]
    public class CodigoControlTests
    {
        private readonly IUnitOfWork unit;
        private readonly ICodigoControl cod;
        [TestMethod()]
        public void CifrarMensajeRC4Test()
        {
            CodigoControl cod = new CodigoControl(unit);
            Assert.AreEqual("EB-06-AE-F8-92", cod.CifrarMensajeRC4("d3Ir6", "sesamo", false));
        }

        [TestMethod()]
        public void GenerarCodigoControlTest()
        {
            CodigoControl cod = new CodigoControl(unit);
            Assert.AreEqual("FB-A6-E4-78", cod.GenerarCodigoControl("79040011859", "152", "1026469026",
                "20070728", "135", "A3Fs4s$)2cvD(eY667A5C4A2rsdf53kw9654E2B23s24df35F5"));
        }

        [TestMethod()]
        public void ObtenerBase64Test()
        {
            CodigoControl cod = new CodigoControl(unit);
            Assert.AreEqual("tjDU/", cod.ObtenerBase64(934598591));
        }

        [TestMethod()]
        public void ObtenerVerhoeffTest()
        {
            CodigoControl cod = new CodigoControl(unit);
            Assert.AreEqual(7, cod.ObtenerVerhoeff("12083"));
        }
    }
}