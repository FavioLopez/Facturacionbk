using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VentasComputadora.Core.DTO;
using VentasComputadora.Core.Entities;

namespace VentasComputadora.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, Producto>();

            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();

            CreateMap<Venta, VentaDto>();
            CreateMap<VentaDto, Venta>();

            CreateMap<DetalleVenta, DetalleVentaDto>();
            CreateMap<DetalleVentaDto, DetalleVenta>();

        }
    }
}
