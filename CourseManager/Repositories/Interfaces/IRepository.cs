using System.Linq.Expressions;

namespace CourseManager.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    IEnumerable<T> GetAll();
    IEnumerable<T> Where(Expression<Func<T, bool>> filter);
    bool Any(Expression<Func<T, bool>> filter);
    void Delete(T entity);
    void Update(T entity);
    T FirstOrDefault(Expression<Func<T, bool>> filter);
    void Save();
}
