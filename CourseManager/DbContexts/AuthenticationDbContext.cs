using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.DbContexts;

public class AuthenticationDbContext : IdentityDbContext
{
    private readonly IConfiguration _config;
    public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options, IConfiguration config) : base(options)
    {
        _config = config;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = _config["Roles:Admin"],
                NormalizedName = _config["Roles:Admin"]!.ToUpper(),
                Id = _config["Roles:RoleIds:Admin"]!,
                ConcurrencyStamp = _config["Roles:RoleIds:Admin"],
            },
            new IdentityRole
            {
                Name = _config["Roles:User"],
                NormalizedName = _config["Roles:User"]!.ToUpper(),
                Id = _config["Roles:RoleIds:User"]!,
                ConcurrencyStamp = _config["Roles:RoleIds:User"],
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}
