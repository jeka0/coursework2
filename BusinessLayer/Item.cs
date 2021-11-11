using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Item: BusinessObject
    {
        public String Date;
        public String Time;
        public String Category;
        public String Comment;
        public double Amount;
        public String GetStrAmount(){ return AmountToString(Amount);}
    }
}
