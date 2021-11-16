using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Item: BusinessObject
    {
        private String date;
        private String time;
        private String category;
        private String comment;
        public String Date { get { return ReturnNonEmptyString(date); } set { date = value; } }
        public String Time { get { return ReturnNonEmptyString(time); } set { time = value; } }
        public String Category { get { return ReturnNonEmptyString(category); } set { category = value; } }
        public String Comment { get { return ReturnNonEmptyString(comment); } set { comment = value; } }
        public double Amount { get; set; }
        public String GetStrAmount(){ return AmountToString(Amount);}
    }
}
