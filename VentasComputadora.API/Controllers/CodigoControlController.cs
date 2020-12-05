using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentasComputadora.Core.DTO;
using VentasComputadora.Core.Helpers;
using VentasComputadora.Core.Interface;

namespace VentasComputadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodigoControlController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICodigoControl cod;
        //public CodigoControlController(ICodigoControl codigo)
        //{
        //    this.cod = codigo;
        //}
        [HttpPost]
        public string GetCodigoControl(CodigoControlDto codigoControlDto)
        {
            CodigoControl codigo = new CodigoControl(unitOfWork);
            string codigoRespuesta = codigo.GenerarCodigoControl(codigoControlDto.NumAutorizacion,
                codigoControlDto.NumFactura,codigoControlDto.NitCi,codigoControlDto.FechaTran,
                codigoControlDto.MontoTran,codigoControlDto.LlaveDosi);
            return codigoRespuesta;
        }
    }
}
