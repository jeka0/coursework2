using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User
    {
        public String Login;
        public String Password;
        public String Surname;
        public String Name;
        public double Money;
        public void CalculateBalance(double itemvalue)
        {
            Money += itemvalue;
        }
    }
}
