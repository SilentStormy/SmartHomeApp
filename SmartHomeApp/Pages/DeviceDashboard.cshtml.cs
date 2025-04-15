using Core_Domain;
using Core_Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartHomeApp.Pages
{
    public class DeviceDashboardModel : PageModel
    {
        private readonly IDeviceService _deviceService;

        public DeviceDashboardModel(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }
        [BindProperty]
        public Device newdevice { get; set; }

       
        [BindProperty]
        public List<Device> Alldevices{ get; set; }
        public void OnGet()
        {
            Alldevices=_deviceService.GetAlldevices();
        }

        public async Task<ActionResult> OnPostAsync(string action)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                
                    var result = _deviceService.AddNewDevice(newdevice);

                    if (!result.Success)
                    {
                        ModelState.AddModelError(string.Empty, result.Message);
                        return Page();
                    }
                    TempData["SuccessMessage"] = result.Message;

                return Page();
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostRemoveAsync(int deviceid)
        {
            var device = new Device { DeviceId = deviceid };
            var result = _deviceService.RemoveDevice(device);
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return Page();
            }

            TempData["SuccessMessage"] = result.Message;
            return RedirectToPage();
        }



    }
}
