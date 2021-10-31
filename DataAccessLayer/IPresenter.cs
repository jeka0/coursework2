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
        //bool CheckCategories(String categorie, ComboBox categories);
        //void AddNewElement(String login, ref TextBox Old, ref int index, Panel Screen, String DateStr, String TimeStr, String Categories, String Comment, String Amount, String file, bool Flag);
    }
}
