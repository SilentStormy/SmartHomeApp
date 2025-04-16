

using Infrastructure.Data.DTO;
using Infrastructure.Data.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Data
{
    public class DeviceRpository : IDeviceRepository
    {
        private readonly string _connectionstring;

        public DeviceRpository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("Defaultconnection");
        }
        public void AddNewDevice(string deviceCode, string deviceName)
        {

            using SqliteConnection con = new(_connectionstring);
            con.Open();
            using SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Device (DeviceCode, DeviceName) VALUES (@DeviceCode,@DeviceName)";
            cmd.Parameters.AddWithValue("@DeviceCode", deviceCode);
            cmd.Parameters.AddWithValue("@DeviceName", deviceName);
            cmd.ExecuteNonQuery();
        
    }

        public bool DeviceCodeExists(string deviceCode)
        {
            using SqliteConnection connection = new(_connectionstring);
            connection.Open();
            using SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT 1 FROM Device WHERE DeviceCode=@DeviceCode";
            cmd.Parameters.AddWithValue("@DeviceCode",deviceCode);
            var result =cmd.ExecuteScalar();
            return result !=null;
        } 
        public bool DeviceNameExists(string deviceName)
        {
            using SqliteConnection connection = new(_connectionstring);
            connection.Open();
            using SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT 1 FROM Device WHERE DeviceName=@DeviceName";
            cmd.Parameters.AddWithValue("@DeviceName",deviceName);
            var result =cmd.ExecuteScalar();
            return result !=null;
        }

        public List<DeviceDTO> GetAllDevices()

        {
            List<DeviceDTO> devices = new();
            using SqliteConnection conn = new(_connectionstring);   
            conn.Open();
            using SqliteCommand cmd=conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Device";
            using SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                devices.Add(new DeviceDTO
                {
                    DeviceId = Convert.ToInt32(reader["DeviceId"]),
                    DeviceCode = reader["DeviceCode"].ToString(),
                    DeviceName = reader["DeviceName"].ToString()
                });
            }
            return devices;

        }

        public string GetDeviceSatus(int deviceId)
        {
            using SqliteConnection connection = new(_connectionstring);
            connection.Open();
            using SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT DeviceStatus FROM Device WHERE DeviceId=@DeviceId";
            cmd.Parameters.AddWithValue("@DeviceId", deviceId);
            var result = cmd.ExecuteScalar();
            return result.ToString();
                
                
        }

        public void RemoveDevice(int deviceId)
        {
            using SqliteConnection connection= new(_connectionstring);
            connection.Open();
            using SqliteCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Device WHERE DeviceId=@DeviceId";
            command.Parameters.AddWithValue("@DeviceId", deviceId);
            command.ExecuteNonQuery();
        }

        public void TurnOnDevice(int deviceId)
        {
           using SqliteConnection con = new(_connectionstring);
            con.Open();
            using SqliteCommand cmd= con.CreateCommand();
            cmd.CommandText = "UPDATE Device SET DeviceStatus ='ON' WHERE DeviceId= @DeviceId";
            cmd.Parameters.AddWithValue("@DeviceId",deviceId);
            cmd.ExecuteNonQuery();
        }

        public void TurnOffDevice(int deviceId)
        {
            using SqliteConnection con = new(_connectionstring);
            con.Open();
            using SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Device SET DeviceStatus ='OFF' WHERE DeviceId= @DeviceId";
            cmd.Parameters.AddWithValue("@DeviceId", deviceId);
            cmd.ExecuteNonQuery();
        }

        public void SetDeviceLocation(int deviceId, int locationId)
        {
            using SqliteConnection conn= new(_connectionstring);
            conn.Open();
            using SqliteCommand cmd=conn.CreateCommand();
            cmd.CommandText = "UPDATE Device SET LocationId=@LocationId WHERE DeviceId=@DeviceId";
            cmd.Parameters.AddWithValue("@LocationId", locationId);
            cmd.Parameters.AddWithValue("@DeviceId", deviceId);
            cmd.ExecuteNonQuery();

        }
    }
}
