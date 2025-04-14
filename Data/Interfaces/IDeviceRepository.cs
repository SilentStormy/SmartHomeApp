using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Interfaces
{
    public interface IDeviceRepository
    {
        void AddNewDevice(string deviceCode, string deviceName);
        bool DeviceCodeExists(string deviceCode);
        bool DeviceNameExists(string deviceName);   
        List<DeviceDTO> GetAllDevices();

        void RemoveDevice(string deviceName);
        
    }
}
