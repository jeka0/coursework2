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
            if (categories.Find(a => a == newCategory) != null) return true; else return false;
        }
    }
}
