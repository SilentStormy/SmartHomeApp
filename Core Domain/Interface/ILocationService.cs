using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Interface
{
    public interface ILocationService
    {
        List<Location> GetAllLocations();
    }
}
