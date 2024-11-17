using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkDAL.Entities
{
    public class CourseDTO
    {
        private int ID { get; set; }
        private string? CourseTitle { get; set; }
        private string? Course_Description { get; set; }
        private DateTime DateTime { get; set; }
        private Mentor? Mentor_id { get; set; }

        public int course_id
        {
            get { return ID; }
            set { ID = value; }
        }

        public string course_title
        {
            get { return CourseTitle; }
            set { CourseTitle = value; }
        }
        public string course_description
        {
            get { return Course_Description; }
            set { Course_Description = value; }
        }
        public DateTime dateTime
        {
            get { return DateTime; }
            set { DateTime = value; }
        }
        public Mentor mentor_id
        {
            get { return Mentor_id; }
            set { Mentor_id = value; }
        }
      

    }
}
