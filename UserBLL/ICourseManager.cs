using JeugdLinkDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkBLL
{
    public interface ICourseManager
    {
        List<CourseDTO> GetAllCourses();
    }
}
