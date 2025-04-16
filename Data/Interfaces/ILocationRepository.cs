using Infrastructure.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Interfaces
{
    public interface ILocationRepository
    {
        List<LocationDTO> GetAllLocations();

    }
}
