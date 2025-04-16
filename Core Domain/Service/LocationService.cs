using Core_Domain.Interface;
using Infrastructure.Data.DTO;
using Infrastructure.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Service
{
    public class LocationService : ILocationService
    {
        private readonly string _connectionstring;

        private readonly ILocationRepository _locationRepository;

        public LocationService(IConfiguration configuration, ILocationRepository locationRepository)
        {
            _connectionstring = configuration.GetConnectionString("Defaultconnection");
            _locationRepository = locationRepository;
        }
        public List<Location> GetAllLocations()
        {
           List<Location> locations = new();
            foreach(var location in _locationRepository.GetAllLocations())
            {
                locations.Add(new Location
                {
                    LocationId = location.LocationId,
                    LocationName = location.LocationName,

                });
            }
            return locations;
        }
    }
}
