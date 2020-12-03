using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentasComputadora.Core.DTO;
using VentasComputadora.Core.Helpers;

namespace VentasComputadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodigoControlController : ControllerBase
    {
        CodigoControl cod = new CodigoControl();
        [HttpGet]
        public string GetCodigoControl(CodigoControlDto codigoControlDto)
        {
            string codigoRespuesta = cod.GenerarCodigoControl(codigoControlDto.NumAutorizacion,
                codigoControlDto.NumFactura,codigoControlDto.NitCi,codigoControlDto.FechaTran,
                codigoControlDto.MontoTran,codigoControlDto.LlaveDosi);
            return codigoRespuesta;
        }
    }
}
