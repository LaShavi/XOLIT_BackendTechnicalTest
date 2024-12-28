using Application.Ports;
using Application.Services;
using Infrastructure.Persistence.Repositories;

namespace Api.Middleware
{
    public static class ServiceExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {            
            // Registro de Repositorios
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEspacioCompartidoRepository, EspacioCompartidoRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();

            // Registro de Servicios (Casos de Uso)
            services.AddScoped<ClienteService>();
            services.AddScoped<EspacioCompartidoService>();
            services.AddScoped<ReservaService>();
        }
    }
}
