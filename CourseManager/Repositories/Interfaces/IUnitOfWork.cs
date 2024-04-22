using CourseManager.Entities;

namespace CourseManager.Repositories.Interfaces;

public interface IUnitOfWork
{
    IRepository<Course> CourseRepository { get; }
}
