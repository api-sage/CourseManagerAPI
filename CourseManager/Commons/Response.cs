using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Commons;

public class Response<T>
{
    public string status;
    public string message;
    public T data;
}
