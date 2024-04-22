using CourseManager.Commons;
using CourseManager.Entities;
using CourseManager.Models.Course;

namespace CourseManager.Interfaces;

public interface ICourseService
{
    Response<CourseDetails> CreateCourse(CourseDetails request);
    Response<CourseDetails> UpdateCourse(CourseDetails request);
    Response<CourseDetails> FindCourse(CourseCode request);
    Response<List<Course>> GetAllCourses();
    Response<string> DeleteCourse(CourseCode request);
}
