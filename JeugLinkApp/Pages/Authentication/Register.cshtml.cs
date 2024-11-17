using JeugdLinkBLL.UserService;
using JeugdLinkDAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JeugLinkApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IRegistration _registration;

        public RegisterModel(IRegistration registration)
        {
            _registration = registration;
        }

        [BindProperty]

        public UserDTO newuser { get; set; }   
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                bool isRegistered = _registration.Register(newuser);
                if(!isRegistered)
                {
                    ModelState.AddModelError(string.Empty, "This email already exists!");
                    return Page();
                }
              
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }
    }
}
