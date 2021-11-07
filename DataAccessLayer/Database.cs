using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BusinessLayer;
using System.Xml.Serialization;

namespace DataAccessLayer
{
    public class Database : IModel
    {
        List<User> users;
        public List<User> GetUsers() { return users; } 
        public Database(String file)
        {
            try
            {
                users = Read<List<User>>(file);
            }
            catch { users = new List<User>(); Save<List<User>>(file, users); }
        }
        public void Save<T>(String file, T item)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                formatter.Serialize(fs, item);
            }
        }
        public T Read<T>(String file)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                return (T)formatter.Deserialize(fs);
            }
        }
        public void CreateFolder(String folder)
        {
            Directory.CreateDirectory(folder);
        }
        public Elements ReadElements(String file)
        {
            try
            {
                return Read<Elements>(file);
            }
            catch
            {
                var elements = new Elements();
                elements.categories.Add("Общее");
                Save<Elements>(file, elements);
                return elements;
            }
        }
        public List<MonthlyReport> ReadMonthlyReports(String file)
        {
            try
            {
                return Read<List<MonthlyReport>>(file);
            }
            catch
            {
                var monthlyReport = new List<MonthlyReport>();
                Save<List<MonthlyReport>>(file, monthlyReport);
                return monthlyReport;
            }
        }
    }
}
