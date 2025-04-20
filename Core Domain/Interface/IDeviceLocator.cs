using Core_Domain.Entities;
using Core_Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Interface
{
    public interface IDeviceLocator
    {
        DeviceResult SetDeviceToLocation(Device device, Location location);
    }
}
