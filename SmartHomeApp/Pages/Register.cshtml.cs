using Core_Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartHomeApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserService _userservice;

        public RegisterModel(UserService userservice)
        {
            _userservice = userservice;
        }
        [BindProperty]

        public User newuser { get; set; }
        public void OnGet()
        {
        }
        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                 _userservice.Register(newuser);
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
