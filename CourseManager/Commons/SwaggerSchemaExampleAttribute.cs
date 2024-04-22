using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Commons;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Enum, AllowMultiple = false)]
public class SwaggerSchemaExampleAttribute : Attribute
{
    public string Example { get; internal set; }
    public SwaggerSchemaExampleAttribute(string example)
    {
        Example = example;
    }
}
