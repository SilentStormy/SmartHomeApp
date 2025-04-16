using Infrastructure.Data.DTO;
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
    public class LocationRepository : ILocationRepository
    {

        private readonly string _connectionstring;
        public LocationRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("Defaultconnection");
        }

        public List<LocationDTO> GetAllLocations()
        {
            List<LocationDTO> locations = new();
            using SqliteConnection connection = new SqliteConnection(_connectionstring);
            connection.Open();
            using SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Location";
            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                locations.Add(new LocationDTO
                {
                    LocationName = reader["LocationName"].ToString()
                });
                
            }
            return locations;
        }
    }
}
