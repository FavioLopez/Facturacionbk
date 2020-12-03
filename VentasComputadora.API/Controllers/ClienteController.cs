using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentasComputadora.API.Response;
using VentasComputadora.Core.DTO;
using VentasComputadora.Core.Helpers;
using VentasComputadora.Core.Interface;

namespace VentasComputadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        private readonly ICodigoControl _cod;

        public ClienteController(IClienteService clienteService, IMapper mapper, ICodigoControl cod)
        {
            _clienteService = clienteService;
            _mapper = mapper;
            _cod = cod;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            var result = _clienteService.GetClientes();
            var resultDto = _mapper.Map<IEnumerable<ClienteDto>>(result);

            var response = new ApiResponse<IEnumerable<ClienteDto>>(resultDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var result = await _clienteService.GetCliente(id);
            var resultDto = _mapper.Map<ClienteDto>(result);

            var response = new ApiResponse<ClienteDto>(resultDto);
            return Ok(response);
        }
      
    }
}
