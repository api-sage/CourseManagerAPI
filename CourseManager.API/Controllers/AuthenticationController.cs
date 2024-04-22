using CourseManager.Commons;
using CourseManager.Interfaces;
using CourseManager.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseManager.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Register users")]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Successful", typeof(Response<string>))]
    public async Task<IActionResult> Register(Register request)
    {
        var response = await _authenticationService.RegisterUser(request);
        return Ok(JsonConvert.SerializeObject(response));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Users' login")]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Successful", typeof(Response<LoginResponse>))]
    public async Task<IActionResult> Login(Login request)
    {
        var response = await _authenticationService.LoginUser(request);
        return Ok(JsonConvert.SerializeObject(response));
    }
}
