using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User : BusinessObject
    {
        private String login;
        private String password;
        private String surname;
        private String name;
        public String Login { get { return ReturnNonEmptyString(login); } set { login = value; } }
        public String Password { get { return ReturnNonEmptyString(password); } set { password = value; } }
        public String Surname { get { return ReturnNonEmptyString(surname); } set { surname = value; } }
        public String Name { get { return ReturnNonEmptyString(name); } set { name = value; } }
        public double Money { get; set; }
        public String GetStrAmount(){return AmountToString(Money);}
        public void CalculateBalance(double itemvalue)
        {
            Money += itemvalue;
        }
    }
}
