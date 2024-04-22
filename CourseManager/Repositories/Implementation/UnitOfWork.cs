using CourseManager.DbContexts;
using CourseManager.Entities;
using CourseManager.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Repositories.Implementation;

public class UnitOfWork : IUnitOfWork
{
    public CourseDbContext _db;
    public UnitOfWork(CourseDbContext db)
    {
        _db = db;
    }

    public IRepository<Course> CourseRepository => new RepositoryService<Course>(_db);

    public void Save()
    {
        _db.SaveChanges();
    }
}
