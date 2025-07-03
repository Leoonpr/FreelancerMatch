using FreelancerMatch.Domain.Usuario;
using FreelancerMatch.Infrastructure.Db;
using FreelancerMatch.Infrastructure.Repositorios.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreelancerMatch.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString)
            );

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            

            return services;
        }
    }
}