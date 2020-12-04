using Microsoft.VisualStudio.TestTools.UnitTesting;
using VentasComputadora.API.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using VentasComputadora.Core.DTO;
using VentasComputadora.Core.Helpers;
using VentasComputadora.Core.Interface;

namespace VentasComputadora.API.Controllers.Tests
{
    //protected abstract ICodigoControl CreateInstance();
    [TestClass()]
    public class CodigoControlControllerTests
    {
        CodigoControlDto codigoControlDto = new CodigoControlDto();
        CodigoControlController codigo = new CodigoControlController();
        [TestMethod()]
        public void GetCodigoControlTest()
        {

            codigoControlDto.NumAutorizacion = "79040011859";
            codigoControlDto.NumFactura = "152";
            codigoControlDto.NitCi = "1026469026";
            codigoControlDto.FechaTran = "20070728";
            codigoControlDto.MontoTran = "135";
            codigoControlDto.LlaveDosi = "A3Fs4s$)2cvD(eY667A5C4A2rsdf53kw9654E2B23s24df35F5";
            string valorEsperado = "FB-A6-E4-78";
            string valorRespuesta = codigo.GetCodigoControl(codigoControlDto);
            Assert.AreEqual(valorEsperado, valorRespuesta);
        }
    }
}