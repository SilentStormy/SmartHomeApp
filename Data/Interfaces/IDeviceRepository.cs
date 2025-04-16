using Infrastructure.Data.DTO;
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
        string GetDeviceSatus(int deviceId);
        void RemoveDevice(int deviceId);
        void TurnOnDevice(int deviceId); 
        void TurnOffDevice(int deviceId);
        void SetDeviceLocation(int deviceId, int locationId);
    }
}
