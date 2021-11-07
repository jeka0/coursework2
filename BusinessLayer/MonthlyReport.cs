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
        public List<Category> TotalIncome = new List<Category>();
        public List<Category> TotalExpenses = new List<Category>();
        public double AmountTotalIncome;
        public double AmountTotalExpenses;
        public void AddNote(Item item)
        {
            if (item.Amount > 0)
            {
                var oldItem = TotalIncome.Find(a => a.category == item.Category);
                if (oldItem!=null) oldItem.amount += item.Amount;
                else
                    TotalIncome.Add(new Category() { category = item.Category, amount = item.Amount });
            }
            else TotalExpenses.Add(new Category() {category = item.Category,amount = item.Amount });
        }
        public void CalculateTotalValues()
        {
            AmountTotalIncome = 0; AmountTotalExpenses = 0;
            foreach (var item in TotalIncome) AmountTotalIncome += item.amount;
            foreach (var item in TotalExpenses) AmountTotalExpenses += item.amount;
        }
    }
}
