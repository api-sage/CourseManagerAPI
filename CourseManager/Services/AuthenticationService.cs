using CourseManager.Commons;
using CourseManager.Interfaces;
using CourseManager.Models.Authentication;
using Microsoft.AspNetCore.Identity;

namespace CourseManager.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenService _tokenService;
    public AuthenticationService(UserManager<IdentityUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<Response<string>> RegisterUser(Register request)
    {
        Response<string> response = new ()
        {
            status = Constants.Fail,
            message = "Unsuccessful registration",
            data = string.Empty
        };

        try
        {
            IdentityUser user = new ()
            {
                UserName = request.UserName,
                Email = request.EmailAddress,
                EmailConfirmed = true
            };

            IdentityResult userResponse = await _userManager.CreateAsync(user, request.Password);

            if (!userResponse.Succeeded)
            {
                response.message = userResponse.Errors.ToList()[0].Description;
                return response;
            };

            IdentityResult addRole = await _userManager.AddToRoleAsync(user, request.Role);

            if (!addRole.Succeeded)
            {
                response.message = addRole.Errors.ToList()[0].Description;
                return response;
            };

            response.status = Constants.Success;
            response.message = $"{request.UserName} has been registered successfully. Kindly login.";
        }
        catch (Exception ex)
        {
            response.status = Constants.Error;
            response.message = "An error occurred";
            //log the error message
        }
        return response;
    }

    public async Task<Response<LoginResponse>> LoginUser(Login request)
    {
        Response<LoginResponse> response = new()
        {
            status = Constants.Fail,
            message = "Incorrect username or password",
            data = new LoginResponse
            {
                Token = string.Empty
            }
        };

        try
        {
            IdentityUser userSearch = await _userManager.FindByEmailAsync(request.EmailAddress);

            if (userSearch == null)
                return response;

            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(userSearch, request.Password);

            if (!isPasswordCorrect)
                return response;
            var userRole = await _userManager.GetRolesAsync(userSearch);
            if (userRole == null && !userRole!.Any())
                return response;
            string jwtToken = _tokenService.GenerateJWToken(userSearch, userRole!.First());
            response.status = Constants.Success;
            response.message = $"{userSearch.UserName} logged in successfully";
            response.data.Token = jwtToken;
        }
        catch (Exception ex)
        {
            response.status = Constants.Error;
            response.message = "An error occurred";
            //log the error message
        }
        return response;
    }
}
