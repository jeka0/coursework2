using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using BusinessLayer;
using DataAccessLayer;

namespace ServiceLayer
{
    public class ApplicationWork : IPresenter
    {
        public IMainView mainView { get; set; }
        public IModel model { get; set; }
        public IAuthorizationView authorizationView { get; set; }
        public IRegistrationView registrationView { get; set; }
        public Elements Expenses, Income;
        public User SelectedUser { get; private set; }
        public List<User> users;
        public MonthlyReport SelectedMonthlyReport { get; private set; }
        public List<MonthlyReport> monthlyReports;
        public ApplicationWork(IModel model, IAuthorizationView authorView)
        {
            authorizationView = authorView;
            authorizationView.presenter = this;
            this.model = model;
            users = this.model.GetUsers();
        }
        public void LoadСategories()
        {
            Expenses = this.model.Read<Elements>("Data/" + SelectedUser.Login + "/Expenses.xml");
            if (Expenses == null) { Expenses = new Elements(); Expenses.categories.Add("Общее"); }
            Income = this.model.Read<Elements>("Data/" + SelectedUser.Login + "/Income.xml");
            if (Income == null) { Income = new Elements(); Income.categories.Add("Общее"); }
            UpdateСategories();
        }
        public void LoadMonthlyReports()
        {
            monthlyReports = this.model.Read<List<MonthlyReport>>("Data/" + SelectedUser.Login + "/MonthlyReports.xml");
            if (monthlyReports == null) monthlyReports = new List<MonthlyReport>();
            int count = monthlyReports.Count;
            if (count != 0) SelectedMonthlyReport = monthlyReports[count-1]; else 
            { 
                SelectedMonthlyReport = new MonthlyReport(); 
                SelectedMonthlyReport.Date = DateTime.Today.Month.ToString() +'.'+ DateTime.Today.Year.ToString();
                monthlyReports.Add(new MonthlyReport() { Date = (DateTime.Today.Month-1).ToString() + '.' + DateTime.Today.Year.ToString()});
                monthlyReports.Add(SelectedMonthlyReport); 
            }
        }
        public void UpdateСategories()
        {
            mainView.GetCategories().Items.AddRange(Expenses.categories.ToArray());
            mainView.GetCategories2().Items.AddRange(Income.categories.ToArray());
        }
        private Elements IdentifyElements()
        {
            int ind = mainView.GetIndx(), rec = mainView.GetRecordType();
            if (ind == 0 || (ind == 2 && rec == 1)) return Expenses; else if (ind == 1 || (ind == 2 && rec == 2)) return Income;
            else if (ind == 2 && rec == 0)
            { 
                Elements elements = new Elements();
                elements.items.AddRange(Expenses.items);
                elements.items.AddRange(Income.items);
                return elements;
            }
            else return null;
        }
        private Comparison<Item> IdentifyComparison()
        {
            if (mainView.GetSortType() == 0) return (a, b) => a.Time.CompareTo(b.Time);
            else
            if (mainView.GetSortType() == 1) return (a, b) => a.Amount.CompareTo(b.Amount); else return null;
        }
        public void CreateNewUser()
        {
            User newUser = new User() 
            { 
                Login = registrationView.GetLogin(),
                Password = registrationView.GetPassword(),
                Name = registrationView.GetName(),
                Surname = registrationView.GetSurname() 
            };
            SelectedUser = newUser;
            users.Add(newUser);
            var elements = new Elements();
            elements.categories.Add("Общее");
            Expenses = elements; Income = elements;
            model.CreateFolder("Data/" + newUser.Login);
            SaveAccount();
        }
        public bool UserAuthorization()
        {
            SelectedUser = users.Find(a => authorizationView.GetLogin() == a.Login && authorizationView.GetPassword() == a.Password);
            if (SelectedUser != null) return true; else return false;
        }
        public bool UserRegistration()
        {
            if (users.Find(a => registrationView.GetLogin() == a.Login) == null) return true; else return false;
        }
        public void UpdateUserData()
        {
            mainView.SetLogin(SelectedUser.Login);
            mainView.SetName(SelectedUser.Name);
            mainView.SetSurname(SelectedUser.Surname);
            UpdateSum();
        }
        private void AddNewElement(Item item)
        {
            var dataGridView = mainView.GetDataGridView();
            dataGridView.Rows.Add(item.Date, item.Time, item.Category, item.Comment, item.GetStrAmount());
            int count = dataGridView.Rows.Count;
            if (count != 0) dataGridView.FirstDisplayedScrollingRowIndex = count - 1;
        }
        public void UpdateElements()
        {
            mainView.GetLabel().Hide();
            Elements elements = IdentifyElements();
            Item item = new Item() 
            { 
                Date = mainView.GetDate(), 
                Time = mainView.GetTime(), 
                Category = mainView.GetCategory(), 
                Comment = mainView.GetComment(), 
                Amount = mainView.GetAmount() 
            };
            SelectedMonthlyReport.AddNote(item);
            SelectedMonthlyReport.CalculateTotalValues();
            SelectedMonthlyReport.CalculatePercents();
            SelectedMonthlyReport.Sort();
            SelectedUser.CalculateBalance(item.Amount);
            elements.items.Add(item);
            AddNewElement(item);
        }
        public void UpdateCharts()
        {
            int ind = mainView.GetReportType();
            Chart generalSchedule = mainView.GetGeneralSchedule(), categoryChart = mainView.GetCategoryChart();
            var tabels = mainView.GetDataGridViewReports();
            generalSchedule.Series[0].Points.Clear(); categoryChart.Series[0].Points.Clear();
            tabels[0].Rows.Clear(); tabels[1].Rows.Clear();
            double oldValue=0;
            foreach (var item in monthlyReports) 
            {
                double value = item.GetTotalAmount(ind);
                Bitmap picture;
                if (value < oldValue) picture = Properties.Resource.Down; else picture = Properties.Resource.Up;
                generalSchedule.Series[0].Points.AddXY(item.Date, Convert.ToInt32(value));
                tabels[1].Rows.Add(item.Date, picture,"на " + item.AmountToString(value - oldValue), item.AmountToString(value));
                oldValue = value;
            }
            tabels[1].Sort(tabels[1].Columns[0],System.ComponentModel.ListSortDirection.Descending);
            foreach (var item in SelectedMonthlyReport.GetTotalList(ind))
            {
                categoryChart.Series[0].Points.AddXY(item.category, Convert.ToInt32(item.amount));
                tabels[0].Rows.Add(item.category,item.percent + " %",item.AmountToString(item.amount));
            }
        }
        public void UpdateHistory()
        {
            if (mainView.GetIndx()==2)
            {
                var dataGridView = mainView.GetDataGridView();
                dataGridView.Rows.Clear();
                List<Item> items = IdentifyElements().FindItemsByDate(mainView.GetDate());
                if (items.Count == 0) mainView.GetLabel().Show(); else mainView.GetLabel().Hide();
                items.Sort(IdentifyComparison());
                foreach (Item item in items) AddNewElement(item);
            }
        }
        public void LoadElements()
        {
            Elements elements= IdentifyElements();
            int i = 0, count = elements.items.Count;
            if (count > 0) { mainView.GetLabel().Hide(); if (count > 23) i = count - 23; }
            for (; i < count; i++)AddNewElement(elements.items[i]);
        }
        public bool CheckCategories()
        {
            return IdentifyElements().CheckCategories(mainView.GetNewCategory());
        }
        public void AddCategory()
        {
            IdentifyElements().categories.Add(mainView.GetNewCategory());
        }
        public void UpdateSum()
        {
            mainView.SetSum(SelectedUser.GetStrAmount());
        }
        public void SaveAccount()
        {
            model.Save<List<User>>("Data/accounts.xml", users);
            model.Save<List<MonthlyReport>>("Data/" + SelectedUser.Login + "/MonthlyReports.xml", monthlyReports);
            model.Save<Elements>("Data/" + SelectedUser.Login + "/Expenses.xml", Expenses);
            model.Save<Elements>("Data/" + SelectedUser.Login + "/Income.xml", Income);
        }
    }
}
