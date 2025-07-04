using System.Linq.Expressions;

namespace FreelancerMatch.Infrastructure.Repositorios.Geral
{
    public interface IRepositorioBasico<T> where T : class
    {
        Task<T?> BuscarPorIdAsync(Guid id); 
        Task<IEnumerable<T>> ListarTodosAsync();
        Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicate); 
        Task AdicionarAsync(T entity);
        void Atualizar(T entity);
        Task Remover(T entity);
    }
}