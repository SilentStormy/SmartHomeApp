using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Entities
{
    public class Cooling : Device
    {
        private float temperatue;

        public float Temperatue
        {
            get { return temperatue; }
            set { temperatue = value; }
        }


    }
}
