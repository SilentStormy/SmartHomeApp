using Core_Domain.Interface;
using Core_Domain.Result;
using Infrastructure.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Service
{
    public class DeviceService : IDeviceService
    {
        private readonly string _connectionstring;

        private readonly IDeviceRepository _devicerepository;

        public DeviceService(IConfiguration configuration, IDeviceRepository devicerepository)
        {
            _connectionstring = configuration.GetConnectionString("Defaultconnection");
            _devicerepository = devicerepository;
        }

        public DeviceResult AddNewDevice(Device device)
        {
            if (_devicerepository.DeviceCodeExists(device.DeviceCode))
            {
                return DeviceResult.FailedResult(false, "This code has been already added! Please try again with the correct code");
            }
            if (_devicerepository.DeviceNameExists(device.DeviceName))
            {
                return DeviceResult.FailedResult(false, "This name has been already used! Please try again with another name");
            }
            _devicerepository.AddNewDevice(device.DeviceCode, device.DeviceName);
            return DeviceResult.SuccessResult(true, "The new device is now added successfuly!");
        }


        public List<Device> GetAlldevices()
        {
            List<Device> devices = new();
            foreach (var devicedto in _devicerepository.GetAllDevices())
            {
                devices.Add(new Device
                {
                    DeviceId=devicedto.DeviceId,
                    DeviceCode = devicedto.DeviceCode,
                    DeviceName = devicedto.DeviceName,
                }
                    );

            }
            return devices;
        }

        public DeviceResult RemoveDevice(Device device)
        {
            _devicerepository.RemoveDevice(device.DeviceId);
            return DeviceResult.SuccessResult(true, "This device has been successfully removed");
        }

        public DeviceResult TurnOn(Device device)
        {
            var currentstatus = _devicerepository.GetDeviceSatus(device.DeviceId);
           if(currentstatus == "ON")
            {
                return DeviceResult.FailedResult(false, "This device is akready ON");
            }
            _devicerepository.TurnOnDevice(device.DeviceId);
            return DeviceResult.SuccessResult(true, "This device is now On");
        }   
        
        public DeviceResult TurnOff(Device device)
        {
            var currentstatus = _devicerepository.GetDeviceSatus(device.DeviceId);
           if(currentstatus == "OFF")
            {
                return DeviceResult.FailedResult(false, "This device is akready OFF");
            }
            _devicerepository.TurnOffDevice(device.DeviceId);
            return  DeviceResult.SuccessResult(true, "This device is now Off");
        }

        public DeviceResult SetDeviceToLocation(Device device, Location location)
        {
            _devicerepository.SetDeviceLocation(device.DeviceId,location.LocationId);
            return DeviceResult.SuccessResult(true,"This device has been added successfully!");
        }
    }
}
