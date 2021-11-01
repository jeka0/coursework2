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
        public Elements Expenses;
        public Elements Income;
        public User SelectedUser { get; private set; }
        public List<User> users;
        private TextBox[] Old = new TextBox[2] { null, null };
        private int[] index = new int[2] { 10, 10 };
        public ApplicationWork(IModel model, IAuthorizationView authorView/*, IMainView mView, IAuthorizationView authorView, IRegistrationView regView*/)
        {
            /*mainView = mView;
            mainView.presenter = this;
            authorizationView = authorView;
            authorizationView.presenter = this;
            registrationView = regView;
            registrationView.presenter = this;*/
            authorizationView = authorView;
            authorizationView.presenter = this;
            this.model = model;
            users = this.model.GetUsers;
        }
        public void LoadСategories()
        {
            Expenses = this.model.ReadElementsXml("Data/" + SelectedUser.Login + "/Expenses.xml");
            Income = this.model.ReadElementsXml("Data/" + SelectedUser.Login + "/Income.xml");
            UpdateСategories();
        }
        public void UpdateСategories()
        {
            mainView.GetCategories.Items.AddRange(Expenses.categories.ToArray());
            mainView.GetCategories2.Items.AddRange(Income.categories.ToArray());
        }

        public void CreateNewUser()
        {
            User newUser = new User() 
            { 
                Login = registrationView.GetLogin,
                Password = registrationView.GetPassword,
                Name = registrationView.GetName,
                Surname = registrationView.GetSurname 
            };
            SelectedUser = newUser;
            users.Add(newUser);
            model.SaveXml<List<User>>("Data/accounts.xml", users);
            var elements = new Elements();
            elements.categories.Add("Общее");
            model.CreateFolder("Data/" + newUser.Login);
            model.SaveXml<Elements>("Data/" + newUser.Login + "/Expenses.xml", elements);
            model.SaveXml<Elements>("Data/" + newUser.Login + "/Income.xml", elements);
        }
        public bool UserAuthorization()
        {
            foreach (User user in users) { if (authorizationView.GetLogin == user.Login && authorizationView.GetPassword == user.Password) { SelectedUser = user; return true; } }
            return false;
        }
        public bool UserRegistration()
        {
            foreach (User user in users) { if (registrationView.GetLogin == user.Login) return false; }
            return true;
        }
        public void UpdateUserData()
        {
            mainView.SetLogin = SelectedUser.Login;
            mainView.SetName = SelectedUser.Name;
            mainView.SetSurname = SelectedUser.Surname;
        }
        public void AddNewElement(Item item)
        {
            int ind = mainView.GetIndx;
            Panel Screen = mainView.GetScreen;
            Point point = new Point(0, index[ind]);
            if (Old != null) Screen.ScrollControlIntoView(Old[ind]);
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
                    case 4: textBoxes[i].Size = new Size(115, 24); point.X = 691; textBoxes[i].Text = item.Amount + " руб."; break;
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
            mainView.GetLabel.Hide();
            Elements elements=null;String file = null;
            int ind = mainView.GetIndx;
            if (ind == 0) { elements = Expenses; file = "Data/" + SelectedUser.Login + "/Expenses.xml"; } else if (ind == 1) { elements = Income;file = "Data/" + SelectedUser.Login + "/Income.xml"; }
            Item item = new Item() { Date = mainView.GetDate, Time = mainView.GetTime, Category = mainView.GetCategory, Comment = mainView.GetComment, Amount = mainView.GetAmount };
            elements.items.Add(item);
            AddNewElement(item);
            model.SaveXml<Elements>(file,elements);
        }
        public void LoadElements()
        {
            mainView.GetLabel.Hide();
            Elements elements=null;
            int ind = mainView.GetIndx;
            if (ind == 0) elements = Expenses; else if (ind == 1) elements = Income;
            List<Item> list = elements.items;
            for (int i = 0; i < list.Count && i<23;i++)
            {
                AddNewElement(list[i]);
            }
        }
        public bool CheckCategories()
        {
            Elements elements = null;
            int ind = mainView.GetIndx;
            if (ind == 0) elements = Expenses; else if (ind == 1) elements = Income;
            bool Flag = false;
            for (int i = 0; i < elements.categories.Count; i++)
            {
                if (mainView.GetNewCategory == elements.categories[i].ToString()) { Flag = true; break; }
            }
            return Flag;
        }
        public void AddCategory()
        {
            Elements elements = null; String file = null;
            int ind = mainView.GetIndx;
            if (ind == 0) { elements = Expenses; file = "Data/" + SelectedUser.Login + "/Expenses.xml"; } else if (ind == 1) { elements = Income; file = "Data/" + SelectedUser.Login + "/Income.xml"; }
            elements.categories.Add(mainView.GetNewCategory);
            model.SaveXml<Elements>(file, elements);

        }
    }
}
