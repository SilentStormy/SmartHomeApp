using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Result
{
    public class DeviceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static DeviceResult SuccessResult(bool success, string message)
        {
            return new DeviceResult
            {
                Success = true,
                Message = message
            };
        }

        public static DeviceResult FailedResult(bool success, string message)
        {
            return new DeviceResult
            {
                Success = false,
                Message = message
            };
        }
    }
}
