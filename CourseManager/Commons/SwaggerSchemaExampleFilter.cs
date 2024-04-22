using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Commons;

public class SwaggerSchemaExampleFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.MemberInfo != null)
        {
            var schemaAttribute = context.MemberInfo.GetCustomAttributes(typeof(SwaggerSchemaExampleAttribute), true).FirstOrDefault();
            if (schemaAttribute != null)
                ApplySchemaAttribute(schema, (SwaggerSchemaExampleAttribute)schemaAttribute);
        }
    }

    private void ApplySchemaAttribute(OpenApiSchema schema, SwaggerSchemaExampleAttribute schemaAttribute)
    {
        if (schemaAttribute.Example != null)
        {
            schema.Example = new OpenApiString(schemaAttribute.Example);
        }
    }
}
