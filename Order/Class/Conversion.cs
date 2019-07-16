using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Order
{
    public static class con
    {
        public static double FttoM(double input, int indexSelect)
        {
            switch (indexSelect)
            {
                case 0:
                    return input;

                case 1:
                    return (input * 0.3048);
            }
            return 0.0;
        }

        public static double TemperConvert(double input, int indexSelect)
        {
            switch (indexSelect)
            {
                case 0:
                    return input;

                case 1:
                    return (((5.0 * (input - 50.0)) / 9.0) + 10.0);
            }
            return 0.0;
        }





    }
}