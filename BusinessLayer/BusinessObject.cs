﻿using System;
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
            if (value < 1000 && value > -1000) return value.ToString("0.##") + " руб.";
            else
                if (value < 1000000 && value > -1000000) { value /= 1000.00; return value.ToString("0.##") + " тыс."; }
            else
                if (value < 1000000000 && value > -1000000000) { value /= 1000000.00; return value.ToString("0.##") + " мил."; }
            else
                return value.ToString("0.# +E0") + " руб.";
        }
    }
}