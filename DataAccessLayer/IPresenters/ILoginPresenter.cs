using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ILoginPresenter
    {
        ViewsContainer Views { get; set; }
        void CreateNewUser();
        bool UserAuthorization();
        bool UserRegistration();
        bool ValidateString(String str);
    }
}
