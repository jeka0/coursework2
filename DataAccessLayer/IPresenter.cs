using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public interface IPresenter
    {
        IMainView mainView { get; set; }
        IAuthorizationView authorizationView { get; set; }
        IRegistrationView registrationView { get; set; }
        void CreateNewUser();
        bool UserAuthorization();
        bool UserRegistration();
        void UpdateUserData();
        void UpdateСategories();
        void LoadСategories();
        void LoadMonthlyReports();
        void UpdateElements();
        void LoadElements();
        bool CheckCategories();
        void AddCategory();
        void UpdateSum();
        void SaveAccount();
        void UpdateHistory();
        void UpdateCharts();
    }
}
