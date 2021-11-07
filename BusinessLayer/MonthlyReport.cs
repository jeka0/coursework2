using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MonthlyReport : BusinessObject
    {
        public String Date;
        public List<(String category, double amount)> TotalIncome = new List<(String category, double amount)>();
        public List<(String category, double amount)> TotalExpenses = new List<(String category, double amount)>();
    }
}
