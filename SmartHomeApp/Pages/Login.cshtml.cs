using Core_Domain.Entities;
using Core_Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SmartHomeApp.Pages
{
    public class LoginModel : PageModel
    {

        private readonly IUserserivce _userservice;

        public LoginModel(IUserserivce userservice)
        {
            _userservice = userservice;
        }

        [BindProperty]
        public string email {  get; set; }  
        
        [BindProperty]
        public string password {  get; set; }


        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
               
                return Page();
            }
            try
            {
                User user = new User(email, password);
               
               var result= _userservice.Login(user);
                TempData["SuccessMessage"]=result.Message;
                return RedirectToPage("/DeviceDashboard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Er is een fout opgetreden: {ex.Message}");
                return Page();
            }



        }
    }
}
