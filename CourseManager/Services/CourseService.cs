using CourseManager.Commons;
using CourseManager.Entities;
using CourseManager.Interfaces;
using CourseManager.Models.Course;
using CourseManager.Repositories.Interfaces;

namespace CourseManager.Services;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Response<CourseDetails> CreateCourse(CourseDetails request)
    {
        var response = new Response<CourseDetails>()
        {
            status = Constants.Fail,
            message = "Course addition unsuccessful",
            data = new CourseDetails()
        };

        try
        {
            var course = new Course()
            {
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                Instructor = request.Instructor,
                StartDate = DateTime.Parse(request.StartDate.ToString()),
                EndDate = DateTime.Parse(request.EndDate.ToString())
            };
            _unitOfWork.CourseRepository.Add(course);
            _unitOfWork.CourseRepository.Save();
            response.status = Constants.Success;
            response.message = "Course successfully added";
            response.data = request;

        }
        catch (Exception ex)
        {
            response.status = Constants.Error;
            response.message = "An error occurred";
        }

        return response;
    }

    public Response<CourseDetails> UpdateCourse(CourseDetails request)
    {
        var response = new Response<CourseDetails>()
        {
            status = Constants.Fail,
            message = "Course update unsuccessful",
            data = new CourseDetails()
        };

        try
        {
            var course = _unitOfWork.CourseRepository.Where(x => x.Code == request.Code).ToList().First();

            if (course == null)
            {
                response.message = $"Course code {request.Code} does not exist";
                return response;
            }

            course.Code = request.Code;
            course.Name = request.Name;
            course.Description = request.Description;
            course.Instructor = request.Instructor;
            course.StartDate = DateTime.Parse(request.StartDate.ToString());
            course.EndDate = DateTime.Parse(request.EndDate.ToString());

            _unitOfWork.CourseRepository.Update(course);
            _unitOfWork.CourseRepository.Save();

            response.status = Constants.Success;
            response.message = "Course successfully added";
            response.data = request;

        }
        catch (Exception ex)
        {
            response.status = Constants.Error;
            response.message = "An error occurred";
        }

        return response;
    }

    public Response<CourseDetails> FindCourse(CourseCode request)
    {
        var response = new Response<CourseDetails>()
        {
            status = Constants.Fail,
            message = $"Course {request.Code} could not be found",
            data = new CourseDetails()
        };

        try
        {
            var course = _unitOfWork.CourseRepository.Where(x => x.Code == request.Code).ToList().First();

            if (course == null)
            {
                response.message = $"Course code {request.Code} does not exist";
                return response;
            }

            response.status = Constants.Success;
            response.message = "Course found successfully";
            response.data.Code = course.Code;
            response.data.Name = course.Name;
            response.data.Instructor = course.Instructor;
            response.data.StartDate = DateOnly.Parse(course.StartDate.ToString());
            response.data.EndDate = DateOnly.Parse(course.EndDate.ToString());
        }
        catch (Exception ex)
        {
            response.status = Constants.Error;
            response.message = "An error occurred";
        }

        return response;
    }

    public Response<string> DeleteCourse(CourseCode request)
    {
        var response = new Response<string>()
        {
            status = Constants.Fail,
            message = "Course deletion unsuccessful",
            data = string.Empty
        };

        try
        {
            var course = _unitOfWork.CourseRepository.Where(x => x.Code == request.Code).ToList().First();

            if (course == null)
            {
                response.message = $"Course code {request.Code} does not exist";
                return response;
            }

            _unitOfWork.CourseRepository.Delete(course);
            _unitOfWork.CourseRepository.Save();

            response.status = Constants.Success;
            response.message = "Course deleted successfully";
        }
        catch (Exception ex)
        {
            response.status = Constants.Error;
            response.message = "An error occurred";
        }

        return response;
    }

    public Response<List<Course>> GetAllCourses()
    {
        var response = new Response<List<Course>>()
        {
            status = Constants.Fail,
            message = "Unable to retrieve all courses at this time",
            data = new List<Course>()
        };

        try
        {
            var courses = _unitOfWork.CourseRepository.GetAll().ToList();
            if (courses == null || !courses.Any())
            {
                response.message = "No course has been registered yet";
                return response;
            }
            response.status = Constants.Success;
            response.message = "Courses retrieved successfully";
            response.data = courses;
        }
        catch (Exception ex)
        {
            response.status = Constants.Error;
            response.message = "An error occurred";
        }
        return response;
    }
}
