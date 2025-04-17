using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Entities
{
    public class Location
    {
        private int locationId;
        private string locationName;
        public int LocationId
        {
            get { return locationId; }
            set { locationId = value; }
        }

        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }
    }
}
