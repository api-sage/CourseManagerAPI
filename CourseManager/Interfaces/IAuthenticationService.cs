using CourseManager.Commons;
using CourseManager.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Interfaces;

public interface IAuthenticationService
{
    Task<Response<string>> RegisterUser(Register request);
    Task<Response<LoginResponse>> LoginUser(Login request);
}
