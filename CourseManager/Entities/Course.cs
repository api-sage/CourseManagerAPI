using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Entities;

public class Course
{
    [Key]
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Instructor { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
