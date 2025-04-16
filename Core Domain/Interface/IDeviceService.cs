using Core_Domain.Result;
using Infrastructure.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Interface
{
    public interface IDeviceService
    {
        DeviceResult AddNewDevice(Device device);
        DeviceResult RemoveDevice(Device device);
        List<Device> GetAlldevices();
        DeviceResult TurnOn(Device device);
        DeviceResult TurnOff(Device device);

        DeviceResult SetDeviceToLocation(Device device,Location location);


    }
}
