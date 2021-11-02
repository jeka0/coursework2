using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Elements
    {
        public List<String> categories = new List<String>();
        public List<Item> items = new List<Item>();
        public bool CheckCategories(String newCategory)
        {
            bool Flag = false;
            for (int i = 0; i < categories.Count; i++)
            {
                if (newCategory == categories[i].ToString()) { Flag = true; break; }
            }
            return Flag;
        }
    }
}
