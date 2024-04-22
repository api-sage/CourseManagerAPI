using CourseManager.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Models.Course;

public class CourseCode
{
    [Required]
    [SwaggerSchemaExample("CSC101")]
    public string Code { get; set; }
}
