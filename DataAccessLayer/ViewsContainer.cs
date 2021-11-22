using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ViewsContainer
    {
        public IMainView MainView { get; set; }
        public IAuthorizationView AuthorizationView { get; set; }
        public IRegistrationView RegistrationView { get; set; }
    }
}
