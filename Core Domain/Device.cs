using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain
{
    public class Device
    {
        private int deviceId;
        private string devicecode;
        private string devicename;
        private string devicestatus;

        public int DeviceId
        {
            get { return deviceId; }
            set { deviceId = value; }
        }
        public string DeviceCode
        {
            get { return devicecode; }
            set { devicecode = value; }
        }
        public string DeviceName
        {
            get { return devicename; }
            set { devicename = value; }

        }
        public string DeviceStatus
        {
            get { return devicestatus; }
            set { devicestatus = value; }
        }
    }
}

