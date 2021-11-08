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
            List<Category> list;
            if (item.Amount > 0) list = TotalIncome; else list = TotalExpenses;
            var oldItem = list.Find(a => a.category == item.Category);
            if (oldItem != null) oldItem.amount += item.Amount;
            else
                list.Add(new Category() { category = item.Category, amount = item.Amount });
        }
        public void Sort()
        {
            TotalIncome.Sort((a, b) => b.amount.CompareTo(a.amount));
            TotalExpenses.Sort((a, b) => a.amount.CompareTo(b.amount));
        }
        public void CalculateTotalValues()
        {
            AmountTotalIncome = 0; AmountTotalExpenses = 0;
            foreach (var item in TotalIncome) AmountTotalIncome += item.amount;
            foreach (var item in TotalExpenses) AmountTotalExpenses += item.amount;
        }
        public void CalculatePercents()
        {
            foreach (var item in TotalIncome) item.percent = (int)(100 * item.amount / AmountTotalIncome);
            foreach (var item in TotalExpenses) item.percent = (int)(100 * item.amount / AmountTotalExpenses);
        }
        public double GetTotalAmount(int index) { if (index == 0) return AmountTotalIncome; else return AmountTotalExpenses; }
        public List<Category> GetTotalList(int index) { if (index == 0) return TotalIncome; else return TotalExpenses; }
    }   
}
