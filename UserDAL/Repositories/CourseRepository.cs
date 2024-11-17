using JeugdLinkDAL.Entities;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkDAL.Repositories
{
    public class CourseRepository:ICourseRepository
    {
        private readonly string _connstring;
        private readonly ILogger<CourseRepository> _logger;

        public CourseRepository(string connstring, ILogger<CourseRepository> logger)
        {
            _connstring = connstring;
            _logger = logger;
        }

        public List<CourseDTO> ReadCourses()
        {
            var courses = new List<CourseDTO>();
            try
            {
                MySqlConnection connection = new MySqlConnection(_connstring);
                connection.Open();
                string query = "SELECT Course_id,Title,Description FROM courses";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            courses.Add(new CourseDTO
                            {

                                course_id = reader.GetInt32("Course_id"),
                                course_title = reader["Title"].ToString(),
                                course_description = reader["Description"].ToString(),

                            });
                        }
                    }
                }




            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return courses;




        }
    }
}
    
