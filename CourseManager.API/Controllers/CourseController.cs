using CourseManager.Commons;
using CourseManager.Interfaces;
using CourseManager.Models.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseManager.API.Controllers;

[ApiController]
[Route("[controller]/[Action]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    [SwaggerOperation(Summary = "Add courses")]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Successful", typeof(Response<CourseDetails>))]
    public async Task<IActionResult> AddCourse(CourseDetails request)
    {
        var response = _courseService.CreateCourse(request);
        return Ok(JsonConvert.SerializeObject(response));
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    [SwaggerOperation(Summary = "Updates courses")]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Successful", typeof(Response<CourseDetails>))]
    public async Task<IActionResult> UpdateCourse(CourseDetails request)
    {
        var response = _courseService.UpdateCourse(request);
        return Ok(JsonConvert.SerializeObject(response));
    }

    [HttpPost]
    [Authorize(Roles = "Administrator, Regular User")]
    [SwaggerOperation(Summary = "Searches for a courses using the course code")]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Successful", typeof(Response<CourseDetails>))]
    public async Task<IActionResult> FindCourse(CourseCode request)
    {
        var response = _courseService.FindCourse (request);
        return Ok(JsonConvert.SerializeObject(response));
    }

    [HttpGet]
    [Authorize(Roles = "Administrator, Regular User")]
    [SwaggerOperation(Summary = "Fetches all registered courses")]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Successful", typeof(Response<List<CourseDetails>>))]
    public async Task<IActionResult> GetAllCourses()
    {
        var response = _courseService.GetAllCourses();
        return Ok(JsonConvert.SerializeObject(response));
    }

    [HttpDelete]
    [Authorize(Roles = "Administrator")]
    [SwaggerOperation(Summary = "Deletes a courses using the course code")]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Successful", typeof(Response<string>))]
    public async Task<IActionResult> DeleteCourse(CourseCode request)
    {
        var response = _courseService.DeleteCourse(request);
        return Ok(JsonConvert.SerializeObject(response));
    }
}
