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
        private TextBox[] Old = new TextBox[2] { null, null };
        private int[] index = new int[2] { 10, 10 };
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
            int ind = mainView.GetIndx();
            if (ind == 0) return Expenses; else if (ind == 1) return Income;
            return null;
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
            TextBox[] textBoxes = new TextBox[5];
            for (int i = 0; i < 5; i++)
            {
                textBoxes[i] = new TextBox();
                textBoxes[i].BackColor = Color.FromArgb(45, 45, 48);
                textBoxes[i].ForeColor = Color.White;
                textBoxes[i].Font = new Font(textBoxes[i].Font.Name, 11, textBoxes[i].Font.Style, textBoxes[i].Font.Unit);
                textBoxes[i].BorderStyle = BorderStyle.FixedSingle;
                textBoxes[i].ReadOnly = true;
                switch (i)
                {
                    case 0: textBoxes[i].Size = new Size(97, 24); point.X = 17; textBoxes[i].Text = item.Date; break;
                    case 1: textBoxes[i].Size = new Size(97, 24); point.X = 120; textBoxes[i].Text = item.Time; break;
                    case 2: textBoxes[i].Size = new Size(165, 24); point.X = 223; textBoxes[i].Text = item.Category; break;
                    case 3: textBoxes[i].Size = new Size(291, 24); point.X = 394; textBoxes[i].Text = item.Comment; break;
                    case 4: textBoxes[i].Size = new Size(115, 24); point.X = 691; textBoxes[i].Text = item.GetStrAmount(); break;
                }
                textBoxes[i].Location = point;
            }
            Screen.Controls.AddRange(textBoxes);
            Screen.ScrollControlIntoView(textBoxes[0]);
            Old[ind] = textBoxes[0];
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
