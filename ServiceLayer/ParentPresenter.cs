using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessLayer;

namespace ServiceLayer
{
    public class ParentPresenter
    {
        public ViewsContainer Views { get; set; }
        public IModel Model { get; set; }
        public ParentPresenter(IModel model)
        {
            Model = model;
        }
        public void LoadСategories()
        {
            Model.Expenses = this.Model.Read<Elements>("Data/" + Model.SelectedUser.Login + "/Expenses.xml");
            if (Model.Expenses == null) Model.Expenses = Elements.CreateNew();
            Model.Income = this.Model.Read<Elements>("Data/" + Model.SelectedUser.Login + "/Income.xml");
            if (Model.Income == null) Model.Income = Elements.CreateNew();
        }
        public void LoadMonthlyReports()
        {
            Model.MonthlyReports = this.Model.Read<List<MonthlyReport>>("Data/" + Model.SelectedUser.Login + "/MonthlyReports.xml");
            if (Model.MonthlyReports == null) Model.MonthlyReports = new List<MonthlyReport>();
            int count = Model.MonthlyReports.Count;
            if (count != 0) { if (Model.MonthlyReports[count - 1].Date != MonthlyReport.GetDate()) Model.MonthlyReports.Add(Model.SelectedMonthlyReport = MonthlyReport.CreateNew()); else Model.SelectedMonthlyReport = Model.MonthlyReports[count - 1]; }
            else Model.MonthlyReports.Add(Model.SelectedMonthlyReport = MonthlyReport.CreateNew()); 
        }
        public Elements IdentifyElements()
        {
            int ind = Views.MainView.GetIndx(), rec = Views.MainView.GetRecordType();
            if (ind == 0 || (ind == 2 && rec == 1)) return Model.Expenses;
            else if (ind == 1 || (ind == 2 && rec == 2)) return Model.Income;
            else if (ind == 2 && rec == 0)
            {
                Elements elements = new Elements();
                elements.items.AddRange(Model.Expenses.items);
                elements.items.AddRange(Model.Income.items);
                return elements;
            }
            else return null;
        }
        public Comparison<Item> IdentifyComparison()
        {
            if (Views.MainView.GetSortType() == 0) return (a, b) => a.Time.CompareTo(b.Time);
            else
            if (Views.MainView.GetSortType() == 1) return (a, b) => a.Amount.CompareTo(b.Amount); else return null;
        }
        public double IdentifyAmount()
        {
            int indx = Views.MainView.GetIndx();
            if (indx == 0) return Convert.ToDouble(Views.MainView.GetAmount()) * (-1); else if (indx == 1) return Convert.ToDouble(Views.MainView.GetAmount()); else return 0;
        }
        public void DeleteAccount()
        {
            Model.DeleteFile("Data/" + Model.SelectedUser.Login + "/MonthlyReports.xml");
            Model.DeleteFile("Data/" + Model.SelectedUser.Login + "/Expenses.xml");
            Model.DeleteFile("Data/" + Model.SelectedUser.Login + "/Income.xml");
            Model.DeleteFolder("Data/" + Model.SelectedUser.Login);
            Model.Users.Remove(Model.SelectedUser);
            Model.Save<List<User>>("Data/accounts.xml", Model.Users);
            Model.SelectedUser = null;
        }
        public void SaveAccount()
        {
            Model.Save<List<User>>("Data/accounts.xml", Model.Users);
            Model.CreateFolder("Data/" + Model.SelectedUser.Login);
            Model.Save<List<MonthlyReport>>("Data/" + Model.SelectedUser.Login + "/MonthlyReports.xml", Model.MonthlyReports);
            Model.Save<Elements>("Data/" + Model.SelectedUser.Login + "/Expenses.xml", Model.Expenses);
            Model.Save<Elements>("Data/" + Model.SelectedUser.Login + "/Income.xml", Model.Income);
        }
        public bool ValidateString(String str)
        {
            return !BusinessObject.ValidateIsNullOrEmpty(str);
        }
    }
}
