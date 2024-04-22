using CourseManager.DbContexts;
using CourseManager.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CourseManager.Repositories.Implementation;

public class RepositoryService<T> : IRepository<T> where T : class
{
    public CourseDbContext _db;
    public DbSet<T> _dbSet;
    public RepositoryService(CourseDbContext db)
    {
        _db = db;
        _dbSet = _db.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public bool Any(Expression<Func<T, bool>> filter)
    {
        return _dbSet.Any(filter);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public T FirstOrDefault(Expression<Func<T, bool>> filter)
    {
        return _dbSet.FirstOrDefault(filter)!;
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public IEnumerable<T> Where(Expression<Func<T, bool>> filter)
    {
        return _dbSet.Where(filter);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
