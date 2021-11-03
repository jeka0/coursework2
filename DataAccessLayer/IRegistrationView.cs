using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRegistrationView
    {
        IPresenter presenter { get; set; }
        String GetLogin();
        String GetPassword();
        String GetSurname();
        String GetName();
    }
}
