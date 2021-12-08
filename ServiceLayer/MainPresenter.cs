using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataAccessLayer;

namespace ServiceLayer
{
    public class MainPresenter : ParentPresenter, IMainPresenter
    {
        public MainPresenter(IModel model):base(model)
        {
            Views = new ViewsContainer();
        }
        public void UpdateСategories()
        {
            var categories = Views.MainView.GetCategories();
            categories.Items.Clear();
            categories.Items.AddRange(IdentifyElements().categories.ToArray());
            categories.Text = categories.Items[0].ToString();
        }
        public void UpdateUserData()
        {
            Views.MainView.SetLogin(Model.SelectedUser.Login);
            Views.MainView.SetName(Model.SelectedUser.Name);
            Views.MainView.SetSurname(Model.SelectedUser.Surname);
            UpdateSum();
        }
        private void AddNewElement(Item item)
        {
            var dataGridView = Views.MainView.GetDataGridView();
            dataGridView.Rows.Add(item.Date, item.Time, item.Category, item.Comment, item.GetStrAmount());
            int count = dataGridView.Rows.Count;
            if (count != 0) dataGridView.FirstDisplayedScrollingRowIndex = count - 1;
            dataGridView.ClearSelection();
        }
        public void UpdateElements()
        {
            Views.MainView.GetLabel().Hide();
            Item item = new Item() 
            { 
                Date = Views.MainView.GetDate(), 
                Time = Views.MainView.GetTime(), 
                Category = Views.MainView.GetCategory(), 
                Comment = Views.MainView.GetComment(), 
                Amount = IdentifyAmount()
            };
            Model.SelectedMonthlyReport.AddNote(item);
            Model.SelectedUser.CalculateBalance(item.Amount);
            IdentifyElements().items.Add(item);
            AddNewElement(item);
        }
        public void UpdateCharts()
        {
            SupportingWork.mainView = Views.MainView;
            SupportingWork.FillInMonthlyReport(Model.MonthlyReports);
            SupportingWork.FillInCategoryReport(Model.SelectedMonthlyReport.GetTotalList(Views.MainView.GetReportType()));
            Views.MainView.SetMonthlyAmount(Model.SelectedMonthlyReport.TotalAmountToString());
        }
        public void UpdateHistory()
        {
            if (Views.MainView.GetIndx()==2)
            {
                var dataGridView = Views.MainView.GetDataGridView();
                dataGridView.Rows.Clear();
                List<Item> items = IdentifyElements().FindItemsByDate(Views.MainView.GetDate());
                if (items.Count == 0) Views.MainView.GetLabel().Show(); else Views.MainView.GetLabel().Hide();
                items.Sort(IdentifyComparison());
                foreach (Item item in items) AddNewElement(item);
                Views.MainView.SetAmountPerDay(Model.SelectedUser.AmountToString(items.Sum(item => item.Amount)));
            }
        }
        public void LoadElements()
        {
            Elements elements= IdentifyElements();
            int i = 0, count = elements.items.Count;
            if (count > 0) { Views.MainView.GetLabel().Hide(); if (count > 23) i = count - 23; }
            for (; i < count; i++)AddNewElement(elements.items[i]);
        }
        public bool CheckCategories()
        {
            return IdentifyElements().CheckCategories(Views.MainView.GetNewCategory());
        }
        public void AddCategory()
        {
            IdentifyElements().categories.Add(Views.MainView.GetNewCategory());
        }
        public void UpdateSum()
        {
            Views.MainView.SetSum(Model.SelectedUser.GetStrAmount());
        }
        public bool ValidateAmount()
        {
            return BusinessObject.ValidateAmount(Views.MainView.GetAmount());
        }
    }
}
