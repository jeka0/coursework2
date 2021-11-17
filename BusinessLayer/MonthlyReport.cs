using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MonthlyReport : BusinessObject
    {
        private String date;
        public String Date { get { return ReturnNonEmptyString(date); } set { date = value; } }
        public List<Category> TotalIncome = new List<Category>();
        public List<Category> TotalExpenses = new List<Category>();
        public double AmountTotalIncome { get; set; }
        public double AmountTotalExpenses { get; set; }
        public void AddNote(Item item)
        {
            List<Category> list; int indx;
            if (item.Amount > 0) { list = TotalIncome; indx = 0; } else { list = TotalExpenses; indx = 1; }
            var oldItem = list.Find(a => a.Name == item.Category);
            if (oldItem != null) oldItem.Amount += item.Amount;
            else list.Add(new Category() { Name = item.Category, Amount = item.Amount });
            CalculateTotalValues(indx);
            CalculatePercents(indx);
            Sort(indx);
        }
        public void Sort(int indx)
        {
            if(indx==0) TotalIncome.Sort((a, b) => b.Amount.CompareTo(a.Amount));
            else TotalExpenses.Sort((a, b) => a.Amount.CompareTo(b.Amount));
        }
        public void CalculateTotalValues(int indx)
        {
            if(indx == 0) AmountTotalIncome = TotalIncome.Sum(a=>a.Amount);
            else AmountTotalExpenses = TotalExpenses.Sum(a=>a.Amount);
        }
        public void CalculatePercents(int indx)
        {
            if(indx == 0) foreach (var item in TotalIncome) item.CalculatePercent(AmountTotalIncome);
            else foreach (var item in TotalExpenses) item.CalculatePercent(AmountTotalExpenses);
        }
        public double GetTotalAmount(int index) { if (index == 0) return AmountTotalIncome; else return AmountTotalExpenses; }
        public List<Category> GetTotalList(int index) { if (index == 0) return TotalIncome; else return TotalExpenses; }
    }   
}
