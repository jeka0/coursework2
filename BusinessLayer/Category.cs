using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Category:BusinessObject
    {
        public String category;
        public int percent;
        public double amount;
        public void CalculatePercent(double totalAmount)
        {
            percent = (int)(100 * amount / totalAmount);
        }
    }
}
