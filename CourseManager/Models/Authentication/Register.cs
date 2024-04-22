using CourseManager.Commons;
using Swagger.Net.Swagger.Annotations;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Models.Authentication;

public class Register
{
    [Required]
    [SwaggerSchemaExample("dummyUser")]
    [SwaggerSchema(Description = "Username")]
    public string UserName { get; set; }
    [Required]
    [SwaggerSchemaExample("dummyUser@email.com")]
    [SwaggerSchema(Description = "User email address")]
    [DataType(DataType.EmailAddress)]
    public string EmailAddress { get; set; }
    [Required]
    [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Password must contain at least one digit, one uppercase letter, one lowercase letter, one non-alphanumeric character, and be at least 8 characters long.")]
    [DataType(DataType.Password)]
    [SwaggerSchemaExample("1aB;234@")]
    public string Password { get; set; }
    [SwaggerSchemaExample("Regular User")]
    [SwaggerSchema(Description = "Role")]
    public string Role { get; set; }
}
