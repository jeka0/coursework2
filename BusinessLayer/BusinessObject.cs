using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessObject
    {
        public String AmountToString(double value)
        {
            if (value < 1000000000 && value > -1000000000) return value.ToString("0.##") + " руб.";
            else return value.ToString("0.# +E0") + " руб.";
        }
        public int ConvertToInt32(double value)
        {
            if (value > int.MaxValue) return int.MaxValue; else if (value < int.MinValue) return int.MinValue; else return Convert.ToInt32(value);
        }
        public String ReturnNonEmptyString(String str)
        {
            if (ValidateIsNullOrEmpty(str)) return "Unknown"; else return str;
        }
        static public bool ValidateAmount(String value)
        {
            return Double.TryParse(value, out double amount) && amount > 0;
        }
        static public bool ValidateIsNullOrEmpty(String value)
        {
            return String.IsNullOrEmpty(value);
        }
    }
}
