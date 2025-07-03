using FreelancerMatch.Application.Servicos.Usuario;
using Microsoft.Extensions.DependencyInjection;

namespace FreelancerMatch.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            // Registrar os serviços da camada de aplicação
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}