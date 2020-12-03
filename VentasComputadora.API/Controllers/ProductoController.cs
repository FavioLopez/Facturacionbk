using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VentasComputadora.Core.DTO;
using VentasComputadora.Core.Interface;
using VentasComputadora.API.Response;
using VentasComputadora.Core.Entities;

namespace VentasComputadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;

        public ProductoController(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            var result =  _productoService.GetProductos();            
            var resultDto = _mapper.Map<IEnumerable<ProductoDto>>(result);

            //var response = new ApiResponse<IEnumerable<ProductoDto>>(resultDto);
            return Ok(resultDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var result = await _productoService.GetProducto(id);
            var resultDto = _mapper.Map<ProductoDto>(result);

            var response = new ApiResponse<ProductoDto>(resultDto);
            return Ok(response);
        }

        //[HttpGet("NombreProductos/{nombre}")]          
        [Route("[action]/{nombre}")]
        [HttpGet]
        public IActionResult GetNombreProductos(string nombre)
        {
            var result =  _productoService.GetNombreProductos(nombre.ToUpper());
            var resultDto = _mapper.Map<IEnumerable<ProductoDto>>(result);

            var response = new ApiResponse<IEnumerable<ProductoDto>>(resultDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostProducto(ProductoDto productoDto)
        {
            var oProducto = _mapper.Map<Producto>(productoDto);
            await _productoService.PostProducto(oProducto);

            productoDto = _mapper.Map<ProductoDto>(oProducto);
            var response = new ApiResponse<ProductoDto>(productoDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(ProductoDto productoDto, int id)
        {
            var oProducto = _mapper.Map<Producto>(productoDto);
            bool result = await _productoService.PutProducto(oProducto);
            
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            bool result = await this._productoService.DeleteProducto(id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
