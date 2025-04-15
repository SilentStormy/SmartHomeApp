using Core_Domain.Result;
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
        AuthResult TurnOn(Device device);
        AuthResult TurnOff(Device device);
    }
}
