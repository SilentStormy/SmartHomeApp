using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Entities
{
    public class Lightening : Device
    {
        private int brightness;
        private int colortemperature;

        public int Brightness
        {
            get { return brightness; }
            set { brightness = value; }
        }
        public int Colortemperature
        {
            get { return colortemperature; }
            set { colortemperature = value; }
        }


    }

}
