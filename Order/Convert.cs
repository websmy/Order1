using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Order
{
    public static class Convert
    {

        public static double ToDouble(object val)
        {
            double result = 0;
            try
            {
                result = System.Convert.ToDouble(val);
            }
            catch (Exception)
            {
                result = 0;
            }

            return result;
        }

        public static int ToInt32(object val)
        {
            int result = 0;
            try
            {
                result = System.Convert.ToInt32(val);
            }
            catch (Exception)
            {
                result = 0;
            }

            return result;
        }


    }
}