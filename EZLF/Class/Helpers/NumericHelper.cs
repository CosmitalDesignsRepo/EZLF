using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZLF.Class.Helpers
{
    public static class NumericHelper
    {
        public static int IntParse(this object num, int ret = 0)
        {
            int result = 0;
            if (num is int)
                return (int)num;

            if (num != null && int.TryParse(num.ToString(), out result))
                return result;
            return ret;
        }

        public static double DoubleParse(this object num, double ret = 0)
        {
            double result = 0;
            if (num != null && double.TryParse(num.ToString(), out result))
                return result;

            return ret;
        }

        public static float FloatParse(this object num, float ret = 0)
        {
            float result = 0;
            if (num != null && float.TryParse(num.ToString(), out result))
                return result;

            return ret;
        }

        public static decimal DecimalParse(this object num, decimal ret = 0)
        {
            decimal result = 0;
            if (decimal.TryParse(num.ToString(), out result))
                return result;

            return ret;
        }
    }
}