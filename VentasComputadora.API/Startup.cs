using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using VentasComputadora.Core.Helpers;
using VentasComputadora.Core.Interface;
using VentasComputadora.Core.Services;
using VentasComputadora.Infrastructure.Data;
using VentasComputadora.Infrastructure.Repositories;

namespace VentasComputadora.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var conex = Configuration.GetConnectionString("VentaComputadorasDB");
            services.AddControllers();
            //Conexion a Sqlserver
            services.AddDbContext<VentaComputadorasContext>(options => 
                options.UseSqlServer(conex)
            );
            //services.AddTransient<ITestApiRepository, TestapiRepository>();
            //services.AddTransient<ITestApiRepository, TestapiMongoDB>();
            //services.AddTransient<ITestApiRepository, TestapiOracle>();
            //services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IVentaService, VentaService>();
            services.AddTransient<ICodigoControl, CodigoControl>();
            services.AddTransient<IDetalleVentaService, DetalleVentaService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(a => a.AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(or => true)
            .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
