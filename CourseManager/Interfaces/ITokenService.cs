using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Interfaces;

public interface ITokenService
{
    string GenerateJWToken(IdentityUser user, string role);
}
