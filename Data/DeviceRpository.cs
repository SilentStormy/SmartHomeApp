using Infrastructure.Data.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DeviceRpository : IDeviceRepository
    {
        private readonly string _connectionstring;

        public DeviceRpository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }
        public void AddNewDevice(string deviceCode, string deviceName)
        {
           
            using SqliteConnection con = new(_connectionstring);
            con.Open();
            using SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Device(DeviceCode, DeviceName) VALUES (@DeviceCode,@DeviceName)";
            cmd.Parameters.AddWithValue("@DeviceCode", deviceCode);
            cmd.Parameters.AddWithValue("@DeviceName", deviceName);
            cmd.ExecuteNonQuery();

    }
    }
}
