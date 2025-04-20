using Core_Domain.Entities;
using Core_Domain.Interface;
using Core_Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartHomeApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserAuthService _userauthentication;

        public RegisterModel(IUserAuthService userservice)
        {
            _userauthentication = userservice;
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

                var result = _userauthentication.Register(newuser);
                    
                if (!result.Success)
                {
                    ModelState.AddModelError(string.Empty, result.Message); 
                    return Page();
                }

                TempData["SuccessMessage"] = result.Message;
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
