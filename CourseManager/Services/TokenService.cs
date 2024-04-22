using CourseManager.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Services;

public class TokenService : ITokenService
{
	private readonly IConfiguration _config;
    public TokenService(IConfiguration config)
    {
		_config = config;
    }
    public string GenerateJWToken(IdentityUser user, string role)
    {
        List<Claim> claims = [new Claim(ClaimTypes.Email, user.Email!), new Claim(ClaimTypes.Role, role)];
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken token = new(
			_config["Jwt:Issuer"],
			_config["Jwt:Audience"],
			claims,
			expires: DateTime.Now.AddMinutes(10),
			signingCredentials: credentials
			);
		return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
