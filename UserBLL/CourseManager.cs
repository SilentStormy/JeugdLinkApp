using JeugdLinkDAL.Entities;
using JeugdLinkDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkBLL
{
    public class CourseManager:ICourseManager
    {
        private readonly ICourseRepository courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;

        }

        public List<CourseDTO> GetAllCourses()
        {
            return courseRepository.ReadCourses();
        }
    }
}
