using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessLayer;

namespace ServiceLayer
{
    public class LoginPresenter : ParentPresenter, ILoginPresenter
    {
        public LoginPresenter(IModel model) :base(model)
        {
            Views = new ViewsContainer();
        }
        public bool UserAuthorization()
        {
            Model.SelectedUser = Model.Users.Find(a => Views.AuthorizationView.GetLogin() == a.Login && Views.AuthorizationView.GetPassword() == a.Password);
            if (Model.SelectedUser != null) return true; else return false;
        }
        public void CreateNewUser()
        {
            User newUser = new User()
            {
                Login = Views.RegistrationView.GetLogin(),
                Password = Views.RegistrationView.GetPassword(),
                Name = Views.RegistrationView.GetName(),
                Surname = Views.RegistrationView.GetSurname()
            };
            Model.MonthlyReports = null; Model.SelectedMonthlyReport = null;
            Model.Users.Add(Model.SelectedUser = newUser);
            var elements = Elements.CreateNew();
            Model.Expenses = elements; Model.Income = elements;
            Model.CreateFolder("Data/" + Model.SelectedUser.Login);
            SaveAccount();
        }
        public bool UserRegistration()
        {
            if (Model.Users.Find(a => Views.RegistrationView.GetLogin() == a.Login) == null) return true; else return false;
        }
    }
}
