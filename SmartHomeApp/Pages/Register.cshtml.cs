using Core_Domain;
using Core_Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartHomeApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserserivce _userservice;

        public RegisterModel(IUserserivce userservice)
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

                 var result=   _userservice.Register(newuser);

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
