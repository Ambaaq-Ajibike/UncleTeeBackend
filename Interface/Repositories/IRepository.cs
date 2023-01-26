using System.Linq.Expressions;

namespace Backend.Interface.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<T> Add(T entity);
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<IReadOnlyList<T>> GetAll(Expression<Func<T, bool>> expression);
        Task< bool> Delete(T entity);
        Task< bool> Exist(Expression<Func<T, bool>> expression);
    }
}