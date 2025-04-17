using Core_Domain.Entities;
using Core_Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartHomeApp.Pages
{
    public class DeviceDashboardModel : PageModel
    {
        private readonly IDeviceService _deviceService;
        private readonly ILocationService _locationService; 

        public DeviceDashboardModel(IDeviceService deviceService,ILocationService locationService)
        {
            _deviceService = deviceService;
            _locationService = locationService;
        }
       

        [BindProperty]
        public string DeviceName {  get; set; }
        [BindProperty]
        public string DeviceCode { get; set; }

        [BindProperty]
        public List<Device> Alldevices{ get; set; }

        [BindProperty]
        public Device selecteddevice{ get; set; }

        [BindProperty]
        public Location selectedlocation { get; set; }

        [BindProperty]
        public List<Location> AllLocations { get; set; }    
         public void OnGet()
        {
            Alldevices=_deviceService.GetAlldevices();
            AllLocations=_locationService.GetAllLocations();
        }

        public async Task<ActionResult> OnPostAddDeviceAsync()
        {
            if(!ModelState.IsValid)
            {
                Alldevices = _deviceService.GetAlldevices();
                return Page();
            }

            try
            {
                Device newdevice = new Device(DeviceName, DeviceCode)
                {
                    DeviceStatus = "OFF"
                };
                    var result = _deviceService.AddNewDevice(newdevice);

                    if (!result.Success)
                    {
                        ModelState.AddModelError(string.Empty, result.Message);
                    Alldevices = _deviceService.GetAlldevices();
                    return Page();
                    }
                    TempData["SuccessMessage"] = result.Message;
                Alldevices = _deviceService.GetAlldevices();

                return Page();
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                Alldevices = _deviceService.GetAlldevices();
                return Page();
            }
        }

        public async Task<IActionResult> OnPostRemoveDeviceAsync(int deviceid)
        {
           selecteddevice = new Device { DeviceId = deviceid };
            var result = _deviceService.RemoveDevice(selecteddevice);
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                Alldevices = _deviceService.GetAlldevices();
                return Page();
            }

            TempData["SuccessMessage"] = result.Message;
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostTurnOnDeviceAsync(int deviceid)
        {
            selecteddevice = new Device { DeviceId = deviceid };
            var result = _deviceService.TurnOn(selecteddevice);
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                Alldevices = _deviceService.GetAlldevices();
                return Page();
            }

            TempData["SuccessMessage"] = result.Message;
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostTurnOffDeviceAsync(int deviceid)
        {
            selecteddevice = new Device { DeviceId = deviceid };
            var result = _deviceService.TurnOff(selecteddevice);
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                Alldevices = _deviceService.GetAlldevices();
                return Page();
            }

            TempData["SuccessMessage"] = result.Message;
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSetLocationAsync(int deviceid,int locationid)
        {
            selecteddevice = new Device { DeviceId = deviceid };
            selectedlocation = new Location { LocationId = locationid };
            
            var result = _deviceService.SetDeviceToLocation(selecteddevice,selectedlocation);
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                Alldevices = _deviceService.GetAlldevices();
                return Page();
            }

            TempData["SuccessMessage"] = result.Message;
            return RedirectToPage();
        }

    }
}
