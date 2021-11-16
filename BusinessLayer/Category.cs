using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Category:BusinessObject
    {
        private String name;
        public String Name { get { return ReturnNonEmptyString(name); } set { name = value; } }
        public int Percent { get; set; }
        public double Amount { get; set; }
        public String GetStrAmount() { return AmountToString(Amount); }
        public void CalculatePercent(double totalAmount)
        {
            Percent = (int)Math.Round(100 * Amount / totalAmount);
        }
    }
}
