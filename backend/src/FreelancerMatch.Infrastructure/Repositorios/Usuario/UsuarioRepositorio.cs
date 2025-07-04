using FreelancerMatch.Infrastructure.Db;
using FreelancerMatch.Infrastructure.Repositorios.Geral;

namespace FreelancerMatch.Infrastructure.Repositorios.Usuario
{
    public class UsuarioRepositorio : RepositorioBasico<Domain.Usuario.Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(AppDbContext context) : base(context)
        {
            
        }

    }
}