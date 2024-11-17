using JeugdLinkDAL.Entities;
using JeugdLinkDAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JeugLinkApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICourseRepository _courseRepository;

        public IndexModel(ILogger<IndexModel> logger, ICourseRepository courseRepository)
        {
            _logger = logger;
            _courseRepository = courseRepository;
        }

        [BindProperty]

        public List<CourseDTO> AllCourses { get; set; }=new List<CourseDTO>();
        public void OnGet()
        {
            try
            {
                AllCourses = _courseRepository.ReadCourses().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex.Message);
            }

        }
    }
}