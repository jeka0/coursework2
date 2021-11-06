using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private Label[] Old = new Label[3] { null, null, null };
        private int[] index = new int[3] { 10, 10, 10 };
        public ApplicationWork(IModel model, IAuthorizationView authorView)
        {
            authorizationView = authorView;
            authorizationView.presenter = this;
            this.model = model;
            users = this.model.GetUsers();
        }
        public void LoadСategories()
        {
            Expenses = this.model.ReadElements("Data/" + SelectedUser.Login + "/Expenses.xml");
            Income = this.model.ReadElements("Data/" + SelectedUser.Login + "/Income.xml");
            UpdateСategories();
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
            int ind = mainView.GetIndx();
            Panel Screen = mainView.GetScreen();
            Point point = new Point(0, index[ind]);
            if (Old[ind] != null) Screen.ScrollControlIntoView(Old[ind]);
            Label[] labels = new Label[5];
            for (int i = 0; i < 5; i++)
            {
                labels[i] = new Label();
                labels[i].BackColor = Color.FromArgb(45, 45, 48);
                labels[i].ForeColor = Color.White;
                labels[i].Font = new Font(labels[i].Font.Name, 11, labels[i].Font.Style, labels[i].Font.Unit);
                labels[i].BorderStyle = BorderStyle.FixedSingle;
                switch (i)
                {
                    case 0: labels[i].Size = new Size(97, 24); point.X = 17; labels[i].Text = item.Date; break;
                    case 1: labels[i].Size = new Size(97, 24); point.X = 120; labels[i].Text = item.Time; break;
                    case 2: labels[i].Size = new Size(165, 24); point.X = 223; labels[i].Text = item.Category; break;
                    case 3: labels[i].Size = new Size(291, 24); point.X = 394; labels[i].Text = item.Comment; break;
                    case 4: labels[i].Size = new Size(115, 24); point.X = 691; labels[i].Text = item.GetStrAmount(); break;
                }
                labels[i].Location = point;
            }
            Screen.Controls.AddRange(labels);
            Screen.ScrollControlIntoView(labels[0]);
            Old[ind] = labels[0];
            if (index[ind] < 430) index[ind] += 30; else if (index[ind] == 430) index[ind] += 13;
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
            SelectedUser.CalculateBalance(item.Amount);
            elements.items.Add(item);
            AddNewElement(item);
        }
        public void UpdateHistory()
        {
            if (mainView.GetIndx()==2)
            {
                Panel Screen = mainView.GetScreen();
                index[2] = 10; Old[2] = null;
                if (Screen.Controls.Count > 0) Screen.ScrollControlIntoView(Screen.Controls[0]);
                Screen.Controls.Clear();
                List<Item> items = IdentifyElements().FindItemsByDate(mainView.GetDate());
                items.Sort(IdentifyComparison());
                if (items.Count == 0) Screen.Controls.Add(mainView.GetLabel());
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
            model.Save<Elements>("Data/" + SelectedUser.Login + "/Expenses.xml", Expenses);
            model.Save<Elements>("Data/" + SelectedUser.Login + "/Income.xml", Income);
        }
    }
}
