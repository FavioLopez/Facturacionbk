using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentasComputadora.API.Response;
using VentasComputadora.Core.DTO;
using VentasComputadora.Core.Entities;
using VentasComputadora.Core.Interface;

namespace VentasComputadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentaService _ventaService;
        private readonly IDetalleVentaService _detalleVentaService;
        private readonly IMapper _mapper;

        public VentasController(IVentaService ventaService, IDetalleVentaService detalleVentaService, IMapper mapper)
        {
            _ventaService = ventaService;
            _detalleVentaService = detalleVentaService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostVenta(VentaDto ventaDto)
        {
            var oVenta = _mapper.Map<Venta>(ventaDto);
            await _ventaService.PostVenta(oVenta);

            foreach (var detalleDto in ventaDto.DetalleVentas)
            {              
                var oDetalle = _mapper.Map<DetalleVenta>(detalleDto);
                oDetalle.VentaId = oVenta.Id;
                await _detalleVentaService.PostDetalleVenta(oDetalle);
            }


            ventaDto = _mapper.Map<VentaDto>(oVenta);
            var response = new ApiResponse<VentaDto>(ventaDto);
            return Ok(response);

        }
    }
}
