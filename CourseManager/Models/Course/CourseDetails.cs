using CourseManager.Commons;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Models.Course;

public class CourseDetails
{
    [Required]
    [SwaggerSchemaExample("CSC101")]
    public string Code { get; set; }
    [Required]
    [SwaggerSchemaExample("Computer science 1")]
    public string Name { get; set; }
    [Required]
    [SwaggerSchemaExample("Introduction to computer science")]
    public string Description { get; set; }
    [Required]
    [SwaggerSchemaExample("Prof.A.A.Kushan")]
    public string Instructor { get; set; }
    [Required]
    public DateOnly StartDate { get; set; }
    [Required]
    public DateOnly EndDate { get; set; }
}
